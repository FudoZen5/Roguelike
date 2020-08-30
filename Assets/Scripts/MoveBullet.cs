using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float bulletSpeed;
    [SerializeField] private Vector3 direction;
    private Damage damage;
    private float lifetime = 2f;
    public void Init (Vector3 moveDirection, Damage BulletDamage)
    {
        direction = moveDirection;
        damage = BulletDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<IDamageable>();
        if (target != null && !target.Equals(damage.shooter)) {
            target.GetDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * bulletSpeed * Time.deltaTime;
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            EndAnimations();
        }
    }

    public void EndAnimations()
    {
        Destroy(gameObject);
    }
}
