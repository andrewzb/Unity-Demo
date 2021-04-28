using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class EditPage : Page
    {
        [SerializeField] private List<EditFunctionalityGroup> functionalityGroupsList = null;
        [SerializeField] private EditFunctionalityGroup cancelFunctionalityGroup = null;
        [SerializeField] private EditFunctionalityGroup exitFunctionalityGroup = null;
        [SerializeField] private EditFunctionalityGroup deleteFunctionalityGroup = null;

        protected override void SetDefaultState()
        {
            foreach (var group in functionalityGroupsList)
            {
                group.Reset();
            }
            cancelFunctionalityGroup.Reset();
            exitFunctionalityGroup.Reset();
            deleteFunctionalityGroup.Reset();
        }

        public void Setup(Figure figure)
        {
            foreach (var group in functionalityGroupsList)
            {
                group.Setup(figure);
            }
            cancelFunctionalityGroup.Setup(figure);
            exitFunctionalityGroup.Setup(figure);
            deleteFunctionalityGroup.Setup(figure);
            OpenMode();
        }


        public void OpenMode(EditFunctionalityGroup functionalityGroup = null)
        {
            foreach (var group in functionalityGroupsList)
            {
                if (functionalityGroup == null)
                {
                    group.Show();
                }
                else
                {
                    if (group == functionalityGroup)
                    group.Open();
                else
                    group.Hide();
                }
            }
            exitFunctionalityGroup.Show();
            deleteFunctionalityGroup.Show();
            if (functionalityGroup == null)
                cancelFunctionalityGroup.Hide();
            else
                cancelFunctionalityGroup.Show();

        }
    }
}
