using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Demo.Figures;
using Demo.BundleLoader.Types;

namespace Demo.UI
{
    public class SpawnUIController : MonoBehaviour
    {
        [SerializeField] private SelectPage selectPage = null;
        [SerializeField] private SpawnPage spawnPage = null;
        private BundleLoaderTypes spawnType = BundleLoaderTypes.none;

       public Action<BundleLoaderTypes> ActionOnSpawnAction;

        private void Awake()
        {
            selectPage.SelectFigureAction += OnSelectButtonClicked;
            spawnPage.AcseptButtonAction += OnAcseptClicked;
            spawnPage.CancelButtonAction += OnCancelClicked;
        }

        public void StartSpawn()
        {
            selectPage.Open();
            spawnPage.Close();
            spawnType = BundleLoaderTypes.none;
        }

        public void Close()
        {
            selectPage.Close();
            spawnPage.Close();
        }

        private void OnSelectButtonClicked(BundleLoaderTypes type)
        {
            spawnType = type;
            selectPage.Close();
            spawnPage.Open();
        }

        private void OnAcseptClicked()
        {
            ActionOnSpawnAction?.Invoke(spawnType);
        }

        private void OnCancelClicked()
        {
            spawnType = BundleLoaderTypes.none;
            StartSpawn();
        }


    }
}

