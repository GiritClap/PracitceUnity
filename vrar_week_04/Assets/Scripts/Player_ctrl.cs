using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_ctrl : MonoBehaviour
{
    private float power;
    public float power_plus = 100.0f;
    public GameObject goal;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        goal.transform.position = new Vector3(Random.Range(7.0f, 10.0f), Random.Range(-3.0f, 2.0f), 0);
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isJumping)
        {
            power += power_plus * Time.deltaTime;
        }

        if(Input.GetMouseButtonUp(0) && !isJumping)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
            power = 0.0f;
            isJumping = true;
        }

        if(this.transform.position.y < -5.0f || Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
