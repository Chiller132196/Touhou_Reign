using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAdmin : MonoBehaviour
{
    public TMP_Text timer;

    public void SetTime(int _time)
    {
        timer.text = "第 " + _time + " 天";
    }

    public void RefreshTime()
    {
        int time = PlayerManager.PlayerManager.playerManager.player.playerSD;
        timer.text = "第 " + time  + " 天";
    }
}
