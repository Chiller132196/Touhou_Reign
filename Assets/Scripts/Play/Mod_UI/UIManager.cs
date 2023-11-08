using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /// 设置牌面
        /// </summary>
        /// <param name="_card"></param>
        public void SetShowedCard(CardManager.Card _card)
        {
            showedCard.GetComponent<ShowedCard>().ChangeCardFace(_card);
        }

        public void TakeDownCard()
        {

        }

        public void PutOnCard()
        {

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
