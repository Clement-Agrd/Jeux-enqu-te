using Core.Script.Core.Data;
using UnityEngine;
using UnityEngine.UI;
//Normalement il sert à pouvoir intéragir avec
namespace GamePlay
{
	public class ButtonObjectUI : MonoBehaviour
	{
		private ObjectData objectData;
		public Image icon;
		public void Setup(ObjectData obj)
		{
			objectData = obj;

			if (icon != null && objectData.icon != null)
			{
				icon.sprite = objectData.icon;
			}
		}
	}
}