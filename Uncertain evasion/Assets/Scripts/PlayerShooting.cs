using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform GunTip;
    [SerializeField] PlayerGun gun;
    float fireTime;

    AudioSource audioSource;


    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        fireTime += Time.deltaTime;

        if (gun.type == GunType.ClickShoot)
        {
            animator.SetTrigger("Aiming");
            if (Input.GetMouseButtonDown(0) && fireTime >= gun.fireRate)
            {
                audioSource.clip = gun.fireSound;
                audioSource.Play();
                fireTime = 0f;
                GameObject newBullet = Instantiate(gun.bulletPrefab, GunTip.position, Quaternion.identity);
                newBullet.GetComponent<PlayerBullet>().gun = gun;
                newBullet.transform.forward = transform.forward;
            }
        } 
        else if (gun.type == GunType.HoldShoot)
        {
            animator.SetTrigger("Aiming");
            if (Input.GetMouseButton(0) && fireTime >= gun.fireRate)
            {
                audioSource.clip = gun.fireSound;
                audioSource.Play();
                fireTime = 0f;
                GameObject newBullet = Instantiate(gun.bulletPrefab, GunTip.position, Quaternion.identity);
                newBullet.GetComponent<PlayerBullet>().gun = gun;
                newBullet.transform.forward = transform.forward;
            }
        }
    }
}
