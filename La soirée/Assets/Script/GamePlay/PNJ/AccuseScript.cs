using System;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.Interface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay
{
    public class AccuseScript : MonoBehaviour,IInteract

    {
    [SerializeField] private PnjData pnjData;

    [SerializeField] private GameObject AccuseBoutton;
    [SerializeField] private AccuseManager accuseManager;

    private void Start()
    {
        AccuseBoutton.SetActive(false);
    }

    public void Interact()
    {
        AccuseBoutton.SetActive(true);
        accuseManager.Add(pnjData);
        
    }
    }
}
