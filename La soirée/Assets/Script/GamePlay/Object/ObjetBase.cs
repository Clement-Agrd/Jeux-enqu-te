using System;
using GamePlay.Script.GamePlay.Interface;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.Mouse2D;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;


// C'est la base qui sera la même pour chaque objet . Pour utiliser ce script faudra le mettre à coté du Monobehaviour comme ici avec IInteract. 
// Chaque Objet à son impact sur le temp , a qui il appartient  , modif de description,collect dans l'inventaire 
namespace GamePlay.Script.GamePlay.Object
{
    public class ObjetBase : MonoBehaviour,IInteract
    {
        public ObjectData objectData;
        private SaveData saveData;
        private int currentAccuse;

        void Awake()
        {
            objectData.isActive = false;
            objectData.isActiveForever = false;
        }
        void Start()
        { 
            if (objectData.pnjData != null)
                currentAccuse = objectData.pnjData.Accuse;
        }

        private void Update()
        {
            if (SaveData.Instance.saveSystem.destroyedObjectIDs.Contains(objectData.ID))
            {
                Destroy(gameObject);

            }
        }
        public void Interact()
        {
            Debug.Log($"Is a {objectData.Name}");

            // Impact sur le PNJ
            if (objectData.pnjDataRangeUp != null)
            {
                objectData.pnjDataRangeUp.Range += objectData.InteractValue;
            }

            // Ajout à l'inventaire
            Inventory.Instance.AddObject(objectData);
            SaveData.Instance.AddDestroyedObject(objectData.ID);

            Value();
            // Supprime l'objet de la scène
            Destroy(gameObject);
            
        }
        
        
       
        public void Value()
        {
            var timeManager = FindObjectOfType<TimeManager>();
            if (timeManager != null)
                timeManager.LooseTime(objectData.TimeValue);
            else
                Debug.LogWarning("TimeManager introuvable dans la scène.");
        }

    }
}
