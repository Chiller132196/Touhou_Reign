using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardManager;

namespace UI_Manager
{
    public class SelectButton : MonoBehaviour
    {
        CardManager.CardManager localCardManager = CardManager.CardManager.cardManager;

        /// <summary>
        /// 通过玩家状态决定下一步
        /// </summary>
        /// <returns></returns>
        public bool PlayerStateConfirm()
        {
            if (PlayerManager.PlayerManager.playerManager.player.playerAction == PlayerManager.PlayerAction.Choice || PlayerManager.PlayerManager.playerManager.player.playerAction == PlayerManager.PlayerAction.Awake)
            {
                Debug.Log("已做出选择");
                return true;
            }
            else if (PlayerManager.PlayerManager.playerManager.player.playerAction == PlayerManager.PlayerAction.ReadRejectResult)
            {
                Debug.Log("阅读文本完毕");
                PlayerManager.PlayerManager.playerManager.Check();
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 确定按钮触发事件
        /// </summary>
        public void ConfirmBtn()
        {
            if (PlayerStateConfirm())   //检测到玩家在做选择状态时，回应玩家选择
            {
                CardManager.CardManager.cardManager.GotResult(CardResult.Yes);

                PlayerManager.PlayerManager.playerManager.player.playerAction = PlayerManager.PlayerAction.ReadConfirmResult;
                /*
                            UI_Manager.UIManager.uiManager.RefreshTimer();*/
                UI_Manager.UIManager.uiManager.RefreshResultCard();
                UI_Manager.UIManager.uiManager.SwitchCard();
            }
            else   //玩家处于阅读结果文本状态，关闭结果文本，抽取下一张卡牌
            {
                PlayerManager.PlayerManager.playerManager.player.playerAction = PlayerManager.PlayerAction.Choice;

                CardManager.CardManager.cardManager.Gacha();
                /*
                            UI_Manager.UIManager.uiManager.RefreshTimer();*/
                UI_Manager.UIManager.uiManager.SwitchCard();
            }
        }

        /// <summary>
        /// 否定按钮触发事件
        /// </summary>
        public void RejectBtn()
        {
            if (PlayerStateConfirm())
            {
                CardManager.CardManager.cardManager.GotResult(CardResult.No);

                PlayerManager.PlayerManager.playerManager.player.playerAction = PlayerManager.PlayerAction.ReadRejectResult;
                /*
                            UI_Manager.UIManager.uiManager.RefreshTimer();*/
                UI_Manager.UIManager.uiManager.RefreshResultCard();
                UI_Manager.UIManager.uiManager.SwitchCard();
            }
            else
            {
                PlayerManager.PlayerManager.playerManager.player.playerAction = PlayerManager.PlayerAction.Choice;

                CardManager.CardManager.cardManager.Gacha();
                /*
                            UI_Manager.UIManager.uiManager.RefreshTimer();*/
                UI_Manager.UIManager.uiManager.SwitchCard();
            }
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