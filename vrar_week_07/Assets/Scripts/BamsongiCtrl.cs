using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiCtrl : MonoBehaviour
{
    float timer = 0.0f;
    public bool is_shot = false;
    public bool is_hit = false;
    public bool is_destroy = false;
    public float x;
    public float y;
    int score = 0;
    GameObject generator;
    void Start()
    {
        generator = GameObject.Find("bamsongi_spawn");
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.right * x * Time.deltaTime);
        GetComponent<Rigidbody>().AddForce(Vector3.up * y * Time.deltaTime);
        if(generator.GetComponent<BamsongiGenerator>().timer_start && GetComponent<Rigidbody>().isKinematic)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
        is_shot = true;
    }

    void OnCollisionEnter(Collision other)
    {
        is_hit = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        Vector3 collieded_position = transform.position;
        float distance = collieded_position.x * collieded_position.x + (collieded_position.y - 6.5f) * (collieded_position.y - 6.5f);
        distance = Mathf.Sqrt(distance);
        if (distance <= 0.4f && distance >= 0.0f)
        {
            score = 100;
        } else if (distance <= 0.8f && distance > 0.4f)
        {
            score = 90;
        } else if (distance <= 1.2f && distance > 0.8f)
        {
            score = 70;
        } else if (distance <= 1.6f && distance > 1.2f)
        {
            score = 50;
        } else if (distance <= 2.0f && distance > 1.6f)
        {
            score = 30;
        } else
        {
            score = 0;
        }
        generator.GetComponent<BamsongiGenerator>().score += score;
        Debug.Log(collieded_position);
        Debug.Log(distance);
        
    }
}
