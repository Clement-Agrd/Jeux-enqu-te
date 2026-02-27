using System.Collections.Generic;
using Core.Script.Core.Data;
using GamePlay.Script.GamePlay.Object;
using GamePlay.Script.GamePlay.Sauvegarde;
using UnityEngine;
//
//
// PAS TOUCHER
// Ce script Sert à sauvegarder les objet détruit d'une scene 
// à l'autre IMPORTANT pour notre jeu
//
//
namespace GamePlay
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance;
        public SaveSystem saveSystem =  new SaveSystem();
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
        public void SaveToJson()
        {
            string inventoryData = JsonUtility.ToJson(saveSystem, true);
            string filepath = Application.persistentDataPath+ "/InventoryData.json";
            
            Debug.Log(filepath);
            System.IO.File.WriteAllText(filepath, inventoryData);
            Debug.Log("Sauvegarde effectuée");
        }

        public void LoadFromJson()
        {
            string filepath = Application.persistentDataPath + "/InventoryData.json";

            if (!System.IO.File.Exists(filepath))
            {
                Debug.LogWarning("Fichier de sauvegarde introuvable");
                return;
            }

            string inventoryData = System.IO.File.ReadAllText(filepath);
            Inventory.Instance.LoadFromSave(saveSystem.destroyedObjectIDs);
            JsonUtility.FromJsonOverwrite(inventoryData, saveSystem);

            Debug.Log("Chargement effectué");
        }
        
        public void AddDestroyedObject(string id)
        {
            if (!saveSystem.destroyedObjectIDs.Contains(id))
            {
                saveSystem.destroyedObjectIDs.Add(id);
                SaveToJson();
            }
            
        }
    }
}
