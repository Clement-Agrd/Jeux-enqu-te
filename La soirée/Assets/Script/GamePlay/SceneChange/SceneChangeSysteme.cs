using GamePlay.Script.GamePlay.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class SceneChangeSysteme : MonoBehaviour,IInteract
    {
        [SerializeField] private string sceneName;
        public JournalManager journalManager;
        public void Interact()
        {
            journalManager = FindAnyObjectByType<JournalManager>();
            if (!journalManager.IsOpen)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
