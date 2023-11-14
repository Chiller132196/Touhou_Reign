using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI_Manager
{
    public class ResultCard : CardObject
    {
        /// <summary>
        /// 结果牌标题
        /// </summary>
        public TMP_Text cardTitle;

        /// <summary>
        /// 结果牌内容
        /// </summary>
        public TMP_Text cardInfo;

        private CardManager.Card nowCard;

        public void ChangeCardFace(CardManager.Card _card)
        {
            nowCard = _card;

            cardTitle.text = _card.cardShowedTitle;
            if (PlayerManager.PlayerManager.playerManager.player.playerAction == PlayerManager.PlayerAction.ReadConfirmResult)
            {
                Debug.Log("结果1");
                cardInfo.text = _card.cardShowedResult1;
            }
            else
            {
                Debug.Log("结果2");
                cardInfo.text = _card.cardShowedResult2;
            }
        }

        public void RefreshCardFace()
        {
            if (PlayerManager.PlayerManager.playerManager.player.playerAction == PlayerManager.PlayerAction.ReadConfirmResult)
            {
                Debug.Log("结果1");
                cardInfo.text = nowCard.cardShowedResult1;
            }
            else
            {
                Debug.Log("结果2");
                cardInfo.text = nowCard.cardShowedResult2;
            }
        }
    }
} 
