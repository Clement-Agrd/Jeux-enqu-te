using System.Collections.Generic;
using System.Linq.Expressions;
using Codice.Client.BaseCommands;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Script.Core.Data
{
    [CreateAssetMenu(fileName = "PnjData", menuName = "PnjData")]
    public class PnjData : ScriptableObject
    {
        public string Name;
        public GameObject[] GameObject;
		
        [Header("Accuse mechanic")]
        public int Accuse;
        public float Range;
        public List<ObjectData> objectDatas;

        [Header("Expression")] 
        public Sprite idle;
        public Sprite talk;
        public Sprite angry;
        public Sprite happy;
        public Sprite sad;
        public Sprite surprise;
        public enum AllExpression
        {
            IDLE,
            TALK,
            ANGRY,
            HAPPY,
            SAD,
            SUPRISE,
        }

        public Sprite GetExpression(AllExpression expression)
        {
            switch (expression)
            {
                case AllExpression.IDLE : return idle;
                case AllExpression.TALK :  return talk;
                case AllExpression.ANGRY : return angry;
                case AllExpression.HAPPY : return happy;
                case AllExpression.SAD : return sad;
                case AllExpression.SUPRISE : return surprise;
                default: return idle;
            }
        }

        public Sprite[] GetAllExpression()
        {
            return new[]
            {
                idle,
                talk,
                angry,
                happy,
                sad,
                surprise
            };
        }
    }
}