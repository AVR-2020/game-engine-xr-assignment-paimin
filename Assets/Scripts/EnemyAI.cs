using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour, ITakeDamage
{
    const string RUN_TRIGGER = "Run";
    const string CROUCH_TRIGGER = "Crouch";
    const string SHOOT_TRIGGER = "Shoot";
    ScoreCounter scoreCounter;
    [SerializeField] private float startingHealth, minTimeUnderCover, maxTimeUnderCover, rotationSpeed, damage;
    [SerializeField] private int minShotsToTake, maxShotsToTake;
    [Range(0, 100)]
    [SerializeField] private float shootingAccuracy;

    [SerializeField] private Transform shootingPosition;

    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] protected Transform bulletSpawn;

    private bool isShooting;
    private int currentShotsTaken;
    private int currentMaxShotsToTake;
    private NavMeshAgent agent;
    private Player player;
    private Transform occupiedCoverSpot;
    private Animator animator;

    private float _health;

    public float health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, startingHealth);
        }
    }

    private void Awake()
    {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetTrigger(RUN_TRIGGER);
        _health = startingHealth;
    }

    public void Init(Player player, Transform coverSpot)
    {
        occupiedCoverSpot = coverSpot;
        this.player = player;
        GetToCover();
    }

    private void GetToCover()
    {
        agent.isStopped = false;
        agent.SetDestination(occupiedCoverSpot.position);
    }

    private void Update()
    {
        if(agent.isStopped == false && (transform.position - occupiedCoverSpot.position).sqrMagnitude <= 0.1f)
        {
            agent.isStopped = true;
            StartCoroutine(InitializeShootingCO());
        }
        if(isShooting)
        {
            RotateTowardsPlayer();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = player.GetHeadPosition() - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    }

    private IEnumerator InitializeShootingCO()
    {
        HideBehindCover();
        yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeUnderCover, maxTimeUnderCover));
        StartShooting();
    }

    private void StartShooting()
    {
        isShooting = true;
        currentMaxShotsToTake = UnityEngine.Random.Range(minShotsToTake, maxShotsToTake);
        currentShotsTaken = 0;
        animator.SetTrigger(SHOOT_TRIGGER);
    }

    public void Shoot()
    {
        bool hitPlayer = UnityEngine.Random.Range(0, 100) < shootingAccuracy;
        
        if (hitPlayer)
        {
            RaycastHit hit;
            Vector3 direction = player.GetHeadPosition() - shootingPosition.position;
            Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            projectileInstance.Launch();
        }
        currentShotsTaken++;
        if(currentShotsTaken >= currentMaxShotsToTake)
        {
            StartCoroutine(InitializeShootingCO());
        }
    }

    private void HideBehindCover()
    {
        animator.SetTrigger(CROUCH_TRIGGER);
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        health -= weapon.GetDamage();
        if (health <= 0)
        {
            scoreCounter.AddScore(100);
            Destroy(gameObject);
        }
    }
}
