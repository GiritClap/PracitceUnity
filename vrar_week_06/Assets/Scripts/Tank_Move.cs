using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Move : MonoBehaviour
{
    private float tank_speed = 5.0f;
    private float rot_speed = 120.0f;
    public float bullet_power = 600.0f;
    public GameObject turret;
    public Transform bullet;
    public GameObject barrel;

    
    void Update()
    {
        float distance_per_frame = tank_speed * Time.deltaTime;
        float degrees_per_frame = rot_speed * Time.deltaTime;

        float moving_velocity = Input.GetAxis("Vertical");
        float tank_angle = Input.GetAxis("Horizontal");
        float turret_angle = Input.GetAxis("TurretRotation");

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame);
        this.transform.Rotate(0.0f, tank_angle * degrees_per_frame, 0.0f);
        turret.transform.Rotate(Vector3.up * turret_angle * degrees_per_frame * 0.5f);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawn_point = GameObject.Find("Sp_Bullet");
            Transform prefab_bullet = Instantiate(bullet, spawn_point.transform.position, spawn_point.transform.rotation);
            prefab_bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.up * bullet_power);
        }
    }

  
}
