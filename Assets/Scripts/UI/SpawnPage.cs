using System;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.UI
{
    public class SpawnPage : Page
    {
        [SerializeField] private Button acceptButton = null;
        [SerializeField] private Button cancelButton = null;

        public Action AcseptButtonAction;
        public Action CancelButtonAction;

        protected override void ToggleSubscription(bool subscribe)
        {
            acceptButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
            if (subscribe)
            {
                acceptButton.onClick.AddListener(() => AcseptButtonAction?.Invoke());
                cancelButton.onClick.AddListener(() => CancelButtonAction?.Invoke());
            }
        }
    }
}
