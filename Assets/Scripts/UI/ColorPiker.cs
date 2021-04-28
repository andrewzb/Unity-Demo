using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class ColorPiker : MonoBehaviour
    {
        [SerializeField] private List<Button> btnList = null;
        [SerializeField] private List<Image> imgList = null;
        private Figure figure = null;
        private int index = 0;

        private void OnEnable()
        {
            for (int i = 0; i < btnList.Count; i++)
            {
                var scopeIndex = i;
                btnList[scopeIndex].onClick.AddListener(() => figure.SetColor(index, imgList[scopeIndex].color));
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
