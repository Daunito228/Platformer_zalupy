using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BehaviorEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy;
    public float speed = 3f;
    private float rotation = 1;
    public static float speedMultiplier = 1;
    bool isSeePlayer = false;
    Vector2 trfrm;
    public static float enemyHP = 1;
    public Image enemyHpBarFilling;
    public static Image staticEnemyHpBarFilling;

    private void Start()
    {
        staticEnemyHpBarFilling = enemyHpBarFilling;
    }

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
        if (transform.localScale.x > 0)
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
            isSeePlayer = true;
            Debug.Log("Видит");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isSeePlayer = false;
        }
    }

    private void Update()
    {
        Ray2D ray = new Ray2D(transform.position, transform.forward);
        trfrm = DirectionDtrm(speed);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, trfrm);
        if (!isSeePlayer) {
            if (hit.transform.name == "Player Cube")
            {
                isSeePlayer = true;
               // Debug.Log("Видит");
            }
        }
        else
        {
            ray = new Ray2D(transform.position, transform.forward);
            trfrm = DirectionDtrm(speed);
            hit = Physics2D.Raycast(transform.position, trfrm);
            if (!(hit.transform.name == "Player Cube"))
            {
                isSeePlayer = false;
                //Debug.Log("не Видит");
            }
        }

        if(enemyHP <= 0)
        {
            Destroy(enemy);
        }
    }

    private void FixedUpdate()
    {
        if (!isSeePlayer)
        {
            calmBehavior();
            Debug.Log("Не видит");
        }
        else
        {
            //тут надо дописать приследование игрока. Я заебался
            //Debug.Log("Заметил");
            trfrm = DirectionDtrm(speed);
            Debug.Log("видит");
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, trfrm);
        }
    }
}
