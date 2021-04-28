using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Demo.Features
{
    public class TMPTextable : Textable
    {
        [SerializeField] private List<TextMeshPro> textList = null;

        public override int OptionCount => textList.Count;

        public override string GetText()
        {
            return textList[0].text;
        }

        public override void SetText(int materialIndex, string text)
        {
            textList[materialIndex].text = text;
        }
    }
}
