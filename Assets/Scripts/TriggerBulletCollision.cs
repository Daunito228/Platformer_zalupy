using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TriggerBulletCollision : MonoBehaviour
{
    public GameObject bullet;
    private GameObject particle;
    private Vector2 explodePos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explodePos = new Vector2(bullet.transform.position.x, bullet.transform.position.y);

        if (collision.gameObject.tag == "Floor")
        {
            particle = Instantiate(PlayerShot.staticExplodeBulletPrefab, explodePos, Quaternion.identity);
            Destroy(bullet);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            particle = Instantiate(PlayerShot.staticExplodeBulletPrefab, explodePos, Quaternion.identity);
            Destroy(bullet);
            BehaviorEnemy.enemyHP -= PlayerShot.staticDamageShot;
            BehaviorEnemy.staticEnemyHpBarFilling.fillAmount = BehaviorEnemy.enemyHP;
        }
        Destroy(particle, 0.1f);
    }
}
