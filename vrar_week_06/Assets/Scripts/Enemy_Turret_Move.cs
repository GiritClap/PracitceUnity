using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret_Move : MonoBehaviour
{
    [SerializeField]
    private float power = 1200.0f;
    private float elapsed_time = 0.0f;
    public float fire_interval = 2.0f;
    public Transform bullet;
    public Transform target;
    public Transform sp_point;

    private void Update()
    {
        this.transform.LookAt(target);
        elapsed_time += Time.deltaTime;

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);


        Debug.DrawRay(sp_point.transform.position, fwd * 5, Color.green);
        if (Physics.Raycast(sp_point.transform.position, fwd, out hit, 5) == false || hit.collider.gameObject.tag != "Tank" || elapsed_time < fire_interval)
        {
            return;
        }
        Debug.Log(hit.collider.gameObject.name);

        Transform enemy_bullet = Instantiate(bullet, sp_point.transform.position, Quaternion.identity);
        enemy_bullet.GetComponent<Rigidbody>().AddForce(fwd * power);
        elapsed_time = 0.0f;
    }
}
