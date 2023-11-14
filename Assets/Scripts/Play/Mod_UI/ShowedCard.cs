using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI_Manager
{
    public class ShowedCard : CardObject
    {
        /// <summary>
        /// 卡牌物件标题
        /// </summary>
        public TMP_Text cardTitleText;

        /// <summary>
        /// 卡牌物件内容
        /// </summary>
        public TMP_Text cardInfoText;

        public void ChangeCardFace(CardManager.Card _card)
        {
            cardTitleText.text = _card.cardShowedTitle;
            cardInfoText.text = _card.cardShowedInfo;
        }

    }
}
