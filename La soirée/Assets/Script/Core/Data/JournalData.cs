using Core.Script.Core.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [CreateAssetMenu(fileName = "JournalData", menuName = "Scriptable Objects/JournalData")]
    public class JournalData : ScriptableObject
    {
        [Header("Info")]
        public Sprite icon;
        public string name;

        [System.Serializable]
        public class Description
        {
            public string titre;
            public int ID;
            [TextArea] public string description;
        }
        
        public Description[]  descriptions;
    }
}
