using System.Collections;
using Core;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.PNJ;
using UnityEditor;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
namespace GamePlay
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public DialogueData dialogueData;
        public DialogueManager manager;
        public PnjBase pnjBase;
        public bool DialogueIsActive { get; private set; }
        public bool RangeIsAdd;

        private int dialogueIndex;
        private Coroutine typingCoroutine;
        private bool isTyping;
        private PnjData.AllExpression CurrentExpression;

        public void StartDialogue()
        {
            if (DialogueIsActive) return;
            //Vérifie que le dialogueData n'est pas vide
            if (dialogueData == null || dialogueData.AddDialogue.Length == 0)
            {
                Debug.LogError("DialogueData vide !");
                return;
            }
            
            // Test pour empécher un autre dialogue de se lancer
            if (!manager.TryTalk(this)) // Si quelqu’un parle déjà
            {
                Debug.LogWarning("[Dialogue] Manager occupé, dialogue ignoré.");
                return;
            }
            // Test 
            
            //Empéche de relancer un deux foi le même dialogue
            DialogueIsActive = true;
            //Empéche d'avoir des dialogues qui se chevauche
            StopTyping();
            
            
            if (manager != null && manager.Choice != null)
            {
                foreach (var choice in manager.Choice)
                {
                    if (choice != null) choice.SetActive(false);
                }
            }
            
            manager.DialogueBox.SetActive(true);

            //Vide le texte, met l'index à 0, change le sprite et lance l'écriture du texte
            dialogueIndex = 0;
            CurrentExpression = dialogueData.AddDialogue[dialogueIndex].expression;
            UpdateExpression();
            textComponent.text = "";
            StartTyping();
        }

        void Update()
        {
            
            //Test
            
            // Ne réagit que si ce Dialogue est en cours
            if (!DialogueIsActive) return;

            // IMPORTANT : si le manager a un dialogue courant différent, on ignore l'input
            if (manager != null && manager.currentDialogue != null
                                && !ReferenceEquals(manager.currentDialogue, this)) return;
            //Test
            
            //Détecte le clique gauche
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (isTyping)
                {
                    // Skip l'animation si le texte n'a pas fini d'être écrit
                    StopCoroutine(typingCoroutine);
                    textComponent.text = dialogueData.AddDialogue[dialogueIndex].text;
                    isTyping = false;
                }
                else
                {
                    //Sinon lance la prochaine boite de dialogue
                    NextDialogue();
                }
            }
        }

        void StartTyping()
        {
            //Commence la Coroutine qui gére l'écriture et la vitesse du texte
            typingCoroutine = StartCoroutine(TypeSentence());
        }
        
        void StopTyping()
        {
            //Fonction qui empéche l'écriture du texte
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
            }
            
            isTyping = false;
        }

        IEnumerator TypeSentence()
        {
            isTyping = true;
            textComponent.text = "";

            var current = dialogueData.AddDialogue[dialogueIndex];

            //Vitesse d'apparition des lettres
            foreach (char letter in current.text)
            {
                textComponent.text += letter;
                yield return new WaitForSeconds(current.textSpeed);
            }

            isTyping = false;
        }

        void NextDialogue()
        {
            dialogueIndex++;

            if (dialogueIndex < dialogueData.AddDialogue.Length)
            {
                CurrentExpression = dialogueData.AddDialogue[dialogueIndex].expression;
                UpdateExpression();
                StartTyping();
            }
            else
            {
                // Fin du dialogue
                EndDialogue();
            }

            void EndDialogue()
            {
                //Nettoie le dialogue en gros enléve tout
                Debug.Log("Ending Dialogue");
                StopTyping();
                textComponent.text = "";
                
                manager.NotifyEnded(); // libère le manager
                manager.End();

                DialogueIsActive = false;
                
                pnjBase.ResetExpression();
                AddAccuse();
            }

            void AddAccuse()
            {
                if (RangeIsAdd == true)
                {
                    Debug.Log("Nothing");
                }

                else
                {
                    pnjBase.pnjData.Range += dialogueData.AddRange;
                    Debug.Log ($"Range = {pnjBase.pnjData.Range}");
                    
                    RangeIsAdd = true;
                }
            }
        }
        void UpdateExpression()
        {
            
            if (pnjBase == null)
            {
                Debug.LogError("[Dialogue] pnjBase manquant");
                return;
            }
            pnjBase.SetExpression(CurrentExpression);
        }
    }
}