using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardManager;

namespace PlayerManager
{
    public class PlayerManager : MonoBehaviour
    {
        /// <summary>
        /// 玩家管理单例
        /// </summary>
        public static PlayerManager playerManager;

        public Player player = new Player();

        /// <summary>
        /// 初始化玩家数据
        /// </summary>
        private void LoadPlayer()
        {
            player.canGoNextStage = false;

            // Debug.Log("加载玩家中");
            player.playerAction = PlayerAction.Awake;
            player.playerStage = Stage.Junior;
            player.playerSD = 0;

            player.mental = 25;
            player.health = 25;
            player.popu = 25;
            player.wealth = 25;

            // Debug.Log("已加载玩家数据");
        }

        /// <summary>
        /// 带有启动参数的重载初始化函数
        /// </summary>
        /// <param name="tIndex"></param>
        private void LoadPlayer(int tIndex)
        {
            player.canGoNextStage = false;

            player.playerStage = Stage.Junior;
            player.playerSD = 0;

            player.mental = 25;
            player.health = 25;
            player.popu = 25;
            player.wealth = 25;

            switch (tIndex)
            {
                case 0:break;
            }
        }

        public void ChangePlayerState(Card tCard, int tIndex)
        {
            if (tIndex > 1 || tIndex < 0) {
                Debug.Log("输入索引无效");
                return;
            }

            player.health += tCard.cardHealthEffect(tIndex);
            player.mental += tCard.cardMentalEffect(tIndex);
            player.popu += tCard.cardPopuEffect(tIndex);
            player.wealth += tCard.cardWealthEffect(tIndex);

            Debug.Log("玩家属性: " + "Health:" + player.health + " Mental:" + player.mental + " Popu:" + player.popu + " Wealth:" + player.wealth);
        }

        public void ChangePlayerStage(Stage _stage)
        {
            player.playerStage = _stage;
        }

        public void GoNextPlayerStage()
        {
            player.playerStage += 1;
        }

        /// <summary>
        /// 检测玩家数据是否到达结局阈值
        /// </summary>
        public void Check()
        {
            //属性溢出时
            if (player.playerHealth >= 50)
            {
                GameEnd(EndType.Strenth);
            }
            else if (player.playerMental >= 50)
            {
                GameEnd(EndType.Glad);
            }
            else if (player.playerPopu >= 50)
            {
                GameEnd(EndType.Fame);
            }
            else if (player.playerWealth >= 50)
            {
                GameEnd(EndType.Rich);
            }

            //属性跌至0时
            else if (player.playerHealth <= 0)
            {
                GameEnd(EndType.Weakness);
            }
            else if (player.playerMental <= 0)
            {
                GameEnd(EndType.Sadness);
            }
            else if (player.playerPopu <= 0) {
                GameEnd(EndType.Disappear);
            }
            else if (player.playerWealth <= 0)
            {
                GameEnd(EndType.Poor);
            }
            

        }

        /// <summary>
        /// 游戏结束
        /// </summary>
        /// <param name="_endType"></param>
        public void GameEnd(EndType _endType)
        {
            player.playerAction = PlayerAction.End;
            Debug.Log("游戏结束");
        }

        private void Awake()
        {
            playerManager = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            LoadPlayer();
            UI_Manager.UIManager.uiManager.RefreshCount();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
