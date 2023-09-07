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
            BehaviorEnemy.enemyHP -= PlayerShot.staticDamageShot;
            BehaviorEnemy.staticEnemyHpBarFilling.fillAmount = BehaviorEnemy.enemyHP;
            Debug.Log(BehaviorEnemy.enemyHP - PlayerShot.staticDamageShot);
        }   
    }
}
