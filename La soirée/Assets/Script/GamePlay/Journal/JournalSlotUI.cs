using Core;
using GamePlay.Script.GamePlay.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GamePlay
{
    public class JournalSlotUI : MonoBehaviour
    {
        public JournalData journal;
        private bool IsOpen;

        [Header("UI")]
        [SerializeField]private Image icon;
        [SerializeField]private TextMeshProUGUI Name;
        [SerializeField]private TextMeshProUGUI Description;

        public void OpenInfo()
        {
            Debug.Log("Peut ouvrir");
            icon.sprite = journal.icon;
            Name.text = journal.name;
            Description.text = journal.descriptions[0].description;
        }
    }
}
