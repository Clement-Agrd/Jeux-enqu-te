using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening.Core;
using TMPro;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public class intro : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private GameObject pnj;
        [SerializeField] private GameObject endPos;
        [SerializeField] private GameObject startPos;
        
        [Header("text")]
        [SerializeField] private TextMeshProUGUI firstText;
        [SerializeField] private TextMeshProUGUI secondText;
        [SerializeField] private TextMeshProUGUI thirdText;
        
        [Header("bulleDeText")]
        [SerializeField] private GameObject bulleDeText;

        private int text = 0;
        
        void Start()
        {
            bulleDeText.SetActive(false);
            firstText.gameObject.SetActive(false);
            secondText.gameObject.SetActive(false);
            thirdText.gameObject.SetActive(false);
        }
        
        void Update()
        {
            pnj.transform.DOMove(endPos.transform.position, 0.5f);

            if (pnj.transform.position == endPos.transform.position)
            {
                UI();
            }
        }

        public void addText()
        {
            text++;
        }
        private void UI()
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
            else if (text == 3)
            {
                SceneManager.LoadScene("Salon");
            }
        }
    }
}
