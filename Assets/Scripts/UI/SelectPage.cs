using System;
using UnityEngine;
using UnityEngine.UI;
using Demo.Types.BundleTypes;


namespace Demo.UI
{
    public class SelectPage : Page
    {
        [SerializeField] private Button cubeButton = null;
        [SerializeField] private Button capsuleButton = null;
        [SerializeField] private Button planButton = null;
        [SerializeField] private Button sphereButton = null;

        public Action<BundleTypes> SelectFigureAction;

        protected override void ToggleSubscription(bool subscribe)
        {
            cubeButton.onClick.RemoveAllListeners();
            capsuleButton.onClick.RemoveAllListeners();
            planButton.onClick.RemoveAllListeners();
            sphereButton.onClick.RemoveAllListeners();
            if (subscribe)
            {
                cubeButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleTypes.A1));
                capsuleButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleTypes.A2));
                planButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleTypes.A3));
                sphereButton.onClick.AddListener(() => OnSpawnButtonClicked(BundleTypes.A4));
            }
        }

        private void OnSpawnButtonClicked(BundleTypes types)
        {
            SelectFigureAction?.Invoke(types);
        }
    }
}
