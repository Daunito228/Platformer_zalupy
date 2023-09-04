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
    bool isSeePlayer = false;
    Vector2 trfrm;

    void turnEnemy(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            speed *= -1;
            rotation *= -1;
        }
    }

    Vector2 DirectionDtrm(float speed)
    {
        if (speed > 0)
        {
            trfrm = -transform.right;
        }
        else
        {
            trfrm = transform.right;
        }
        return trfrm;
    }

    void calmBehavior()
    {
        enemy.transform.localScale = new Vector2(rotation, 1);
        rb.velocity = new Vector2(-speed * speedMultiplier, rb.velocity.y);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSeePlayer)
        {
            turnEnemy(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ray2D ray = new Ray2D(transform.position, transform.forward);
            trfrm = DirectionDtrm(speed);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, trfrm);
            if (hit.transform.name == "Player Cube")
            {
                Debug.Log(hit.transform.name);
                isSeePlayer = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Не видит");
        isSeePlayer = false;
    }

    private void FixedUpdate()
    {
        if (!isSeePlayer)
        {
            calmBehavior();
        }
        else
        {
            //тут надо дописать приследование игрока. Я заебался
            Debug.Log("Заметил");
            trfrm = DirectionDtrm(speed);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, trfrm);


        }
    }
}
