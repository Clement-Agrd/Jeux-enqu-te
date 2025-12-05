using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField] private Time timeScript;   // Référence vers le script Time
        [SerializeField] private Image timeCircle;  // L'image UI du fill radial

        void Update()
        {
            if (!timeScript || !timeCircle)
                return;

            // Convertir le temps en %
            float fill = (float)timeScript.currentTime / timeScript.totalTime;

            // Appliquer au cercle
            timeCircle.fillAmount = fill;
        }
    }
}