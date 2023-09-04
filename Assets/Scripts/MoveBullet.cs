using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Rigidbody2D RbBulletPrefab;
    private float direction;
    private void Start()
    {
        direction = MovePlayer.direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        RbBulletPrefab.velocity = new Vector2(PlayerShot.staticSpeed * direction, RbBulletPrefab.velocity.y);
    }
}
