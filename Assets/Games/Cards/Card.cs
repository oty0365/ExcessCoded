
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
    public class Card:MonoBehaviour
    {
        [Header("카드 설정")] public string cardName;
        public int coast;
        public CardType cardType;
        public int atk;
        public int hp;
        public GameObject character;
        [Header("카드 대입")] public Transform midPos;
        public TextMeshPro cardNameText;
        public TextMeshPro atkText;
        public TextMeshPro hpText;

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
            hpText.text = hp.ToString();
            atkText.text = atk.ToString();
        }
        
    }
}
