using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] float span = 3f;

    // Start is called before the first frame update
    void Start(){
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating ("decideTargetPotision", span, span);
    }

    // 目的地を設定する
    private void decideTargetPotision(){
        // 目的地を再設定する
        agent.SetDestination(RandomNavmeshLocation(4f));
    }

    public Vector3 RandomNavmeshLocation(float radius) {
         Vector3 randomDirection = Random.insideUnitSphere * radius;
         randomDirection += transform.position;
         NavMeshHit hit;
         Vector3 finalPosition = Vector3.zero;
         if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
             finalPosition = hit.position;
         }
         return finalPosition;
    }
}
