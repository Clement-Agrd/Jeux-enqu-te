using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class Intro : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject pnj;
        [SerializeField] private Transform endPos;
        [SerializeField] private Transform startPos;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI firstText;
        [SerializeField] private TextMeshProUGUI secondText;
        [SerializeField] private TextMeshProUGUI thirdText;

        [Header("Bulle de texte")]
        [SerializeField] private GameObject bulleDeText;

        private int text = 0;

        void Start()
        {
            pnj.transform.DOKill();
            pnj.transform.position = startPos.position;
        
            // reset UI
            bulleDeText.SetActive(false);
            firstText.gameObject.SetActive(false);
            secondText.gameObject.SetActive(false);
            thirdText.gameObject.SetActive(false);

            text = 0;
            Debug.Log(Vector3.Distance(pnj.transform.position, endPos.position));
            PlayIntro();
        }

        void PlayIntro()
        {
            Debug.Log("Playing intro");
            pnj.transform.DOMove(endPos.position, 0.5f).OnComplete(UI);

        }

        public void AddText()
        {
            text++;
            UI();
        }

        void UI()
        {
            if (text == 0)
            {
                bulleDeText.SetActive(true);
                firstText.gameObject.SetActive(true);
            }
            else if (text == 1)
            {
                firstText.gameObject.SetActive(false);
                secondText.gameObject.SetActive(true);
            }
            else if (text == 2)
            {
                secondText.gameObject.SetActive(false);
                thirdText.gameObject.SetActive(true);
            }
            else if (text >= 3)
            {
                Skip();
            }
        }

        public void Skip()
        {
            pnj.transform.DOKill();
            SceneManager.LoadScene("Salon");
        }
    }
}