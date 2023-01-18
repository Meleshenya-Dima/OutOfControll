using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float Damage = 20f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Animator>().SetTrigger("GetDamage");
            collider.GetComponent<HealthManager>().GetDamage(Damage);
        }
        else if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Animator>().SetTrigger("GetDamage");
            collider.GetComponent<EnemyHealth>().GetDamage(Damage);
        }
    }
}
