using System;
using System.Collections.Generic;
using UnityEngine;
//Mise à jour de l'affichage ShowObject
namespace GamePlay
{
    public class ShowObjectUI : MonoBehaviour
    {
        [SerializeField] private ShowPanelObject panelObject;
        [SerializeField] private Transform objectParent;
        [SerializeField] private GameObject slotsItem;



        private void OnEnable()
        {
            panelObject.ItemAdded += RefreshUI;

        }

        private void OnDisable()
        {
            panelObject.ItemAdded -= RefreshUI;
        }

        public void RefreshUI()
        {

            int i = 0;
            
            foreach (var obj in panelObject.objectPersonal)
            {
                if (i >= objectParent.childCount)
                    Instantiate(slotsItem, objectParent);

                objectParent.GetChild(i).GetComponent<ButtonObjectUI>().Setup(obj);
                i++;
            }
        }
    }
}
