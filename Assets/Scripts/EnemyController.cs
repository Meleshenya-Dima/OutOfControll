using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject GameObject;
    public string targetTag = "Player";
    public int rays = 8;
    public int distance = 33;
    public float angle = 40;
    public Vector3 offset;
    public Transform target;
    private NavMeshAgent Nana;
    private NavMeshAgent agent;
    public Animator animator;
    public int kickDistance = 1;

    void Start()
    {
        target = GameObject.transform.Find(PlayerInformationStatic.PrefabHero).gameObject.transform;
        Nana = GetComponent<NavMeshAgent>();
        agent = GetComponent<NavMeshAgent>();
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }
        if (a || b) result = true;
        return result;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            agent.isStopped = false;
            if (Vector3.Distance(transform.position, target.position) < kickDistance)
            {
                animator.SetTrigger("Kick");
            }
            else
            {
                animator.SetTrigger("NotKick");
                agent.SetDestination(target.position);
                animator.SetTrigger("Walk");
                if (RayToScan())
                {
                    Nana.enabled = true;
                }
            }
        }
        else
        {
            animator.SetTrigger("NotWalk");
            agent.isStopped = true;
        }
    }
}