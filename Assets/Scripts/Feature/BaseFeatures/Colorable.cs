using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Features
{
    public abstract class Colorable : MonoBehaviour, ICompositeCountable
    {
        public abstract int OptionCount { get; }

        private static MaterialPropertyBlock _propertyBlock;
        protected static MaterialPropertyBlock PropertyBlock
            => _propertyBlock ?? (_propertyBlock = new MaterialPropertyBlock());

        public abstract Color GetColor(int materialIndex);
        public abstract void SetColor(int materialIndex, in Color color);
    }
}
