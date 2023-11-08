using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardManager;

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
        /// 交换上下两张卡牌的层次关系
        /// </summary>
        public void SwitchCard()
        {
            topCard.SetActive(false);
            bottomCard.SetActive(true);

            GameObject temp = topCard.gameObject;
            topCard = bottomCard;
            bottomCard = temp;
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
