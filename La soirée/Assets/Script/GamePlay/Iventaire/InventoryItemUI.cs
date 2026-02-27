using UnityEngine;
using UnityEngine.UI;
using Core.Script.Core.Data;

public class InventoryItemUI : MonoBehaviour
{
    public Image icon;
    private ObjectData objectData;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Init(ObjectData data, System.Action<ObjectData> onClick)
    {
        objectData = data;
        icon.sprite = data.icon;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            onClick(objectData);
        });
    }
}