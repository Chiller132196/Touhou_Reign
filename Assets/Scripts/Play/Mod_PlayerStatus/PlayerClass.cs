using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerManager
{
    /// <summary>
    /// 游戏阶段
    /// </summary>
    public enum Stage
    {
        Junior,
        Medium,
        Senior
    }

    /// <summary>
    /// 存放信息的玩家类
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 玩家所处阶段
        /// </summary>
        public Stage playerStage { get; set; }
        
        /// <summary>
        /// 心情
        /// </summary>
        internal int mental;
        /// <summary>
        /// 健康
        /// </summary>
        internal int health;
        /// <summary>
        /// 人气
        /// </summary>
        internal int popu;
        /// <summary>
        /// 财富
        /// </summary>
        internal int wealth;
        /// <summary>
        /// 生存天数
        /// </summary>
        internal int surviveDays;

        /// <summary>
        /// 玩家心情
        /// </summary>
        public int playerMental
        {
            get => mental;
            set { mental = value; }
        }

        /// <summary>
        /// 玩家健康
        /// </summary>
        public int playerHealth
        {
            get => health;
            set { health = value; }
        }

        /// <summary>
        /// 玩家人气
        /// </summary>
        public int playerPopu
        {
            get => popu;
            set { popu = value; }
        }

        /// <summary>
        /// 玩家财富
        /// </summary>
        public int playerWealth
        {
            get => wealth;
            set { wealth = value; }
        }

        /// <summary>
        /// 玩家生存天数
        /// </summary>
        public int playerSD
        {
            get => surviveDays;
            set { surviveDays = value; }
        }
    }
}