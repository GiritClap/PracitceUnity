using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public float rot_angle = 15.0f;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    // Update is called once per frame
    void Update()
    {
        float current_angle = rot_angle * Time.deltaTime;

        this.transform.RotateAround(Vector3.zero, Vector3.up, current_angle);
        //MoveToTarget();
    }

 /*   void MoveToTarget()
    {
        agent.SetDestination(target.transform.position);
    }*/
}
