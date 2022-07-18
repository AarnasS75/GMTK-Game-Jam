using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed = 40f;
    Rigidbody rb;

    [SerializeField] public int bulletDamage = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * Speed;
    }

    public int EnemyBulletDamage()
    {
        return bulletDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
