using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class TextPicker : MonoBehaviour
    {
        [SerializeField] private List<Button> btnList = null;
        [SerializeField] private List<TextMeshProUGUI> textList = null;
        private Figure figure = null;
        private int index = 0;

        private void OnEnable()
        {
            for (int i = 0; i < btnList.Count; i++)
            {
                var scopeIndex = i;
                btnList[scopeIndex].onClick.AddListener(() => figure.SetText(index, textList[scopeIndex].text));
            }
        }

        private void OnDisable()
        {
            foreach (var item in btnList)
            {
                item.onClick.RemoveAllListeners();
            }
        }

        public void Setup(Figure figure, int index)
        {
            this.figure = figure;
            this.index = index;

        }
    }
}
