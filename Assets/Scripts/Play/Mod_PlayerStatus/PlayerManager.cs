using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerManager
{
    public class PlayerManager : MonoBehaviour
    {
        /// <summary>
        /// 玩家管理单例
        /// </summary>
        public static PlayerManager playerManager;

        public Player player;

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
            player.health += tCard.cardHealthEffect(tIndex);
            player.mental += tCard.cardMentalEffect(tIndex);
            player.popu += tCard.cardPopuEffect(tIndex);
            player.wealth += tCard.cardWealthEffect(tIndex);
        }

        public void ChangePlayerStage()
        {

        }

        /// <summary>
        /// 检测玩家数据是否到达结局阈值
        /// </summary>
        public void Check()
        {
            if (player.playerHealth > 25)
            {
                ;
            }
        }

        private void Awake()
        {
            playerManager = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            LoadPlayer();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
