using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace GamePlay.Script.GamePlay.Mouse2D
{
	public class MouseInputClick : MonoBehaviour
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
			if (playerInput.WasPerformedThisFrame())
			{
				Debug.Log("ClickInteract");
			}
		}
	}
}