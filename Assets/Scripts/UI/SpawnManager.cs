using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Demo.Types.BundleTypes;
using Demo.Figures;
using Demo.UI;

public class SpawnManager : MonoBehaviour
{
    [Header("components")]
    [SerializeField] private string url = "";
    [SerializeField] private bool cacheResults = false;
    [Header("ui")]
    [SerializeField] private SelectPage selectPage = null;
    [SerializeField] private SpawnPage spawnPage = null;
    [Header("ui edit")]
    [SerializeField] private EditPage editPage = null;

    private BundleTypes spawnType = BundleTypes.none;
    private Dictionary<BundleTypes, AssetBundle> cachedBundles = null;
    private Coroutine _pendingCoroutine = null;


    #region LiveCycle
    private void Awake()
    {
        cachedBundles = new Dictionary<BundleTypes, AssetBundle>();
        selectPage.SelectFigureAction += OnSelectButtonClicked;
        spawnPage.AcseptButtonAction += OnAcseptClicked;
        spawnPage.CancelButtonAction += OnCancelClicked;
    }

    private void Start()
    {
        StartSpawn();
    }

    #endregion

    #region Spawn

    private void SpawnSelected(BundleTypes type)
    {
        if (cacheResults && cachedBundles.TryGetValue(type, out AssetBundle assetBundle))
        {
            SpawnObject(assetBundle);
            StopPendingCoroutine();
            return;
        }

        StopPendingCoroutine();
        _pendingCoroutine = StartCoroutine(SendRequest(type));
    }

    private IEnumerator SendRequest(BundleTypes type)
    {
        using (UnityWebRequest req = UnityWebRequestAssetBundle.GetAssetBundle($"{url}/{type}"))
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
            {
                OnLoadError(new Exception(req.error));
            }
            else
            {
                SpawnObject(DownloadHandlerAssetBundle.GetContent(req));
            }
        }
    }

    private void StopPendingCoroutine()
    {
        if (_pendingCoroutine != null)
        {
            StopCoroutine(_pendingCoroutine);
            _pendingCoroutine = null;
        }
    }

    private void OnLoadError(Exception exeption)
    {
        Debug.LogError(exeption);
        StartSpawn();
    }

    private void SpawnObject(AssetBundle assetBundle)
    {
        try
        {
            var figure = assetBundle.LoadAsset<GameObject>("figure.prefab").GetComponent<Figure>();
            var instance = Instantiate(figure, Vector3.zero, Quaternion.identity);
            instance.GetComponent<Figure>().Inject(editPage, this);
            assetBundle.Unload(false);
            StartSpawn();
        }
        catch
        {
            OnLoadError(new Exception("no figure in prefab"));
        }
    }

    #endregion


    #region UI

    public void StartSpawn()
    {
        selectPage.Open();
        spawnPage.Close();
        spawnType = BundleTypes.none;
    }

    public void Close()
    {
        selectPage.Close();
        spawnPage.Close();
    }

    private void OnSelectButtonClicked(BundleTypes type)
    {
        spawnType = type;
        selectPage.Close();
        spawnPage.Open();
    }

    private void OnAcseptClicked()
    {
        SpawnSelected(spawnType);
    }

    private void OnCancelClicked()
    {
        spawnType = BundleTypes.none;
        StartSpawn();
    }
    #endregion





}
