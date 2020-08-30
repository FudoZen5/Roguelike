using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int health;
    [SerializeField]private GameObject Bullet;
    [SerializeField] private int damage;
    private Rigidbody _rigidbody;
    private MoveBullet moveBullet;
    private Vector3 target;
    [SerializeField] protected int speed;
    [SerializeField] private Transform bulletConteiner;
    public System.Action<Enemy> OnDie;

    public virtual void Move()
    {
        target = PlayerController.Instance.transform.position - transform.position;
        transform.Translate(target.normalized * Time.deltaTime * speed);
    }

    public virtual void Attack()
    {
        var bullet = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<MoveBullet>();
        bullet.Init(PlayerController.Instance.transform.position - transform.position, new Damage(this, damage));
    }
    public void GetDamage(Damage damage)
    {
        if (damage.shooter.Equals(this))
            return;
        health -= (int)damage.damage;
        if (health < 1)
            Die(); // ^_^
    }

    public void Die()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }
}
