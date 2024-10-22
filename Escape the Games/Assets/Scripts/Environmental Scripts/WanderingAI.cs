using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    enum AIStates{
        Idle,
        Wandering
    }

    public Vector3 CircleCenter;
    public float CircleRadius;

    private UnityEngine.AI.NavMeshAgent agent;
    private LayerMask floormask = 0;
    private AIStates curState = AIStates.Idle;
    private float waitTimer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState){
            case AIStates.Idle:
                DoIdle();
                break;
            case AIStates.Wandering:
                Wandering();
                break;
            default:
                Debug.Log("Neigh *Snort*");
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            agent.SetDestination(ChessNav(transform.position, 7, 3));
            curState = AIStates.Wandering;
        }
    }

    public void DoIdle(){
        Debug.Log("Idling");
        if (waitTimer > 0){
            waitTimer -= Time.deltaTime;
            return;
        }
        agent.SetDestination(ChessNav(transform.position, 7, 3));
        curState = AIStates.Wandering;
    }

    public void Wandering(){
        Debug.Log("Wandering");
        if (agent.pathStatus != NavMeshPathStatus.PathComplete){
            return;
        }
        waitTimer = Random.Range(1.0f, 4.0f);
        curState = AIStates.Idle;
    }

    public Vector3 RandomNavSphere(Vector3 origin, float distance, LayerMask layerMask){
        //Randomly selects a place within the a sphere whose size and position is centered on the AI's current position and distance constraint.
        Vector3 RandomDirection = UnityEngine.Random.insideUnitSphere*distance;
        RandomDirection += origin;

        NavMeshHit navhit;

        NavMesh.SamplePosition(RandomDirection, out navhit, distance, layerMask);
        return navhit.position;
    }

    public Vector3 LimitedNavSphere(Vector3 origin, float distance, LayerMask layerMask){
        //Checks if the AI is too far from the center of its constrained area.
        float currentDistance = Vector3.Distance(origin, CircleCenter);
        if (currentDistance > CircleRadius){
            Vector3 FromCenterToOrigin = origin - CircleCenter;
            FromCenterToOrigin *= CircleRadius/currentDistance;
            origin = CircleCenter+FromCenterToOrigin;
        }

        Vector3 LimitedDirection = UnityEngine.Random.insideUnitSphere * distance;
        LimitedDirection += origin;

        NavMeshHit navhit;

        NavMesh.SamplePosition(LimitedDirection, out navhit, distance, layerMask);

        return navhit.position;
    }


    public Vector3 ChessNav(Vector3 origin, float distance, LayerMask layerMask){
        float x = Random.Range(-distance, distance);
        float z = Random.Range(-distance, distance);

        Vector3 ChessDirection = new Vector3(x, 0, z);
        ChessDirection += origin;

        NavMeshHit navhit;

        NavMesh.SamplePosition(ChessDirection, out navhit, distance, layerMask);

        return navhit.position;
    }

}
