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

        [SerializeField] private AudioSource mainSound;
        [SerializeField] private AudioSource secondSound;

        private void Start()
        {
	        pauseMenuPrefab.SetActive(false);
	        mainSound.Pause();
	        secondSound.Pause();
        }
        public void StartButton()
        {
            SceneManager.LoadScene("Salon");
            mainSound.Play();
        }

        public void QuitGame()
        {
           Application.Quit(); 
           secondSound.Play();
        }

        public void QuitButton()
        {
	        pauseMenuPrefab.gameObject.SetActive(false);
	        Time.timeScale = 1;
	        startButton.SetActive(false);
        }

        public void PauseButton()
        {
	        pauseMenuPrefab.SetActive(true);
	        Time.timeScale = 0;
	        secondSound.Play();
	        
        }

        public void MenuButton()
        {
	        SceneManager.LoadScene("Menu");
	        mainSound.Play();
        }
        
    }
}
