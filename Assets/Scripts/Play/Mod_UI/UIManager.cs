using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardManager;
using TMPro;

namespace UI_Manager
{
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// UI管理器单例
        /// </summary>
        public static UIManager uiManager;

        /// <summary>
        /// 选项卡
        /// </summary>
        public GameObject showedCard;

        /// <summary>
        /// 结果卡
        /// </summary>
        public GameObject resultCard;

        /// <summary>
        /// 当前顶部的卡牌
        /// </summary>
        public GameObject topCard;

        /// <summary>
        /// 当前底部的卡牌
        /// </summary>
        public GameObject bottomCard;

        /// <summary>
        /// 左上角的生存天数
        /// </summary>
        public GameObject timer;

        /// <summary>
        /// 正在播放退出动画演出的卡牌
        /// </summary>
        public GameObject dropCard;

        public TMP_Text healthNum;
        public TMP_Text mentalNum;
        public TMP_Text popuNum;
        public TMP_Text wealthNum;

        public GameObject healthImage;
        public GameObject mentalImage;
        public GameObject popuImage;
        public GameObject wealthImage;

        /// <summary>
        /// 设置牌面
        /// </summary>
        /// <param name="_card"></param>
        public void SetShowedCard(Card _card)
        {
            showedCard.GetComponent<ShowedCard>().ChangeCardFace(_card);
        }

        public void SetResultCard(Card _card)
        {
            resultCard.GetComponent<ResultCard>().ChangeCardFace(_card);
        }

        /// <summary>
        /// 自定义卡牌牌面
        /// </summary>
        public void DIYResultCard(string _title, string _info)
        {
            Card tCard = new Card();
            tCard.cardTitle = _title;
            tCard.cardInfo = _info;

            resultCard.GetComponent<ResultCard>().ChangeCardFace(tCard);
        }

        /// <summary>
        /// 自定义卡牌牌面
        /// </summary>
        public void DIYResultCard(string _title, string _result1, string _result2)
        {
            Card tCard = new Card();
            tCard.cardTitle = _title;
            tCard.cardResult1 = _result1;
            tCard.cardResult2 = _result2;

            resultCard.GetComponent<ResultCard>().ChangeCardFace(tCard);
        }

        public void RefreshResultCard()
        {
            resultCard.GetComponent<ResultCard>().RefreshCardFace();
        }

        /// <summary>
        /// 交换上下两张卡牌的层次关系
        /// </summary>
        public void SwitchCard()
        {
            bottomCard.GetComponent<CardObject>().isDropable = false;
            bottomCard.transform.position = new Vector2(640.0f, 360.0f);
            topCard.GetComponent<CardObject>().isDropable = true;

//            topCard.SetActive(false);
//            bottomCard.SetActive(true);

            GameObject temp = topCard.gameObject;
            topCard = bottomCard;
            bottomCard = temp;
        }

        /// <summary>
        /// 改变四项数值
        /// </summary>
        public void RefreshCount()
        {
            // Debug.Log("改变数字");
            //healthNum.text = PlayerManager.PlayerManager.playerManager.player.playerHealth.ToString();
            //mentalNum.text = PlayerManager.PlayerManager.playerManager.player.playerMental.ToString();
            //popuNum.text = PlayerManager.PlayerManager.playerManager.player.playerPopu.ToString();
            //wealthNum.text = PlayerManager.PlayerManager.playerManager.player.playerWealth.ToString();

            healthImage.GetComponent<IconObject>().nowNum = PlayerManager.PlayerManager.playerManager.player.playerHealth;
            mentalImage.GetComponent<IconObject>().nowNum = PlayerManager.PlayerManager.playerManager.player.playerMental;
            popuImage.GetComponent<IconObject>().nowNum = PlayerManager.PlayerManager.playerManager.player.playerPopu;
            wealthImage.GetComponent<IconObject>().nowNum = PlayerManager.PlayerManager.playerManager.player.playerWealth;
        }

        /// <summary>
        /// 将最上方的卡牌放至底部
        /// </summary>
        public void TakeDownCard()
        {
            topCard.SetActive(false);

            GameObject temp = new GameObject();


        }

        /// <summary>
        /// 将最下方的卡牌放至顶部
        /// </summary>
        public void PutOnCard()
        {
            bottomCard.SetActive(true);
        }

        /// <summary>
        /// 刷新计时器
        /// </summary>
        public void RefreshTimer()
        {
            timer.GetComponent<TimeAdmin>().RefreshTime();
        }

        /// <summary>
        /// 修改计时器
        /// </summary>
        /// <param name="_time"></param>
        public void SetTimer(int _time)
        {
            timer.GetComponent<TimeAdmin>().SetTime(_time);
        }

        public void RefreshCardPosition(GameObject _cardObject)
        {
            _cardObject.transform.position = new Vector2(640f, 360f);
        }

        public void Restart()
        {
            topCard = showedCard;
            bottomCard = resultCard;

            RefreshCardPosition(showedCard);
            RefreshCardPosition(resultCard);
            // showedCard.transform.position = new Vector2(640f, 360f);
            // resultCard.transform.position = new Vector2(640f, 360f);

            topCard.GetComponent<CardObject>().isDropable = false;
            bottomCard.GetComponent<CardObject>().isDropable = false;
        }

        private void Awake()
        {
            uiManager = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
