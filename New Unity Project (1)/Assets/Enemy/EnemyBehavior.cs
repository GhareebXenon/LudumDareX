using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Handler;
using Player.Behavior;

namespace Enemy.Behavior
{
    public class EnemyBehavior : MonoBehaviour
    {
        [SerializeField]
        GameObject[] EnemyEntity;
        public static EnemyBehavior enemyBehavior { get; private set; }
        [SerializeField]
        Transform target;
        [SerializeField]
        float SightRange;
        [SerializeField]
        float speed;
        float distance;
        int enemyCount;
        [SerializeField]
        int maxEnemyNum;
        [SerializeField]
        Transform[] spawnPoint;
        public int damageToHealth;
        void Start()
        {
            StartCoroutine(EnemySpawn());
        }

        void Update()
        {
            FollowTarget();
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

        void CheckHealth()
        {
            if (GameManager.gameManager.enemyHealth.CurrHp == 0)
                Destroy(this.gameObject);
        }

        IEnumerator EnemySpawn()
        {
            while (enemyCount < maxEnemyNum)
            {
                Instantiate(EnemyEntity[Random.Range(0,1)], new Vector3(spawnPoint[Random.Range(0, 5)].position.x, spawnPoint[Random.Range(0, 5)].position.y, spawnPoint[Random.Range(0, 5)].position.z), Quaternion.identity);
                yield return new WaitForSeconds(500f);
                enemyCount += 1;
            }
            yield return new WaitForSeconds(10f);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Player")
            {
                PlayerBehavior.playerBehavior.PlayerTakeDamage(damageToHealth);
                Destroy(this.gameObject);
            }
        }
    }

}
