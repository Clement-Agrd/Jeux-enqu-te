using UnityEngine;

namespace GamePlay
{
    public class AppPhone : MonoBehaviour
    {
        [Header("App")]
        [SerializeField] private GameObject iconTiktok;
        [SerializeField] private GameObject iconNote;
        [SerializeField] private GameObject aNote;
        [SerializeField] private GameObject bNote;
        [SerializeField] private GameObject iconMessage;
        [SerializeField] private GameObject messageMessage;
        [SerializeField] private GameObject iconMail;
        [SerializeField] private GameObject mailMail;
        
        [Header("Touche tel")]
        [SerializeField] private GameObject toucheTel;

        private bool openMessage = false;
        private bool openNote = false;
        private bool openTiktok = false;
        private bool openMail = false;

        private int screenSlide = 0;
        [SerializeField] private float speed;


        private void Start()
        {
            screenSlide = 0;
            /*iconTiktok.SetActive(false);
            iconNote.SetActive(false);
            iconMessage.SetActive(false);
            iconMail.SetActive(false);*/
            mailMail.SetActive(false);
            aNote.SetActive(false);
            bNote.SetActive(false);
            messageMessage.SetActive(false);

            iconMail.transform.localScale = Vector3.zero;
            iconMessage.transform.localScale = Vector3.zero;
            iconTiktok.transform.localScale = Vector3.zero;
            iconNote.transform.localScale = Vector3.zero;
        }

        private void Update()
        {
            if (openTiktok)
                iconTiktok.transform.localScale = Vector3.Lerp(iconTiktok.transform.localScale, Vector3.one, Time.deltaTime *  speed);
            if (openNote)
                iconNote.transform.localScale = Vector3.Lerp(iconNote.transform.localScale, Vector3.one, Time.deltaTime*speed);
            if (openMail)
                iconMail.transform.localScale = Vector3.Lerp(iconMail.transform.localScale, Vector3.one, Time.deltaTime*speed);
            if (openMessage)
                iconMessage.transform.localScale = Vector3.Lerp(iconMessage.transform.localScale, Vector3.one, Time.deltaTime * speed);

        }

        private void RefreshScreen()
        {
            if (openNote)
            {
                AppNote();
                Debug.Log(openNote);
            }
            if (openTiktok)
            {
                Debug.Log(openTiktok);
                AppTikTok();
            }
            if (openMail)
            {
                AppMail();
                Debug.Log(openMail);
            }
            if(openMessage)
            {
                AppMassage();
                Debug.Log(openMessage);
            }
        }

        public void AppTikTok()
        {
            if(screenSlide == 0)
            {
                openTiktok = true;
                
            }
            
            //LostTime
        }
//*/*******************
        public void AppMassage()
        { 
            if(screenSlide == 0)
            {
                openMessage = true;
                iconMessage.transform.localScale = Vector3.Lerp(iconMessage.transform.localScale, Vector3.one, Time.deltaTime*0.45f);
                messageMessage.SetActive(false);
                screenSlide++;
                
            }
        }

        public void FirstMessage()
        {
            if (openMessage)
            {
                messageMessage.SetActive(true);
            }
        }
//*/*******************
        public void AppNote()
        {if(screenSlide == 0)
            {
                openNote = true;
                aNote.SetActive(false);
                bNote.SetActive(false);
                screenSlide++;
            }
        }

        public void FirstNote()
        {
            if (openNote)
            {
                aNote.SetActive(true);
            }
        }
        public void SecondNote()
        {
            if (openNote)
            {
                bNote.SetActive(true);
            }
        }
//*/*******************
        public void AppMail()
        {if(screenSlide == 0)
            {
                openMail = true;
                
                mailMail.SetActive(false);
                screenSlide++;
            }
        }

        public void FirstMail()
        {
            if (openMail)
            {
                mailMail.SetActive(true);
            }
        }
//*/*******************
        public void Menu()
        {
            iconMail.transform.localScale = Vector3.zero;
            iconMessage.transform.localScale = Vector3.zero;
            iconTiktok.transform.localScale = Vector3.zero;
            iconNote.transform.localScale = Vector3.zero;
            mailMail.SetActive(false);
            aNote.SetActive(false);
            bNote.SetActive(false);
            messageMessage.SetActive(false); 
            
            openMessage = false;
            openNote = false;
            openTiktok = false;
            openMail = false;
            screenSlide = 0; 
        }

        public void Back()
        {
            screenSlide=0;
            RefreshScreen();
        }
        
    }
}
