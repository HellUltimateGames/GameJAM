using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
  



    

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    
    public float health;

    public bool isDead;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public Animator anim;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public float projectileSpeed = 50f;

    //States
    public float sightRange, attackRange;
    public bool playerSightInRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //Check is player is in sight or attack range
        playerSightInRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerSightInRange && !playerInAttackRange) Patrolling();
        if (playerSightInRange && !playerInAttackRange) ChasePlayer();
        if (playerSightInRange && playerInAttackRange) AttackPlayer();

        
    }

    private void Patrolling()
    {
        anim.SetInteger("Mode", 0);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {

        anim.SetInteger("Mode", 1);
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {

        anim.SetInteger("Mode", 2);
        //makse sure enemy doesnt move
        agent.Warp(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            ///Attack Code
            Rigidbody rb = Instantiate(projectile, transform.position + (transform.forward*2), Quaternion.identity).GetComponent<Rigidbody>();
            rb.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
            
            
            ///

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(KillEnemy), .2f);
    }
    public void KillEnemy()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
