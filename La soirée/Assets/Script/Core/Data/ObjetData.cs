using UnityEngine;

namespace Core.Script.Core.Data
{
    [CreateAssetMenu(fileName = "DataObject", menuName = "DataObject")]
    public class ObjetData : ScriptableObject
    {
        public Sprite sprite;
        public GameObject ObjetPrefab;
        public string Name;
        public string Description;
        public int Value;
    }
}
