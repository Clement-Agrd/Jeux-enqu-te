using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuPrefab;
        [SerializeField] private GameObject pauseMenuPrefab;
        [SerializeField] private GameObject startButton;
        [SerializeField] private GameObject quitButton;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject menuButton;

        private void Start()
        {
	        pauseMenuPrefab.SetActive(false);
        }
        public void StartButton()
        {
            SceneManager.LoadScene("Salon");
        }

        public void QuitGame()
        {
           Application.Quit(); 
        }

        public void QuitButton()
        {
	        pauseMenuPrefab.gameObject.SetActive(false);
	        Time.timeScale = 1;
        }

        public void PauseButton()
        {
	        pauseMenuPrefab.SetActive(true);
	        Time.timeScale = 0;
	        
        }

        public void MenuButton()
        {
	        SceneManager.LoadScene("Menu");
        }
        
    }
}
