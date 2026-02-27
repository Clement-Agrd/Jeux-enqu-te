using GamePlay.Script.GamePlay.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class SceneChangeSysteme : MonoBehaviour,IInteract
    {
        [SerializeField] private string sceneName;
        public void Interact()
        {
            SceneManager.LoadScene(sceneName);
            
        }
    }
}
