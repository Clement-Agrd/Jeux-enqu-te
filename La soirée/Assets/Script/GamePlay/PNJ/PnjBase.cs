using System;
using System.Collections.Generic;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.Interface;
using GamePlay.Script.GamePlay.Mouse2D;
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

		
        public DialogueManager dialogueManager;

        public void Awake()
        {
            CharaterSprite = GetComponent<SpriteRenderer>();
        }

        public void Start()
        {
            Debug.Log(pnjData.name);
            pnjData.Accuse = 0;
            pnjData.Range = 0;
            Buttons.SetActive(false);
            CharaterSprite.sprite = pnjData.idle;
            
            if(Buttons!=null)return;
        }

        public void SetExpression(PnjData.AllExpression expr)
        {
            CharaterSprite.sprite = pnjData.GetExpression(expr);
        }
        public void Interact()
        {
            if (talking == false)
            {
                Debug.Log($"I am  {pnjData.name}");
                Buttons.SetActive(true);
            }
        }

        public void ResetExpression()
        {
            CharaterSprite.sprite = pnjData.idle;
        }

        public void ShowObject(InventoryUI inventory)
        {
            inventory.ToggleInventory(true);
            foreach ( ObjectData objectData in Inventory.Instance.objects)
            {
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
			
            dialogueManager.ShowChoice();
        }

        public void Accuse()
        {
			
            if (pnjData.Range <10)
            {
                Debug.Log("Non c'est pas moi");
            }
            else
            {
                Debug.Log("C'est moi");
                //Play video de fin 
            }
        }
    }
}