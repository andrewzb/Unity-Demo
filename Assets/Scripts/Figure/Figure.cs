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
        [SerializeField] private List<Colorable> colorableList = null; 
        [SerializeField] private List<Textable> textableList = null;
        [SerializeField] private List<Positinable> movablePlaneList = null;
        [SerializeField] private List<Positinable> movableHeightList = null;

        // injected deps
        private EditPage editPage = null;
        private SpawnManager spawnManager = null;

        public int TextebleCount => textableList.Count > 0 ? GetICompositCountableCount<Textable>(textableList) : 0;
        public int ColorableCount => colorableList.Count > 0 ? 1 : 0;

        public void Inject(EditPage editPage, SpawnManager spawnManager)
        {
            this.editPage = editPage;
            this.spawnManager = spawnManager;
        }

        private void StartEdit()
        {
            spawnManager.Close();
            editPage.Open();
            ToggleSubscription(true);

        }

        private void OnMouseUp()
        {
            StartEdit();
            editPage.Setup(this);
        }

        private void DeleteClicked()
        {
            ToggleSubscription(false);
            editPage.Close();
            spawnManager.StartSpawn();
            Destroy(gameObject);
        }

        private void ExitClicked()
        {
            ToggleSubscription(false);
            editPage.Close();
            spawnManager.StartSpawn();
        }

        private void EditColorClick(int index)
        {
            if (colorableList.Count > 0)
                colorableList[0].SetColor(0,Color.gray);
            if (colorableList.Count > 1)
                colorableList[1].SetColor(0,Color.yellow);
        }

        private void EditTextClick(int index)
        {
            if (textableList.Count > 0)
                textableList[0].SetText(0, "ffffffffffffffffffffffffffffffffffffffffffffffffffff");
        }

        private void ToggleSubscription(bool subscribe)
        {
            editPage.DeleteAction -= DeleteClicked;
            editPage.ExitAction -= ExitClicked;
            editPage.EditColorAction -= EditColorClick;
            editPage.EditTextAction -= EditTextClick;
            if (subscribe)
            {
                editPage.DeleteAction += DeleteClicked;
                editPage.ExitAction += ExitClicked;
                editPage.EditColorAction += EditColorClick;
                editPage.EditTextAction += EditTextClick;
            }
        }

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
    }
}
