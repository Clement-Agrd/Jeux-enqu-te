using System.Collections.Generic;
using Core.Script.Core.Data;
using UnityEngine;

namespace GamePlay
{
    public class AccuseManager : MonoBehaviour
    {
        [SerializeField] private GameObject AccuseBoutton;
        [SerializeField] private GameObject LostScreen;
        
        [SerializeField] private List<PnjData> pnjDatas = new List<PnjData>();
        private PnjData pnjData;

        [SerializeField] private GameObject GregoryEnd;
        [SerializeField] private GameObject KarlEnd;
        [SerializeField] private GameObject DanielleEnd;
        [SerializeField] private GameObject InessEnd;
        [SerializeField] private GameObject LeoEnd;
        [SerializeField] private GameObject CB12End;

        private void Start()
        {
            LostScreen.SetActive(false);
            
            GregoryEnd.SetActive(false);
            KarlEnd.SetActive(false);
            DanielleEnd.SetActive(false);
            InessEnd.SetActive(false);
            LeoEnd.SetActive(false);
            CB12End.SetActive(false);
        }
        public void Add(PnjData pnjDataz)
        {
            pnjData =  pnjDataz;
            pnjDatas.Add(pnjDataz);
        }

        private void Remove(PnjData pnjDataz)
        {
            pnjData =  pnjDataz;
            pnjDatas.Remove(pnjDataz);
        }
        public void Retour()
        {
            AccuseBoutton.SetActive(false);
            Remove(pnjData);
        }
        public void Accuse()
        {
            Debug.Log(pnjData.name);
            
            AccuseBoutton.SetActive(false);

            if (pnjData.Range < 78)
            {
                Debug.Log("Non c'est pas moi");
                LostScreen.SetActive(true);

            }
            else
            {
                EndScreen();
                Debug.Log("C'est moi");
                //Play video de fin 
            }
        }

        private void EndScreen()
        {
            if (pnjData.name == "Gregory")
            {
                GregoryEnd.SetActive(true);
            }

            if (pnjData.name == "Karl")
            {
                KarlEnd.SetActive(true);
            }

            if (pnjData.name == "Danielle")
            {
                DanielleEnd.SetActive(true);
            }

            if (pnjData.name == "Iness")
            {
                InessEnd.SetActive(true);
            }

            if (pnjData.name == "Leo")
            {
                LeoEnd.SetActive(true);
            }

            if (pnjData.name == "CB12")
            {
                CB12End.SetActive(true);
            }
        }
    }
}
