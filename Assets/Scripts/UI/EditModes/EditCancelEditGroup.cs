using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class EditCancelEditGroup : EditFunctionalityGroup
    {
        [SerializeField] private Button cancelEditButton = null;
        [SerializeField] private EditPage editPage = null;

        private Figure Figure = null;

        public override void Clicked()
        {
            editPage.OpenMode();
        }

        public override void Open() { }

        public override void Close() { }

        public override void Setup(Figure figure)
        {
            Figure = figure;
        }

        public override void Reset() { }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            cancelEditButton.onClick.AddListener(() => Clicked());
        }

        private void OnDisable()
        {
            cancelEditButton.onClick.RemoveAllListeners();
        }

    }
}
