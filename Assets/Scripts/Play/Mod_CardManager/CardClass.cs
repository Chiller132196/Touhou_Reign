using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardManager
{
    /// <summary>
    /// 卡牌的阶段
    /// </summary>
    public enum CardStage
    {
        Junior,
        Medium,
        Senior
    }

    /// <summary>
    /// 卡牌带来的特殊效果
    /// </summary>
    public enum CardAddition
    {
        Phone,
        End9961
    }

    /// <summary>
    /// 卡牌的结果
    /// </summary>
    public enum CardResult
    {
        Yes,
        No
    }

    /// <summary>
    /// 卡牌类，存放卡牌基本信息
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 卡牌的ID
        /// </summary>
        internal int cardID;
        /// <summary>
        /// 卡牌出现阶段
        /// </summary>
        internal CardStage cardStage;
        /// <summary>
        /// 卡牌的标题
        /// </summary>
        internal string cardTitle;
        /// <summary>
        /// 卡牌的描述
        /// </summary>
        internal string cardInfo;
        /// <summary>
        /// 牌面的地址
        /// </summary>
        public string cardFaceURL;

        /// <summary>
        /// 卡牌结果1文案
        /// </summary>
        internal string cardResult1;
        /// <summary>
        /// 卡牌结果2文案
        /// </summary>
        internal string cardResult2;

        /// <summary>
        /// 卡片会导致的全局影响索引
        /// </summary>
        public string cardAddtion1;
        /// <summary>
        /// 卡片会导致的全局影响索引
        /// </summary>
        public string cardAddtion2;

        internal int[] healthEffect = new int[2];
        internal int[] mentalEffect = new int[2];
        internal int[] wealthEffect = new int[2];
        internal int[] popuEffect = new int[2];

        /// <summary>
        /// 卡牌ID
        /// </summary>
        public int cardShowedID
        {
            get => cardID;
        }

        /// <summary>
        /// 卡牌阶段
        /// </summary>
        public CardStage cardShowedStage
        {
            get => cardStage;
        }

        /// <summary>
        /// 卡牌标题
        /// </summary>
        public string cardShowedTitle
        {
            get => cardTitle;
        }

        /// <summary>
        /// 卡牌文本
        /// </summary>
        public string cardShowedInfo
        {
            get => cardInfo;
        }

        /// <summary>
        /// 卡牌结局1
        /// </summary>
        public string cardShowedResult1
        {
            get => cardResult1;
        }

        /// <summary>
        /// 卡牌结局2
        /// </summary>
        public string cardShowedResult2
        {
            get => cardResult2;
        }

        /// <summary>
        /// 卡牌对健康的影响
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int cardHealthEffect(int index)
        {
            int result = 0;

            switch (index)
            {
                case 0: result = healthEffect[0]; break;
                case 1: result = healthEffect[1]; break;
                default: Debug.LogWarning("无效的索引"); break;
            }

            return result;
        }

        /// <summary>
        /// 卡牌对心理的影响
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int cardMentalEffect(int index)
        {
            int result = 0;

            switch (index)
            {
                case 0: result = mentalEffect[0]; break;
                case 1: result = mentalEffect[1]; break;
                default: Debug.LogWarning("无效的索引"); break;
            }

            return result;
        }

        /// <summary>
        /// 卡牌对财富的影响
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int cardWealthEffect(int index)
        {
            int result = 0;

            switch (index)
            {
                case 0: result = wealthEffect[0]; break;
                case 1: result = wealthEffect[1]; break;
                default: Debug.LogWarning("无效的索引"); break;
            }

            return result;
        }

        /// <summary>
        /// 卡牌对人气的影响
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int cardPopuEffect(int index)
        {
            int result = 0;

            switch (index)
            {
                case 0: result = popuEffect[0]; break;
                case 1: result = popuEffect[1]; break;
                default: Debug.LogWarning("无效的索引"); break;
            }

            return result;
        }
    }
}
