using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Handler;

namespace Player.Behavior
{
    public class PlayerBehavior : MonoBehaviour
    {
        public static PlayerBehavior playerBehavior { get; private set; }
        public int damageToHealth;

        void Awake()
        {

        }

        void Update()
        {
            CheckHealth();
        }

        public void PlayerTakeDamage(int dmg)
        {
            GameManager.gameManager.playerHealth.HpDmg(dmg);
        }

        void CheckHealth()
        {
            if (GameManager.gameManager.playerHealth.CurrHp == 0)
                Destroy(this.gameObject);
        }
    }
}
