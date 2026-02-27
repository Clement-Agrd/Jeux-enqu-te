using System;
using System.Collections.Generic;
using UnityEngine;
using Core.Script.Core.Data;
using GamePlay;
using GamePlay.Script.GamePlay.Sauvegarde;


public class Inventory : MonoBehaviour
{
    // Instance globale (accessible partout)
    public static Inventory Instance;
    public ObjectData objectData;
    
    // Liste des objets ramassés
    public List<ObjectData> objects = new List<ObjectData>();
    private bool added = false;

    void Awake()
    {
        // Singleton basique
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    // Ajouter un objet à l'inventaire
    public void AddObject(ObjectData data)
    {
        objects.Add(data);
        Debug.Log($"Objet ajouté à l'inventaire : {data.Name}");
        
        
    }
    
    public void LoadFromSave(List<string> savedIDs)
    {
        objects.Clear();

        foreach (string id in savedIDs)
        {
            ObjectData data = ObjetDataBase.Instance.GetObjectByID(id);

            if (data != null)
            {
                objects.Add(data);
                Debug.Log("Objet chargé depuis la sauvegarde : " + data.Name);
            }
            else
            {
                Debug.LogWarning("Objet introuvable pour ID : " + id);
            }
        }

        Debug.Log("Inventaire reconstruit. Total : " + objects.Count);
    }
}