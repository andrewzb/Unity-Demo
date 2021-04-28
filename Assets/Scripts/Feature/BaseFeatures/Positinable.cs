using UnityEngine;

namespace Demo.Features
{
    public abstract class Positinable : MonoBehaviour, ICompositeCountable
    {
        public int OptionCount { get; }

        public abstract Vector3 GetPosition();
        public abstract void SetPosition();
    }
}
