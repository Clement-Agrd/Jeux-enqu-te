using System;
using UnityEngine;

namespace Core.Script.Core.Data
{
    [CreateAssetMenu(fileName = "DataObject", menuName = "DataObject")]
    public class ObjectData : ScriptableObject
    {
        public GameObject ObjetPrefab;
        public string Name;
        public string Description;
        public string HideDescription;
        public string ShowingDescription;
        public int ShowValue;
        public int InteractValue;
        public int TimeValue; // Temps perdu ou gagné
        public Sprite icon;
        public bool isActive;
        public bool isActiveForever = false;
        public string ID;


    }
}
