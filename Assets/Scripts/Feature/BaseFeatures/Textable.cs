using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Features
{
    public abstract class Textable : MonoBehaviour, ICompositeCountable
    {
        public abstract int OptionCount { get; }
        public abstract string GetText();
        public abstract void SetText(int materialIndex, string text);
    }
}
