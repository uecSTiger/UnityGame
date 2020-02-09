using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent agent;

    [SerializeField] float timeOut;
    [SerializeField] float timeOut2;
    private float timeElapsed;


    // Start is called before the first frame update
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      timeElapsed += Time.deltaTime;

      if(target == null){
        if(timeElapsed >= timeOut) {
          agent.SetDestination(RandomNavmeshLocation(6f));
          timeElapsed = 0.0f;
        }

      }else{
        if(timeElapsed >= timeOut) {
          agent.SetDestination(RandomNavmeshLocation(6f));

          if(timeElapsed >= timeOut2) {
            agent.SetDestination(target.position);
            timeElapsed = 0.0f;
          }
        }
      }
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
