using Core.Script.Core.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        [System.Serializable] public class DialogueText
        {
            public PnjData.AllExpression expression;
            [TextArea] public string text;
            [SerializeField] public float textSpeed;
            private int index;
        }
        [SerializeField] public float AddRange;
        public DialogueText[] AddDialogue;
    }
}