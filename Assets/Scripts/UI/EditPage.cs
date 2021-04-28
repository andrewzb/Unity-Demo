using System;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class EditPage : Page
    {
        [SerializeField] private Button exitButton = null;
        [SerializeField] private Button deleteButton = null;
        [SerializeField] private EditOptionsController colorController = null;
        [SerializeField] private EditOptionsController textController = null;

        public Action ExitAction;
        public Action DeleteAction;
        public Action<int> EditColorAction;
        public Action<int> EditTextAction;

        protected override void ToggleSubscription(bool subscribe)
        {
            exitButton.onClick.RemoveAllListeners();
            deleteButton.onClick.RemoveAllListeners();
            colorController.OnButtonClickAction = null;
            textController.OnButtonClickAction = null;
            if (subscribe)
            {
                exitButton.onClick.AddListener(() => ExitAction?.Invoke());
                deleteButton.onClick.AddListener(() => DeleteAction?.Invoke());
                colorController.OnButtonClickAction += ((index) => EditColorAction?.Invoke(index));
                textController.OnButtonClickAction += ((index) => EditTextAction?.Invoke(index));
            }
        }

        protected override void SetDefaultState()
        {
            colorController.Reset();
            textController.Reset();
        }

        public void Setup(Figure figure)
        {
            colorController.Setup(figure.ColorableCount);
            textController.Setup(figure.TextebleCount);
        }
    }
}
