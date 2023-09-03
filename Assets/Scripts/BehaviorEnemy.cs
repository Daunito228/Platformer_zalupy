using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;

public class BehaviorEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy;
    public float speed = 3f;
    private float rotation = 1;
    public static float speedMultiplier = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
        speed *= -1;
        rotation *= -1;
        }
    }
    private void FixedUpdate()
    {
        enemy.transform.localScale = new Vector2(rotation, 1);
        rb.velocity = new Vector2(-speed * speedMultiplier, rb.velocity.y);
    }
}
