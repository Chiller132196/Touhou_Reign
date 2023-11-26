using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardManager
{

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
                // Debug.Log(row);

                string[] rows = row.ToString().Split(',');

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
                        continue;
                    }

                    thisCard.cardTitle = rows[2];
                    thisCard.cardInfo = rows[3];

                    thisCard.popuEffect[0] = int.Parse(rows[4]);
                    thisCard.popuEffect[1] = int.Parse(rows[8]);

                    thisCard.mentalEffect[0] = int.Parse(rows[5]);
                    thisCard.mentalEffect[1] = int.Parse(rows[9]);

                    thisCard.healthEffect[0] = int.Parse(rows[6]);
                    thisCard.healthEffect[1] = int.Parse(rows[10]);

                    thisCard.wealthEffect[0] = int.Parse(rows[7]);
                    thisCard.wealthEffect[1] = int.Parse(rows[11]);

                    thisCard.cardFaceURL = rows[12];
                    thisCard.cardResult1 = rows[13];
                    thisCard.cardResult2 = rows[14];
                    thisCard.cardAddtion1 = rows[15];
                    thisCard.cardAddtion2 = rows[16];

                    // Debug.Log("CardLoader: 添加 " + thisCard.cardShowedTitle + " 卡牌至" + rows[1]);
                }
            }
            // Debug.Log("Junior:" + GetComponent<CardManager>().JuniorCards.Count);
        }

        private void Awake()
        {
             cardURL = Application.dataPath + "/Resources/Data/CardInfos.csv";
        }

    }

}
