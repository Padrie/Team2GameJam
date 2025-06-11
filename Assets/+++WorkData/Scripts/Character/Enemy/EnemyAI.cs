using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    EnemyStats enemyStats;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent.destination = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit()
    {
        if (CompareTag("Player"))
        {
            StopCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        bool whatever = true;
        while (whatever)
        {
            whatever = player.GetComponent<PlayerTestScript>().TakeDamage(enemyStats.attackDamage);
            yield return new WaitForSeconds(enemyStats.attackSpeed);
        }
        StopCoroutine(Attack());
    }
}
