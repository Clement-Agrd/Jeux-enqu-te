using System;
using System.Collections.Generic;
using Core.Script.Core.Data;
using UnityEngine;

namespace GamePlay
{
    public class ShowPanelObject : MonoBehaviour
    {
        public List<ObjectData> objectPersonal;
        public event Action ItemAdded;

        private void Start()
        {
            objectPersonal = new List<ObjectData>();
            
        }

        public void AddQuestion(ObjectData item)
        {
            if (!objectPersonal.Exists(o => o.ID == item.ID))
            {
                objectPersonal.Add(item);
                Debug.Log(objectPersonal.Count);
                ItemAdded?.Invoke();
            }
        }
    }
}
