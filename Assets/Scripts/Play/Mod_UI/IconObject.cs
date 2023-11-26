using System.Collections;
using System.Collections.Generic;
using PlayerManager;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Manager
{
    public class IconObject : MonoBehaviour
    {
        Player testPlayer = new Player();
        /// <summary>
        /// 最大数字
        /// </summary>
        public int maxNum;

        /// <summary>
        /// 更新后的数字
        /// </summary>
        public int nowNum = 0;

        public float tempNum = 0;

        private Image image;

        /// <summary>
        /// 对icon 进行卷帘动画
        /// </summary>
        public void ScrollIcon()
        {
            if (tempNum > nowNum + 1)
            {
                tempNum -= Time.deltaTime + 0.2f;
            }
            else if (tempNum < nowNum - 1)
            {
                tempNum += Time.deltaTime + 0.2f;
            }
            else
            {
                tempNum = nowNum;
            }
            image.fillAmount = (float)tempNum / (float)maxNum;
        }

        void Start()
        {
            maxNum = testPlayer.playerMaxHealth;
            image = GetComponent<Image>();
        }

        void Update()
        {
            ScrollIcon();
        }
    }
}
