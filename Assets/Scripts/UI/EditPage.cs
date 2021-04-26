using System;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;
using Demo.BundleLoader.Types;


namespace Demo.UI
{
    public class EditPage : Page
    {
        [SerializeField] private Button exitButton = null;
        [SerializeField] private Button deleteButton = null;

        public Action ExitAction;
        public Action DeleteAction;

        protected override void ToggleSubscription(bool subscribe)
        {
            exitButton.onClick.RemoveAllListeners();
            deleteButton.onClick.RemoveAllListeners();
            if (subscribe)
            {
                exitButton.onClick.AddListener(() => ExitAction?.Invoke());
                deleteButton.onClick.AddListener(() => DeleteAction?.Invoke());
            }
        }

        public void Setup(Figure figure)
        {

        }
    }
}
