using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Demo.Figures;

namespace Demo.UI
{
    public class EditChangeColorGroup : EditFunctionalityGroup
    {
        [SerializeField] private Button colorButton = null;
        [SerializeField] private ColorPiker colorPicker = null;
        [SerializeField] private EditPage editPage = null;

        private Figure Figure = null;

        public override void Clicked()
        {
            editPage.OpenMode(this);
        }

        public override void Open()
        {
            colorPicker.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public override void Close()
        {
            colorPicker.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        public override void Setup(Figure figure)
        {
            Figure = figure;
            colorPicker.Setup(figure, 0);
        }

        public override void Reset() { }

        public override void Show()
        {
            colorPicker.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            colorPicker.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            colorButton.onClick.AddListener(() => Clicked());
        }

        private void OnDisable()
        {
            colorButton.onClick.RemoveAllListeners();
        }

    }
}

/*

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
*/