using System;
using GamePlay.Script.GamePlay.PNJ;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace GamePlay
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] public GameObject DialogueBox;
        [SerializeField] public GameObject [] Choice;
        public bool Italk {get; private set;}
        public PnjBase pnj;
        public Dialogue currentDialogue {get; private set;}

        private void Start()
        {
            Debug.Log("Cache les choix");
            
            DialogueBox.SetActive(false);
            
            foreach (GameObject choice in Choice)
            {
                choice.SetActive(false);
            }
        }

        public void ShowChoice()
        {
            Debug.Log("Montre les choix");
            foreach (GameObject choice in Choice)
            {
                    choice.SetActive(true); 
            }
        }
        
        //Test
        public bool TryTalk(Dialogue resquest)
        {
            
            // Si un dialogue est déjà en cours, on refuse
            if (Italk || currentDialogue != null) return false;

            // Verrou : un seul dialogue
            Italk = true;
            currentDialogue = resquest;

            // UI : cacher les choix, afficher la box
            if (Choice != null)
                foreach (var c in Choice) if (c != null) c.SetActive(false);

            if (DialogueBox != null) DialogueBox.SetActive(true);

            return true;
        }

        public void NotifyEnded()
        {
            // Libérer le verrou et l'identité du dialogue courant
            Italk = false;
            currentDialogue = null;

            // UI : cacher la box
            if (DialogueBox != null) DialogueBox.SetActive(false);
        }
        //Test

        public void ReturnUiMenu()
        {
            foreach(GameObject choice in Choice)
            {
                choice.SetActive(false);
            }
            
            pnj.talking = false;
        }
        
        public void End()
        {
            DialogueBox.SetActive(false);

            foreach (GameObject choice in Choice)
            {
                choice.SetActive(true);
            }
        }
    }
}
