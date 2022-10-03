using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Behavior;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Destroy(gameObject, 3f);

    }

   
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.name == "Enemies")
            Behavior.enemyBehavior.EnemyTakeDamage(Behavior.enemyBehavior.damageToHealth);
    }
}
