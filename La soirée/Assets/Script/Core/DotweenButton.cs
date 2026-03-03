using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Core
{
    public class DotweenButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private GameObject button;

        private void Start()
        {
            button = this.gameObject;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            this.transform.DOScale(1.2f, 0.5f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.transform.DOScale(1, 0.5f);
        }

        
    }
}
