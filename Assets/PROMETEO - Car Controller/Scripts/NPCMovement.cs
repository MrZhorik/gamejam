using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public Animator anim;
    public UnityEngine.AI.NavMeshAgent agent; 
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;

    void Start() 
    { 
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
        anim = GetComponent<Animator>();
    } 
    public void Panic(){
        anim.speed = 2.0f;
        anim.Play("Panic");
        Debug.Log("Panic on NPC");
    }
    void Update() 
    { 
            SetDestinationRandomly(); 
    } 
    void SetDestinationRandomly() 
    { 
if (waypoints.Count == 0) return; 
        Vector3 pos = waypoints[currentWaypointIndex].position;
        agent.SetDestination(pos);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            anim.Play("Walk");
            Debug.Log("Panic on NPC");
    } 
}
