using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBulletCollision : MonoBehaviour
{
    public Image enemyHpBarFilling;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            enemyHpBarFilling.fillAmount = BehaviorEnemy.enemyHP - PlayerShot.staticDamageShot;
        }
    }
}
