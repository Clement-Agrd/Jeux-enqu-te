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

        [SerializeField] private boolIsPickUp tel;

        private void Start()
        {
	        pauseMenuPrefab.SetActive(false);
	        mainSound.Pause();
	        secondSound.Pause();
        }
        public void StartButton()
        {
            mainSound.Play();
            tel.tel=false;
            SceneManager.LoadScene("Intro");
        }

        public void QuitGame()
        {
           secondSound.Play();
           Application.Quit(); 
        }

        public void QuitButton()
        {
	        startButton.SetActive(false);
	        pauseMenuPrefab.gameObject.SetActive(false);
	        Time.timeScale = 1;
        }

        public void PauseButton()
        {
	        secondSound.Play();
	        pauseMenuPrefab.SetActive(true);
	        Time.timeScale = 0;
	        
        }

        public void MenuButton()
        {
	        mainSound.Play();
	        Destroy(TimeManager.Instance.gameObject);
	        SceneManager.LoadScene("Menu");
        }
        
        public static void ResetSession()
        {
	        foreach (var obj in FindObjectsOfType<MonoBehaviour>())
	        {
		        if (obj.gameObject.scene.name == "DontDestroyOnLoad")
		        {
			        Destroy(obj.gameObject);
		        }
	        }
        }
    }
}
