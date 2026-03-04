using System;
using DG.Tweening;
using GamePlay.Script.GamePlay.Interface;
using UnityEngine;

namespace GamePlay
{
    public class Tel : MonoBehaviour
    {
        public static Tel instance;
        [SerializeField] private GameObject tel;
        [SerializeField] private GameObject fleche;
        [SerializeField] private GameObject positionStart;
        [SerializeField] private GameObject positionEnd;
        [SerializeField] private boolIsPickUp tels;
        
        private bool upDown = false;

        private void Start()
        {
            fleche.SetActive(false);
        }
        
        private void Update()
        {
            
            if (tels.tel == true)
            {
                fleche.SetActive(true);
            }
            
        }

        public void Fleche()
        {
            upDown = !upDown;
            if (upDown)
            {
                tel.transform.DOMove(positionEnd.transform.position, 0.5f);
            }
            else
            {
                tel.transform.DOMove(positionStart.transform.position, 0.5f);
            }
        }
    }
}
