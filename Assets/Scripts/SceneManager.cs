using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Demo.UI;
using Demo.BundleLoader;
using Demo.BundleLoader.Types;
using Demo.Figures;

namespace Demo
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private SpawnUIController spawnUIController = null;
        [SerializeField] private EditUIController editUIController = null;
        [SerializeField] private AsyncBundleLoader asyncBundleLoader = null;
        [SerializeField] private FigureDencesInjector figureDencesInjector = null;

        private void Awake()
        {
            spawnUIController.ActionOnSpawnAction += SpawnFigure;
            editUIController.EditExitAction += OnEndEdit;
        }

        private void Start()
        {
            spawnUIController.StartSpawn();
        }

        private void SpawnFigure(BundleLoaderTypes type)
        {
            asyncBundleLoader.LoadBundle(type, OnLoadSuccess, OnLoadFailed);
            spawnUIController.StartSpawn();
        }

        private void OnLoadSuccess(Figure figure)
        {
            var instance = Instantiate(figure.gameObject, Vector3.zero, Quaternion.identity);
            var spawnFigure = instance.GetComponent<Figure>();
            spawnFigure.FigureClickedAction += OnFigureClicked;
        }

        private void OnLoadFailed(Exception exeption)
        {
            spawnUIController.StartSpawn();
        }

        private void OnFigureClicked(Figure figure)
        {
            spawnUIController.Close();
            editUIController.StartEdit(figure);
        }

        private void OnEndEdit()
        {
            spawnUIController.StartSpawn();
        }
    }
}
