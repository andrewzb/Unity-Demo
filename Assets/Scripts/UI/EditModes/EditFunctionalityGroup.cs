using UnityEngine;
using Demo.Figures;

namespace Demo.UI
{
    public abstract class EditFunctionalityGroup : MonoBehaviour
    {
        public virtual void Open() { }

        public virtual void Close() { }

        public virtual void Setup(Figure figure) { }

        public virtual void Reset() { }

        public virtual void Clicked() { }

        public virtual void Show() { }

        public virtual void Hide() { }
    }
}
