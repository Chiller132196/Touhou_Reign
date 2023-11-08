using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardManager;

public class SelectButton : MonoBehaviour
{
    CardManager.CardManager localCardManager = CardManager.CardManager.cardManager;

    /// <summary>
    /// 确定按钮触发事件
    /// </summary>
    public void ConfirmBtn()
    {
        CardManager.CardManager.cardManager.GotResult(CardResult.Yes);
    }

    /// <summary>
    /// 否定按钮触发事件
    /// </summary>
    public void RejectBtn()
    {
        CardManager.CardManager.cardManager.GotResult(CardResult.No);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
