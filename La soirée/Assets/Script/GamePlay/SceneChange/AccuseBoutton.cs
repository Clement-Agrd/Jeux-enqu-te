using GamePlay.Script.GamePlay.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class AccuseBoutton : MonoBehaviour, IInteract

    {
        [SerializeField] private GameObject UiButton;
        [SerializeField] private GameObject YButton;
        [SerializeField] private GameObject NButton;

        void Start()
        {
            UiButton.SetActive(false);
        }


        public void Interact()
        {
            UiButton.SetActive(true);
        }

        public void YInteract()
        {
            SceneManager.LoadScene("SceneAccuse");
        }

        public void NInteract()
        {
            UiButton.SetActive(false);
        }
    }
}
