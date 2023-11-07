using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerManager;

namespace CardManager
{
    public class CardManager : MonoBehaviour
    {
        /// <summary>
        /// 卡牌管理器单例
        /// </summary>
        public static CardManager cardManager;

        /// <summary>
        /// 当前抽到的卡牌
        /// </summary>
        internal Card thisCard;
/*
        private Stage oldStage;*/

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

        public void StageChanged(Stage _stage)
        {
            if (_stage == Stage.Junior)
            {

            }
            else if (_stage == Stage.Medium)
            {

            }
            else if (_stage == Stage.Senior)
            {

            }
        }

        /// <summary>
        /// 抽卡函数
        /// </summary>
        public void Gacha()
        {
            /*
            if (oldStage != PlayerManager.PlayerManager.playerManager.player.playerStage)
            {

            }

            oldStage = PlayerManager.PlayerManager.playerManager.player.playerStage;*/


        }

        /// <summary>
        /// 对玩家的选择做出处理
        /// </summary>
        /// <param name="_result"></param>
        public void GotResult(CardResult _result)
        {
            if (_result == CardResult.Yes)
            {
                PlayerManager.PlayerManager.playerManager.ChangePlayerState(thisCard, 0);
                GotAddition(thisCard.cardAddtion1);
            }

            else
            {
                PlayerManager.PlayerManager.playerManager.ChangePlayerState(thisCard, 1);
                GotAddition(thisCard.cardAddtion2);
            }

            PlayerManager.PlayerManager.Check();

            Gacha();
        }

        /// <summary>
        /// 对卡牌的备注进行处理
        /// </summary>
        /// <param name="_cardAddition"></param>
        public void GotAddition(string _cardAddition)
        {
            if (_cardAddition == "Phone")
            {

            }
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

