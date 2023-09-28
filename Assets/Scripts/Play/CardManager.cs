using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayCard
{
    public class CardManager : MonoBehaviour
    {
        public TextAsset cardInfos;
        private string readInfos;

        private void Awake()
        {
            readInfos = Resources.Load<TextAsset>(Application.streamingAssetsPath + "Data/CardInfos.csv").text;
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
}

