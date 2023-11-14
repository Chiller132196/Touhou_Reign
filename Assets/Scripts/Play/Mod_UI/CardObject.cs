using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI_Manager
{
    /// <summary>
    /// 封装卡牌物件共同属性、方法的类
    /// </summary>
    public class CardObject : MonoBehaviour
    {
        public bool isDrop;

        public bool isDropable
        {
            get => isDrop;
            set
            {
                isDrop = value;
                if (isDrop)
                {
                    Debug.Log("准备下落");
                }
            }
        }

        /// <summary>
        /// 控制卡牌，使其下坠
        /// </summary>
        public void DropCard()
        {
            transform.position = new Vector2(960.0f, Mathf.MoveTowards(transform.position.y, transform.position.y - 1000, 1.5f));
        }

        void Start()
        {

        }

        void Update()
        {
            if (isDropable)
            {
                Debug.Log("尝试牵引卡牌");
                DropCard();
            }
        }
    }
}
