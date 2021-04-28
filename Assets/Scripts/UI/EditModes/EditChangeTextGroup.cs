using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class EditChangeTextGroup : EditFunctionalityGroup
    {
        [SerializeField] private string markCarecter = "";
        [SerializeField] private Sprite markSprite = null;
        [SerializeField] GameObject buttonPrefab = null;
        [SerializeField] private TextPicker textPicker = null;
        [SerializeField] private EditPage editPage = null;

        private List<Button> spawnButtonsList = null;

        private Figure Figure = null;

        public override void Clicked()
        {
            editPage.OpenMode(this);
        }

        public override void Open()
        {
            gameObject.SetActive(false);
            textPicker.gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(true);
            textPicker.gameObject.SetActive(false);
        }

        public override void Setup(Figure figure)
        {
            spawnButtonsList = new List<Button>();
            Reset();
            Figure = figure;
            textPicker.Setup(figure, 0);
            var buttonCount = figure.TextebleCount;

            for (int i = 0; i < buttonCount; i++)
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
                button.onClick.AddListener(() => Clicked());
                spawnButtonsList.Add(button);
            }
        }

        public override void Reset()
        {
            if (spawnButtonsList == null)
                return;
            foreach (var item in spawnButtonsList)
            {
                Destroy(item.gameObject);
            }
            spawnButtonsList.Clear();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            textPicker.gameObject.SetActive(false);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            textPicker.gameObject.SetActive(false);
        }
    }
}
