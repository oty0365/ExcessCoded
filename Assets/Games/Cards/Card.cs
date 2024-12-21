
using System;
using TMPro;
using UnityEngine;

namespace Games.Cards
{
    public enum CardType
    {
        SoftWare,
        HardWare,
        Bug,
        
    }
    public enum VariableType
    {
        Int4,
        Bool1,
        Char1,
        Double8,
    } 
    public class Card:MonoBehaviour
    {
        [Header("카드 설정")] public string cardName;
        public int coast;
        public CardType cardType;
        public VariableType variableType;
        public int atk;
        public int hp;
        public GameObject character;
        [Header("카드 대입")] public Transform midPos;
        public TextMeshPro cardNameText;
        public TextMeshPro variableTypeText;
        public TextMeshPro atkText;
        public TextMeshPro hpText;
        public bool isInDeck;
        private void Start()
        {
            UpdateCard();
        }

        private void OnEnable()
        {
            UpdateCard();
        }

        public void UpdateCard()
        {
            //Instantiate(character, midPos, true);
            cardNameText.text = cardName;
            switch (variableType)
            {
                case VariableType.Int4:
                    variableTypeText.text = "int(4)";
                    break;
                case VariableType.Bool1:
                    variableTypeText.text = "bool(1)";
                    break;
                case VariableType.Char1:
                    variableTypeText.text = "char(1)";
                    break;
                case VariableType.Double8:
                    variableTypeText.text = "Double(8)";
                    break;

            }
            hpText.text = hp.ToString();
            atkText.text = atk.ToString();
        }
        
    }
}
