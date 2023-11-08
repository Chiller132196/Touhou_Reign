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

        /// <summary>
        /// 当前卡池
        /// </summary>
        public List<Card> NowCards = new List<Card>();

        /// <summary>
        /// 进行了多少次抽卡
        /// </summary>
        public int gachaTimes;

        private void Awake()
        {
            cardManager = this;
        }

        /// <summary>
        /// 改变游戏阶段
        /// </summary>
        /// <param name="_stage"></param>
        public void StageChanged(Stage _stage)
        {
            RefreshCards(_stage);

            gachaTimes = 0;
            Gacha();
        }

        /// <summary>
        /// 切换至下一个阶段
        /// </summary>
        public void SwitchStage() 
        {
            PlayerManager.PlayerManager.playerManager.player.playerStage += 1;
            StageChanged(PlayerManager.PlayerManager.playerManager.player.playerStage);
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        /// <param name="_stage"></param>
        public void RefreshCards(Stage _stage)
        {
            if (_stage == Stage.Junior)
            {
                Card[] temp = JuniorCards.ToArray();
                Debug.Log("Card temp:" + temp.Length);
/*                JuniorCards.ForEach(i => NowCards.Add(i));*/

                for (int i = 0; i < JuniorCards.Count; i++)
                {
                    int num = Random.Range(0, JuniorCards.Count - 1);
                    Card tCard = temp[num];
                    temp[num] = temp[i];
                    temp[i] = tCard;
                }

                NowCards = new List<Card>(temp);
            }

            else if (_stage == Stage.Medium)
            {
                Card[] temp = MediumCards.ToArray();

                for (int i = 0; i < MediumCards.Count; i++)
                {
                    int num = Random.Range(0, MediumCards.Count - 1);
                    Card tCard = temp[num];
                    temp[num] = temp[i];
                    temp[i] = tCard;
                }

                NowCards = new List<Card>(temp);
            }

            else if (_stage == Stage.Senior)
            {
                Card[] temp = SeniorCards.ToArray();
                for (int i = 0; i < SeniorCards.Count; i++)
                {
                    int num = Random.Range(0, JuniorCards.Count - 1);
                    Card tCard = temp[num];
                    temp[num] = temp[i];
                    temp[i] = tCard;
                }

                NowCards = new List<Card>(temp);
            }

            Debug.Log("已完成洗牌，现在牌堆大小为" + NowCards.Count);
        }

        /// <summary>
        /// 抽卡函数
        /// </summary>
        public void Gacha()
        {
            if (gachaTimes == NowCards.Count)
            {
                SwitchStage();
            }

            thisCard = NowCards[gachaTimes];
            gachaTimes++;

            Debug.Log("抽到了" + thisCard.cardTitle);

            UI_Manager.UIManager.uiManager.SetShowedCard(thisCard);

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

            PlayerManager.PlayerManager.playerManager.Check();

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

            gachaTimes = 0;
            StageChanged(PlayerManager.PlayerManager.playerManager.player.playerStage);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

