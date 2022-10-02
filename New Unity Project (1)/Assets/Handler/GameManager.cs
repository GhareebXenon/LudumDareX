using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HpSys;

namespace Handler
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager { get; private set; }
        public Health healthSystem = new Health(100, 100);
        void Awake()
        {
            if (gameManager != null && gameManager != this)
                Destroy(this);
            else
                gameManager = this;
        }

        void Update()
        {

        }
    }

}
