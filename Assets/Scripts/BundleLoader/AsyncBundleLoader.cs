using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Demo.BundleLoader.Types;
using Demo.Figures;


namespace Demo.BundleLoader
{

    public class AsyncBundleLoader : MonoBehaviour
    {
        [SerializeField] private bool cacheResults = false;
        [SerializeField] private string url = "";
        private Dictionary<BundleLoaderTypes, string> typeToAdressDict = null;
        private Dictionary<BundleLoaderTypes, Figure> cachedBundles = null;
        private Coroutine _pendingCoroutine = null;

        private void Awake()
        {
            typeToAdressDict = new Dictionary<BundleLoaderTypes, string>();
            typeToAdressDict.Add(BundleLoaderTypes.capsule, "capsule");
            typeToAdressDict.Add(BundleLoaderTypes.cube, "cube");
            typeToAdressDict.Add(BundleLoaderTypes.sphere, "sphere");
            typeToAdressDict.Add(BundleLoaderTypes.plane, "plane");

            cachedBundles = new Dictionary<BundleLoaderTypes, Figure>();
        }

        public void LoadBundle(BundleLoaderTypes type, Action<Figure> OnSuccess, Action<Exception> OnFail)
        {
            if (cacheResults && cachedBundles.TryGetValue(type, out Figure figure))
            {
                OnSuccess(figure);
                StopPendingCoroutine();
                return;
            }

            StopPendingCoroutine();
            _pendingCoroutine = StartCoroutine(WaitForRequest(type, OnSuccess, OnFail));
        }

        private void StopPendingCoroutine()
        {
            if (_pendingCoroutine != null)
            {
                StopCoroutine(_pendingCoroutine);
                _pendingCoroutine = null;
            }
        }

        IEnumerator WaitForRequest(BundleLoaderTypes type, Action<Figure> OnSuccess, Action<Exception> OnFail)
        {
            UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle($"{url}/{type}");
            yield return www.SendWebRequest();


            if (www.result != UnityWebRequest.Result.Success)
            {
                OnFail(new Exception(www.error));
            }
            else
            {
                try
                {
                    var content = DownloadHandlerAssetBundle.GetContent(www);
                    var figure = content.LoadAsset<GameObject>($"{type.ToString()}.prefab").GetComponent<Figure>();
                    if (figure != null)
                    {
                        OnSuccess(figure);
                        if (cacheResults! && cachedBundles.TryGetValue(type, out Figure cachedFigure))
                            cachedBundles.Add(type, figure);
                    }
                    else
                        OnFail(new Exception("no element in bundle"));
        
                }
                catch (Exception _)
                {
                    OnFail(_);
                }
                finally
                {
                    AssetBundle.UnloadAllAssetBundles(false);

                }
            }
        }
    }
}
