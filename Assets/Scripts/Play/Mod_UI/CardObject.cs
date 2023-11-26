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

        public float timer = 0;

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
            if (timer < 2.5f)
            {
                Debug.Log("尝试牵引卡牌");
                timer += Time.deltaTime;
                transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, transform.position.y - 2000, 3.5f));
            }
            else
            {
                ;
            }
        }

        void Start()
        {

        }

        void Update()
        {
            if (isDropable)
            {
                DropCard();
            }
            else if (timer != 0)
            {
                timer = 0;
            }
        }
    }
}
