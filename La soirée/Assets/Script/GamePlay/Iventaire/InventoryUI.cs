using System.Threading;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.Object;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    [Header("Références UI")]
    public GameObject inventoryPanel;     // Panel principal
    public Transform content;              // Zone où apparaissent les objets
    public GameObject itemButtonPrefab;    // Bouton d'objet
    public GameObject itemDetailsPanel; // Image + description
    
    
    
    [Header("Preview")]
    public Image previewImage;              // Image en grand
    public TMP_Text descriptionText;            // Description texte
    public bool ShowingItem;
    
    void Start()
    {
        inventoryPanel.SetActive(false); // Inventaire fermé au début
        DontDestroyOnLoad(this);
        
    }

    //Sera remplacé par un bouton
    void Update()
    {
        // Vérifie si la touche I est pressée
        if (Keyboard.current != null && Keyboard.current.iKey.wasPressedThisFrame)
        {
            ToggleInventory(false);
        }
    }

    public void ToggleInventory(bool showing)
    {
        bool isOpen = !inventoryPanel.activeSelf;

        if (isOpen)
        {
            ShowingItem =  showing;
            RefreshInventory();

            // Cache image + description à l'ouverture
            itemDetailsPanel.SetActive(false);
        }
        else
        {
            ShowingItem = false;
        }
        inventoryPanel.SetActive(isOpen);
    }


    // Met à jour l'affichage
    void RefreshInventory()
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);

        foreach (ObjectData obj in Inventory.Instance.objects)
        {
            GameObject go = Instantiate(itemButtonPrefab, content);

            // On récupère le script InventoryItemUI
            InventoryItemUI itemUI = go.GetComponent<InventoryItemUI>();

            // On initialise le bouton
            itemUI.Init(obj, ShowItem);
        }
    }

    void ShowItem(ObjectData obj)
    {
        string Id;
        if (ShowingItem)
        {
            if (obj.isActive)
            {
                if (!obj.isActiveForever)
                    obj.pnjDataRangeUp.Range += obj.ShowValue;
                obj.isActiveForever = true;
                itemDetailsPanel.SetActive(true);
                previewImage.sprite = obj.icon;
                descriptionText.text = obj.ShowingDescription;
            }
            else
            {
                itemDetailsPanel.SetActive(true);
                previewImage.sprite = obj.icon;
                descriptionText.text = "Je n'ai rien a te dire sur cette objet";
            }
        }
        else
        {
            if (obj.isActiveForever)
            {
                itemDetailsPanel.SetActive(true);
                previewImage.sprite = obj.icon;
                descriptionText.text = obj.HideDescription;
            }
            else
            {
                itemDetailsPanel.SetActive(true);
                previewImage.sprite = obj.icon;
                descriptionText.text = obj.Description;
            }
        }
    }
}