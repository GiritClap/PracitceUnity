using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_ctrl : MonoBehaviour
{
    private bool is_collided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_collided && Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        this.is_collided = true;
        collision.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnGUI()
    {
        if(is_collided)
        {
            GUI.Label(new Rect(Screen.width / 2 - 30, 80, 100, 20), "Success!!!");
            GUI.Label(new Rect(Screen.width / 2 - 30, 100, 500, 20), "다시 시작하려면 아무키나 누르세요");
        }
    }
}
