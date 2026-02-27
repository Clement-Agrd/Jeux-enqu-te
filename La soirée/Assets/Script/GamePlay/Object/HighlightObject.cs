using UnityEngine;

namespace GamePlay
{
    public class HighlightObject : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Color color;
        public Color highlightColor = Color.gold;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            color =  spriteRenderer.color;
        }

        public void HighlightOn()
        {
            spriteRenderer.color = highlightColor;
        }

        public void HighlightOff()
        {
            spriteRenderer.color = color;
        }
    }
}
