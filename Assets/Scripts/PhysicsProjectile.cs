using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsProjectile : Projectile
{
    [SerializeField] private float lifeTime;
    private Rigidbody rigidBody;
    private float damage;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        damage = enemy.GetComponent<EnemyAI>().damageBullet;
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        rigidBody.AddRelativeForce(Vector3.forward * weapon.GetShootingForce(), ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        ITakeDamage[] damageTakers = other.GetComponentsInParent<ITakeDamage>();

        foreach (var taker in damageTakers)
        {
            taker.TakeDamage(weapon, this, transform.position);
        }
        if(other.name == "Main Camera"){
            other.GetComponentInParent<Player>().TakeDamage(damage);
        }
    }
}
