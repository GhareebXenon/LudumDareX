using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Handler;

namespace Enemy.Behavior
{
    public class Behavior : MonoBehaviour
    {
        public static Behavior enemyBehavior { get; private set; }
        [SerializeField]
        Transform target;
        [SerializeField]
        float SightRange;
        [SerializeField]
        float speed;
        float distance;
        public int damageToHealth;
        void Start()
        {

        }

        void Update()
        {
            FollowTarget();
            DestroyOnContact();
            CheckHealth();
        }

        public void EnemyTakeDamage(int dmg)
        {
            GameManager.gameManager.enemyHealth.HpDmg(dmg);
        }

        void FollowTarget()
        {
            distance = Vector2.Distance(this.gameObject.transform.position, target.position);
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (distance < SightRange)
            {
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
            }
        }

        void DestroyOnContact()
        {
            if (this.transform.position.x == target.position.x && this.transform.position.y == target.position.y)
                Destroy(this.gameObject);
        }

        void DamagePlayer(int dmg)
        {
            GameManager.gameManager.playerHealth.HpDmg(dmg);
        }

        void CheckHealth()
        {
            if (GameManager.gameManager.enemyHealth.CurrHp == 0)
                Destroy(this.gameObject);
        }
    }

}
