using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerGun : ScriptableObject
{
    public GameObject GunPrefab;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float fireRate = 0.4f;
    public AudioClip fireSound;
    public GunType type = GunType.ClickShoot;
    public GameObject IconPrefab;

    public int damageToEnemy;

}

public enum GunType
{
    ClickShoot,
    HoldShoot,
}