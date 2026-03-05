using UnityEngine;
using UnityEngine.InputSystem;

namespace GamePlay
{
    public class JournalManager : MonoBehaviour
    {
        public GameObject journalPanel;
        public bool IsOpen;

        void Start()
        {
            CloseJournal();
        }
        void Update()
        {
            if (Keyboard.current != null && Keyboard.current.uKey.wasPressedThisFrame)
            {
                if (IsOpen == false)
                    OpenJournal();

                else 
                    CloseJournal();
            }
        }

        private void OpenJournal()
        {
            journalPanel.SetActive(true);
            IsOpen = true;
        }

        private void CloseJournal()
        {
            journalPanel.SetActive(false);
            IsOpen = false;
            Debug.Log("IsOpen=" + IsOpen);
        }
    }
}
