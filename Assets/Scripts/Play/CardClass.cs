using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayCard
{
    /// <summary>
    /// 卡牌类，便于后续从Json 中读取卡牌信息
    /// </summary>
    public class Card {
        //卡牌存放的信息
        public string stage;
        public string title;
        public string content;

        int Fame1;
        int Fame2;

        int Mental1;
        int Mental2;

        int Wealth1;
        int Wealth2;

        int Health1;
        int Health2;

        public string imagePath;
        public string resultTxt1;
        public string resultTxt2;
    }
}