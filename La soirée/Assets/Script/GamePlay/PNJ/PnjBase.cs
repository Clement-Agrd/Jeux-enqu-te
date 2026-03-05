using System;
using System.Collections.Generic;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.Interface;
using GamePlay.Script.GamePlay.Mouse2D;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Script.GamePlay.PNJ
{
    public class PnjBase : MonoBehaviour,IInteract
    {
        public PnjData pnjData;
		
        [SerializeField] private GameObject [] Dialogues;
        [SerializeField] private GameObject Buttons;
        [SerializeField] private GameObject ButtonText;
        public SpriteRenderer CharaterSprite;
        private List<Inventory> inventory;
        private float Range;
        public bool talking;
        private InventoryUI inventoryUI;
        private JournalManager journalManager;
        
        [Header("Position du sprite")]
        private Vector3 StartPosition;
        public Vector3 talkPosition;

		
        public DialogueManager dialogueManager;
        
        private static bool alreadyReset = false;

        
        public void Awake()
        {
            CharaterSprite = GetComponent<SpriteRenderer>();
        }
        public void Start()
        {
            if (!alreadyReset)
            {
                pnjData.Range = 0;
                pnjData.Accuse = 0;
                alreadyReset = true;
            }

            Buttons.SetActive(false);
            CharaterSprite.sprite = pnjData.idle;
            StartPosition = transform.position;
        }
        
        void Update()
        {
            inventoryUI = FindAnyObjectByType<InventoryUI>();
        }
        public void SetExpression(PnjData.AllExpression expr)
        {
            CharaterSprite.sprite = pnjData.GetExpression(expr);
        }
        public void Interact()
        {
            journalManager = FindAnyObjectByType<JournalManager>();
            if (talking == false && !journalManager.IsOpen && !inventoryUI.inventoryPanel.activeSelf)
            {
                Debug.Log($"I am  {pnjData.name}");
                Buttons.SetActive(true);
            }
        }

        public void QuitInteract()
        {
            Buttons.SetActive(false);
            inventoryUI.Quit();
        }

        public void ResetExpression()
        {
            CharaterSprite.sprite = pnjData.idle;
        }

        public void ShowObject()
        {
            inventoryUI.ToggleInventory(true);
            foreach ( ObjectData objectData in Inventory.Instance.objects)
            {
                if (objectData.PnjDataSelf==pnjData)
                {
                    objectData.isActiveSelf = true;
                }
                else
                {
                    objectData.isActiveSelf = false;
                }
                
                if (pnjData.objectDatas.Contains(objectData))
                {
                    objectData.isActive = true;
                }
                else
                {
                    objectData.isActive = false;
                }
            }
            Debug.Log("Show Object");
        }

        
        public void Talk()
        {
            Debug.Log("Talk");
            Buttons.SetActive(false);
            talking = true;
            transform.position = talkPosition;
			
            dialogueManager.ShowChoice();
        }

        public void StopTalk()
        {
            transform.position = StartPosition;
            talking = false;
        }

        
    }
}