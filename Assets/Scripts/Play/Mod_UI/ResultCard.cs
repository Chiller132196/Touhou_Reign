using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultCard : MonoBehaviour
{
    /// <summary>
    /// 结果牌标题
    /// </summary>
    public TMP_Text cardTitle;

    /// <summary>
    /// 结果牌内容
    /// </summary>
    public TMP_Text cardInfo;

    public void ChangeCardFace(CardManager.Card _card)
    {
        cardTitle.text = _card.cardShowedTitle;
        if (PlayerManager.PlayerManager.playerManager.player.playerAction == PlayerManager.PlayerAction.ReadConfirmResult)
        {
            cardInfo.text = _card.cardShowedResult1;
        }
        else
        {
            cardInfo.text = _card.cardShowedResult2;
        }
    }
}
