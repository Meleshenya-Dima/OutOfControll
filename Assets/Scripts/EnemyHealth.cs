using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public BoxCollider HitObject;
    public float _health = 100f;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value <= 0)
            {
                EnemyDied();
            }
            else
            {
                _health = value;
            }
        }
    }
    public void GetDamage(float damage)
    {
        Health -= damage;
    }

    private void EnemyDied()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        HitObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().areaMask = 0;
        gameObject.GetComponent<Animator>().SetTrigger("Die");
    }

    public void GetHelth(float health)
    {
        Health += health;
    }
}
