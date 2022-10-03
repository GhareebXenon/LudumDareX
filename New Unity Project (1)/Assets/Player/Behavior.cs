using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Handler;

namespace Player.Behavior
{
    public class Behavior : MonoBehaviour
    {
        public static Behavior playerBehavior { get; private set; }
        [SerializeField]
        int damageToHealth;

        void Awake()
        {

        }

        void Update()
        {
            CheckHealth();
        }

        void DamageEnemy(int dmg)
        {
            GameManager.gameManager.enemyHealth.HpDmg(dmg);
        }
        void CheckHealth()
        {
            if (GameManager.gameManager.playerHealth.CurrHp == 0)
                Destroy(this.gameObject);
        }
    }
}
