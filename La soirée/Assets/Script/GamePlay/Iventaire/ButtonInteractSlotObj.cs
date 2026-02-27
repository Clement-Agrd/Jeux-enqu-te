using Core.Script.Core.Data;
using UnityEngine;

namespace GamePlay
{
    public class ButtonInteractSlotObj : MonoBehaviour
    {
        [SerializeField] private ObjectData item;

        private void Start()
        {
            item=GetComponent<ObjectData>();
        }
        public void InteractShowItem()
        {
            
            Debug.Log(item.Description);
        }
    }
}
