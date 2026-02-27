using System.Collections.Generic;
using Core.Script.Core.Data;
using UnityEngine;

namespace GamePlay.Script.GamePlay.Sauvegarde
{
	public class ObjetDataBase : MonoBehaviour
	{
		public static ObjetDataBase Instance;
		public List<ObjectData> allObjects;

		void Awake()
		{
			Instance = this;
		}

		public ObjectData GetObjectByID(string id)
		{
			return allObjects.Find(obj => obj.ID == id);
		}
	}
}