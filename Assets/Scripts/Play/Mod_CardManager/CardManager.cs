using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardManager
{
    public class CardManager : MonoBehaviour
    {
        /// <summary>
        /// 卡牌管理器单例
        /// </summary>
        public static CardManager cardManager;

        /// <summary>
        /// 初级卡牌存放列表
        /// </summary>
        public List<Card> JuniorCards = new List<Card>();
        /// <summary>
        /// 中级卡牌存放列表
        /// </summary>
        public List<Card> MediumCards = new List<Card>();
        /// <summary>
        /// 高级卡牌存放列表
        /// </summary>
        public List<Card> SeniorCards = new List<Card>();

        private void Awake()
        {
            cardManager = this;
        }

        /// <summary>
        /// 抽卡函数
        /// </summary>
        public void Gacha()
        {

        }

        public void GotResult(CardResult _result)
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<CardLoader>().LoadCard();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

