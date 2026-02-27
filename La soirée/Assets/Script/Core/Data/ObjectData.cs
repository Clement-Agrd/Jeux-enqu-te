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
        public int TimeValue;
        public Sprite icon;
        public bool isActive;
        public bool isActiveForever = false;
        public string ID;

        // ✅ AJOUT ICI
        public PnjData pnjData;
        public PnjData pnjDataRangeUp;
    }
}