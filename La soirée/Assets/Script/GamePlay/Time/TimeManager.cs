using UnityEngine;

namespace GamePlay
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        public int totalTime = 300;
        public int currentTime = 300;

        private void Awake()
        {
            Debug.Log("TimeManager Awake sur : " + gameObject.name);

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.Log("Duplicate TimeManager détruit");
                Destroy(gameObject);
            }
        }

        void Start()
        {
            currentTime = totalTime;
        }   
        
        //action à appeller pour perdre du temps avec un int (valeur du temps perdu)
        // ReSharper disable Unity.PerformanceAnalysis
        public void LooseTime(int timeLoose)
        {
            currentTime -= timeLoose;
            if (currentTime <= 0)
                Debug.Log("Vous n'avez plus de temps");
        }

        //action à appeller pour Gagner du temps avec un int (valeur du temps gagner)
        public void AddTime(int timeAdd)
        {
            currentTime += timeAdd;
        }

        /*test pour voir si la mecanique marche
        private void FixedUpdate()
        {
            LooseTime(1);
        }
        */
    }
}
