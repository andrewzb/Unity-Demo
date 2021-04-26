using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Figures
{
    public class Figure : MonoBehaviour
    {

        public Action<Figure> FigureClickedAction;

        private void OnMouseUp()
        {
            FigureClickedAction?.Invoke(this);
        }

    }
}
