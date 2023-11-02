using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardManager
{
    public enum CardStage
    {
        Junior,
        Medium,
        Senior
    }

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
                case 0: result = healthEffect[0];break;
                case 1: result = healthEffect[1];break;
                default: Debug.LogWarning("无效的索引");break;
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
                case 0: result = mentalEffect[0];break;
                case 1: result = mentalEffect[1];break;
                default: Debug.LogWarning("无效的索引");break;
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

    public class CardLoader : MonoBehaviour
    {
        string cardURL;
        public TextAsset cardInfos;

        /// <summary>
        /// 从CSV中获取卡牌信息
        /// </summary>
        public void LoadCard()
        {
            // Debug.Log("正在从" + cardURL + "获取卡牌信息");
            cardInfos = Resources.Load<TextAsset>("Data/CardInfos");
            string[] gotText = cardInfos.text.Split('\n');

            //切割获取的字符串组
            foreach( var row in gotText ) {

                //排除空行带来的影响
                if (row == "")
                {
                    continue;
                }

                string[] rows = row.ToString().Split(',');
                Debug.Log(rows[1]);

                string[] otherChara = { "#", "\n", " ", "" };

                if ( ((IList)otherChara).Contains(rows[0]) )
                {
                    Debug.Log("无效行" + Time.deltaTime + "自动忽略");
                    continue;
                }
                else
                {
                    Card thisCard = new Card();

                    thisCard.cardID = int.Parse(rows[0]);

                    if (rows[1] == "Junior")
                    {
                        thisCard.cardStage = CardStage.Junior;
                        GetComponent<CardManager>().JuniorCards.Add(thisCard);
                    }
                    else if (rows[1] == "Medium")
                    {
                        thisCard.cardStage = CardStage.Medium;
                        GetComponent<CardManager>().MediumCards.Add(thisCard);
                    }
                    else if (rows[1] == "Senior")
                    {
                        thisCard.cardStage = CardStage.Senior;
                        GetComponent<CardManager>().SeniorCards.Add(thisCard);
                    }
                    else
                    {
                        Debug.LogWarning("未能解析的卡牌阶段！");
                    }

                    thisCard.cardTitle = rows[2];
                    thisCard.cardInfo = rows[3];

                    thisCard.popuEffect[0] = int.Parse(rows[4]);
                    thisCard.popuEffect[1] = int.Parse(rows[5]);

                    thisCard.healthEffect[0] = int.Parse(rows[5]);
                    thisCard.healthEffect[1] = int.Parse(rows[9]);

                    thisCard.mentalEffect[0] = int.Parse(rows[6]);
                    thisCard.mentalEffect[1] = int.Parse(rows[10]);

                    thisCard.wealthEffect[0] = int.Parse(rows[7]);
                    thisCard.wealthEffect[1] = int.Parse(rows[11]);

                    thisCard.cardFaceURL = rows[12];
                    thisCard.cardResult1 = rows[13];
                    thisCard.cardResult2 = rows[14];
                    thisCard.cardAddtion1 = rows[15];
                    thisCard.cardAddtion2 = rows[16];
                }

            }
        }

        private void Awake()
        {
             cardURL = Application.dataPath + "/Data/CardInfos.csv";
        }

    }

}
