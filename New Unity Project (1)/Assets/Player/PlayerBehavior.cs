using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Handler;

namespace Player.Behavior
{
    public class PlayerBehavior : MonoBehaviour
    {
        public static PlayerBehavior playerBehavior { get; private set; }
        int dmgCount;

        void Awake()
        {

        }

        void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Enemy")
            {
                if (dmgCount >= 4)
                {
                    Destroy(this.gameObject);
                }
                dmgCount += 1;
            }
        }
    }
}
