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

        private void Start()
        {
            LostScreen.SetActive(false);
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
                Debug.Log("C'est moi");
                //Play video de fin 
            }
        }
    }
}
