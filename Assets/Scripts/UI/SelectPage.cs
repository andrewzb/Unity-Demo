using System;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;
using Demo.BundleLoader.Types;


namespace Demo.UI
{
    public class SelectPage : Page
    {
        [SerializeField] private Button cubeButton = null;
        [SerializeField] private Button capsuleButton = null;
        [SerializeField] private Button planButton = null;
        [SerializeField] private Button sphereButton = null;

        public Action<BundleLoaderTypes> SelectFigureAction;

        protected override void ToggleSubscription(bool subscribe)
        {
            cubeButton.onClick.RemoveAllListeners();
            capsuleButton.onClick.RemoveAllListeners();
            planButton.onClick.RemoveAllListeners();
            sphereButton.onClick.RemoveAllListeners();
            if (subscribe)
            {
                cubeButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleLoaderTypes.cube));
                capsuleButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleLoaderTypes.capsule));
                planButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleLoaderTypes.plane));
                sphereButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleLoaderTypes.sphere));
            }
        }

        private void OnSpawnButtonClicked(BundleLoaderTypes types)
        {
            SelectFigureAction?.Invoke(types);
        }
    }
}
