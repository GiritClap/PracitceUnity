using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    int jump_power;
    float alive_time;
    // Start is called before the first frame update
    void Start()
    {
        jump_power = Random.Range(5,9);
    }

    // Update is called once per frame
    void Update()
    {
        alive_time += Time.deltaTime;
        if(Input.GetButton("Jump"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, jump_power, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5f, 5f, Screen.width, 20), "생존 시간 : " + alive_time.ToString());
        GUI.Label(new Rect(5f, 5f+20, Screen.width, 20), "현재 점프력 : " + jump_power.ToString());
    }
}
