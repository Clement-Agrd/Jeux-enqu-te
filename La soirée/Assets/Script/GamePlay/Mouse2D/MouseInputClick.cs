using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace GamePlay.Script.GamePlay.Mouse2D
{
	public class MouseInputClick : MonoBehaviour, IInteract
	{
		public  InputAction playerInput;

		private void OnEnable()
		{
			playerInput.Enable();
		}
		private void OnDisable()
		{
			playerInput.Disable();
		}

		private void Update()
		{
			Interact();
		}

		public void Interact()
		{
			
		}
	}
}