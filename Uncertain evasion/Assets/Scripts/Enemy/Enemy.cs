using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

public class Enemy : MonoBehaviour
{
    //[SerializeField]
    private Transform player;   // Find by tag
    [SerializeField]
    private float attackRange = 2;
    [SerializeField]
    private float sightRange = 10;
    [SerializeField]
    private float health = 50;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private int damage = 12;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float timeBetweenAttacks = 0.7f;
    [SerializeField]
    private float rotationSpeed = 5f;

    private bool alreadyAttacked = false;
    private NavMeshAgent agent;
    private bool inSightRange;
    private bool inAttackRange;

    public System.Action OnEnemyDeath;

    private void OnDestroy()
    {
        OnEnemyDeath?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Find by tag

        this.agent = this.GetComponent<NavMeshAgent>();
        agent.speed = this.speed;
    }

    // Update is called once per frame
    void Update()
    {
        inSightRange = Vector3.Distance(player.position, this.transform.position) <= sightRange;
        inAttackRange = Vector3.Distance(player.position, this.transform.position) <= attackRange;

        if(inAttackRange)
        {
            RotateTowards(player);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    [Task]
    void Patrol()
    {
        if (inSightRange)
        {
            ThisTask.Succeed();
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        { 
            agent.stoppingDistance = 0;
            UpdateTargetRandom();
            ThisTask.Fail();
        }
    }

    [Task]
    void InitiateChase()
    {
        UpdateTarget();
        ThisTask.Succeed();
    }

    [Task]
    void ChasePlayer()
    {
        agent.stoppingDistance = attackRange;
        //Chase failed: got too far
        if(!inSightRange)
        {
            UpdateTargetRandom();
            ThisTask.Fail();
        }
        //Still chasing
        else if (!inAttackRange)
        {
            UpdateTarget();
        }
        //Chase succeeded
        else
        {
            ThisTask.Succeed();
        }
    }

    [Task]
    void Attack()
    {
        ThisTask.Succeed();
    }

    [Task]
    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.forward = transform.forward;
        ThisTask.Succeed();
    }

    void UpdateTarget()
    {
        agent.SetDestination(player.position);
    }

    void UpdateTargetRandom()
    {
        float x, y, z;
        x = Random.Range(0.0f, 25.0f);
        y = 0;
        z = Random.Range(0.0f, 25.0f);
        agent.isStopped = true;
        agent.SetDestination(new Vector3(x, y, z));
        agent.isStopped = false;
    }

    void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void TakeDamage(int ammount)
    {
        health -= ammount;
    }
    
    public int DealDamage()
    {
        return damage;
    }
}
