using System;
using GamePlay.Script.GamePlay.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

// Script pour la détéction du click de la souris. Il intéragie uniquement avec l'interface IInteract
namespace GamePlay.Script.GamePlay.Mouse2D
{
    public class MouseInputClick : MonoBehaviour
    {
        private Camera mainCamera;
        private HighlightObject lastHighlighted;
        private void Start()
        {
            mainCamera = Camera.main;
            if (mainCamera == null) return;
        }
        private void Update()
        {
            if (mainCamera == null)
                mainCamera = Camera.main;

            if (mainCamera == null)
                return;
			
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero);

            HighlightObject currentlyHighlighted = null;

            if (rayHit.collider != null)
            {
                currentlyHighlighted = rayHit.collider.GetComponent<HighlightObject>();
            }

            // Si on a changé d'objet survolé
            if (lastHighlighted != currentlyHighlighted)
            {
                // Enlever l'ancien highlight
                if (lastHighlighted != null)
                    lastHighlighted.HighlightOff();

                // Ajouter le nouveau
                if (currentlyHighlighted != null)
                    currentlyHighlighted.HighlightOn();

                lastHighlighted = currentlyHighlighted;
            }
        }

        public void OnMouseClick(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                Debug.Log("Rien");
                return;
            }
            if (mainCamera == null)
                mainCamera = Camera.main;

            if (mainCamera == null)
                return;

            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero);
			
            if (rayHit.collider == null)
            {
                Debug.Log("Aucun objet touché");
                return;
            }

            IInteract interactable=rayHit.collider.GetComponentInParent<IInteract>();
            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log("Pas de IInteract");
            }
			
        }
    }
}