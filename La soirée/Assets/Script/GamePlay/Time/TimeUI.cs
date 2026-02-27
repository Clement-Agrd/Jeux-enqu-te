using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GamePlay
{
    public class TimeUI : MonoBehaviour
    {
        [FormerlySerializedAs("timeScript")] [SerializeField] private TimeManager timeManagerScript;   // Référence vers le script Time
        [SerializeField] private Image timeCircle;  // L'image UI du fill radial

        void Update()
        {
            if (!timeManagerScript || !timeCircle)
                return;

            // Convertir le temps en %
            float fill = (float)timeManagerScript.currentTime / timeManagerScript.totalTime;

            // Appliquer au cercle
            timeCircle.fillAmount = fill;
        }
    }
}