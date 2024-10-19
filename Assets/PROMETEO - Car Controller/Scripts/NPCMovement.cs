using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public Animator anim;
    public UnityEngine.AI.NavMeshAgent agent; 
    void Start() 
    { 
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
        anim = GetComponent<Animator>();
    } 
    public void Panic(){
        anim.Play("Panic");
    }
    void Update() 
    { 
            SetDestinationRandomly(); 
    } 
    void SetDestinationRandomly() 
    { 
        int x, z; 
        x = Random.Range(-60, 60); 
        z = Random.Range(-60, 60); 
        Vector3 pos = new Vector3(x, z, 0); 
        agent.SetDestination(pos); 
        Debug.Log("new pos"); 
        new WaitForSeconds(500f); 
    } 
}
