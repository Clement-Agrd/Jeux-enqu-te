using GamePlay.Script.GamePlay.Interface;
using Core.Script.Core.Data;
using UnityEngine;


// C'est la base qui sera la même pour chaque objet . Pour utiliser ce script faudra le mettre à coté du Monobehaviour comme ici avec IInteract. 
// Chaque Objet à son impact sur le temp , a qui il appartient  , modif de description,collect dans l'inventaire 
namespace GamePlay.Script.GamePlay.Object
{
    public class ObjetBase : MonoBehaviour,IInteract
    {
        [SerializeField] private TimeManager timeManager;
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
            if (objectData.pnjDataRangeUp != null)
                currentAccuse = objectData.pnjDataRangeUp.Accuse;
        }

        private void Update()
        {
            if (SaveData.Instance.saveSystem.destroyedObjectIDs.Contains(objectData.ID))
            {
                Destroy(gameObject);

            }
            timeManager = FindAnyObjectByType<TimeManager>();
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

            timeManager.LooseTime(5);
            // Supprime l'objet de la scène
            Destroy(gameObject);
            
        }
        

    }
}
