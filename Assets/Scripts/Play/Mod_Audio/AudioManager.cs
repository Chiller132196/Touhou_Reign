using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager audioManager;

        private void Awake()
        {
            audioManager = this;
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