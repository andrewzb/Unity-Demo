using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Demo.UI;
using Demo.Features;

namespace Demo.Figures
{
    public class Figure : MonoBehaviour
    {
        #region EDIT OPTIONS
        [SerializeField] private List<Colorable> colorableList = null; 
        [SerializeField] private List<Textable> textableList = null;
        [SerializeField] private List<Positinable> movablePlaneList = null;
        [SerializeField] private List<Positinable> movableHeightList = null;
        #endregion

        // injected deps
        #region INJECTED EDIT DEPENDENCIES
        private EditPage editPage = null;
        private SpawnManager spawnManager = null;
        #endregion

        #region EDIT OPTIONS
        public int TextebleCount => textableList.Count > 0 ? GetICompositCountableCount<Textable>(textableList) : 0;
        public int ColorableCount => colorableList.Count > 0 ? 1 : 0;

        private int GetICompositCountableCount<T>(List<T> colorableList) where T : ICompositeCountable
        {
            int count = 0;
            foreach (var item in colorableList)
            {
                count += item.OptionCount;
            }
            return count;
        }

        private T GetICompositCountable<T>(int commonIndex, out int localIndex, List<T> colorableList) where T : ICompositeCountable
        {
            var index = 0;
            var colorableIndex = 0;
            for (int i = 0; i < colorableList.Count; i++)
            {
                if ((index + colorableList[i].OptionCount) > commonIndex)
                {
                    colorableIndex = i;
                    break;
                }
                index += colorableList[i].OptionCount;
            }
            localIndex = commonIndex - index;
            return colorableList[colorableIndex];
        }
        #endregion

        #region UTILS

        private void StartEdit()
        {
            spawnManager.Close();
            editPage.Open();
        }

        private void OnMouseUp()
        {
            StartEdit();
            editPage.Setup(this);
        }

        #endregion

        #region API

        public void Inject(EditPage editPage, SpawnManager spawnManager)
        {
            this.editPage = editPage;
            this.spawnManager = spawnManager;
        }

        public void DeleteFigure()
        {
            editPage.Close();
            spawnManager.StartSpawn();
            Destroy(gameObject);
        }

        public void EditExit()
        {
            editPage.Close();
            spawnManager.StartSpawn();
        }

        public void CancelEdit()
        {

        }

        public void SetColor(int index, Color color)
        {
            colorableList[index].SetColor(0, color);
        }

        public Color GetColor(int index)
        {
            return colorableList[index].GetColor(0);
        }

        public string GetText(int index)
        {
            return textableList[index].GetText();
        }

        public void SetText(int index, string text)
        {
            textableList[index].SetText(index, text);
        }

        #endregion

    }
}
