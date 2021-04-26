using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Demo.Figures;

namespace Demo.UI
{
    public class EditUIController : MonoBehaviour
    {
        [SerializeField] private EditPage editPage = null;
        private Figure editFigure = null;

        public Action EditExitAction;

        private void Awake()
        {
            editPage.ExitAction += OnExitClick;
            editPage.DeleteAction += OnDeleteClick;
        }

        public void StartEdit(Figure figure)
        {
            editFigure = figure;
            editPage.Setup(editFigure);
            editPage.Open();
        }

        private void OnExitClick()
        {
            editPage.Close();
            EditExitAction?.Invoke();
        }

        private void OnDeleteClick()
        {
            Destroy(editFigure.gameObject);
            editFigure = null;
            editPage.Close();
            EditExitAction?.Invoke();

        }
    }
}

