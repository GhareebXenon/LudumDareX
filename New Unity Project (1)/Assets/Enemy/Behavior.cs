using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Handler;

namespace Enemy.Behavior
{
    public class Behavior : MonoBehaviour
    {
        [SerializeField]
        Transform target;
        [SerializeField]
        float SightRange;
        [SerializeField]
        float speed;
        float distance;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            FollowTarget();
        }

        void EnemyTakeDamage(int dmg)
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

    }

}
