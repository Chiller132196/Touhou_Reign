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
            player.playerStage = Stage.Junior;
            player.playerSD = 0;

            player.mental = 25;
            player.health = 25;
            player.popu = 25;
            player.wealth = 25;

            Debug.Log("已加载玩家数据");
        }

        /// <summary>
        /// 带有启动参数的重载初始化函数
        /// </summary>
        /// <param name="tIndex"></param>
        private void LoadPlayer(int tIndex)
        {
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

        public void ChangePlayerState(CardManager.Card tCard, int tIndex)
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

        public void ChangePlayerStage()
        {

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

        }

        private void Awake()
        {
            playerManager = this;
            LoadPlayer();
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
