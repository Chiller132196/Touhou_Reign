using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerManager
{
    public class PlayerManager : MonoBehaviour
    {
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
