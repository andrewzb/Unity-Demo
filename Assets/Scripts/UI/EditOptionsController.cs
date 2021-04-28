using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Demo.Features;
using TMPro;

namespace Demo.UI
{
    public class EditOptionsController : MonoBehaviour
    {
        [SerializeField] private string markCarecter = "";
        [SerializeField] private Sprite markSprite = null;
        [SerializeField] GameObject buttonPrefab = null;
        private List<Button> spawnButtonsList = null;

        public Action<int> OnButtonClickAction;

        private void Awake()
        {
            spawnButtonsList = new List<Button>();
        }

        public void Setup(int count)
        {
            Reset();
            spawnButtonsList.Clear();


            for (int i = 0; i < count; i++)
            {
                var instance = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
                var button = instance.GetComponent<Button>();
                var image = instance.GetComponentInChildren<Image>();
                var tmp = instance.GetComponentInChildren<TextMeshProUGUI>();
                if (string.IsNullOrWhiteSpace(markCarecter) && markSprite != null)
                {
                    Destroy(tmp.gameObject);
                    image.sprite = markSprite;
                }
                else
                {
                    tmp.text = $"{markCarecter}{i + 1}";
                }
                instance.transform.SetParent(transform);
                var scopeIndex = i;
                button.onClick.AddListener(() => OnButtonClickAction?.Invoke(scopeIndex));
                spawnButtonsList.Add(button);
            }

        }

        public void Reset()
        {
            if (spawnButtonsList == null)
                return;
            foreach (var item in spawnButtonsList)
            {
                Destroy(item.gameObject);
            }
        }
    }
}