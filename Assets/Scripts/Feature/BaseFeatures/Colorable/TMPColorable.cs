using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Demo.Features
{
    public class TMPColorable : Colorable
    {
        [SerializeField] private List<TextMeshPro> textList = null;

        public override int OptionCount => textList.Count;

        public override Color GetColor(int materialIndex = 0)
        {
            return textList[materialIndex].color;
        }

        public override void SetColor(int materialIndex, in Color color)
        {
            textList[materialIndex].color = color;
        }
    }
}
