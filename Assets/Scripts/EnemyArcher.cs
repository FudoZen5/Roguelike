using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : Enemy
{
    [SerializeField] private float range;
    private float reload = 1;
    private float reloadTime = 1;
    private void Awake()
    {
       // playerss = PlayerController.Instance.transform.position;
    }
    void Update()
    {
        Move();
        if (AttackAvailable())
                Attack();
    }

    private bool AttackAvailable()
    {
        if (Vector3.Distance(PlayerController.Instance.transform.position, transform.position) <= range && reload <= 0)
        {
            reload = reloadTime;
            return true;
        }
        reload -= Time.deltaTime;
        return false;
    }



}
