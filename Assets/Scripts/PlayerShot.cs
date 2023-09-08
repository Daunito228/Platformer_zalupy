using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float speed = 10;
    public static float staticSpeed;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefabRight;
    public GameObject bulletPrefabLeft;
    public GameObject explodeBulletPrefab;
    public static GameObject staticExplodeBulletPrefab;
    public float damageShot = 0.1f;
    public static float staticDamageShot;

    private void Start()
    {
        staticSpeed = speed;
        staticDamageShot = damageShot;
        staticExplodeBulletPrefab = explodeBulletPrefab;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MovePlayer.direction > 0)
            Instantiate(bulletPrefabRight,new Vector2(bulletSpawnPoint.position.x, bulletSpawnPoint.position.y), Quaternion.identity);
        else if (Input.GetKeyDown(KeyCode.Mouse0) && MovePlayer.direction < 0)
            Instantiate(bulletPrefabLeft, new Vector2(bulletSpawnPoint.position.x, bulletSpawnPoint.position.y), Quaternion.identity);
    }
}
