using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Demo.Features
{
    public class MeshRendererColorable : Colorable
    {
        [SerializeField] private MeshRenderer meshRenderer = null;
        [SerializeField] private string selector = "";

        public override int OptionCount => meshRenderer.materials.Length;

        public override Color GetColor(int materialIndex)
        {
            return meshRenderer.sharedMaterials[materialIndex].GetColor(selector);
        }

        public override void SetColor(int materialIndex, in Color color)
        {
            meshRenderer.sharedMaterials[materialIndex].SetColor(selector, color);
        }
    }
}
