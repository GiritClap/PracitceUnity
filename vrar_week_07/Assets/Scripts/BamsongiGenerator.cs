using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;
    BamsongiCtrl bam;
    float x;
    float y;
    float timer = 0;
    public bool timer_start = false;
    int cnt = 0;
    public int score = 0;
    // Update is called once per frame
    private void Start()
    {
        x = Random.Range(-400.0f, 400.0f);
        y = Random.Range(-100.0f, 400.0f);
    }
    void Update()
    {
        if(timer_start)
        {
            timer += Time.deltaTime;
            if ((timer > 3 && bam.is_shot) || bam.is_hit)
            {
                x = Random.Range(-400.0f, 400.0f);
                y = Random.Range(-100.0f, 400.0f);
                timer = 0;
                bam.is_shot = false;
                bam.is_hit = false;
                timer_start = false;
            }

        }
        if (Input.GetMouseButtonDown(0) && cnt < 5 && !timer_start)
        {
            timer_start = true;
            cnt++;
            GameObject bamsongi = Instantiate(bamsongi_prefab) as GameObject;
            Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 shooting_ray = screen_ray.direction;
            bam = bamsongi.GetComponent<BamsongiCtrl>();
            bam.Shoot(shooting_ray * 1000);
            bam.x = x;
            bam.y = y;
           
        }
        if(Input.GetKeyDown(KeyCode.R) && cnt==5)
        {
            SceneManager.LoadScene(0);
        }
    }

    
    private void OnGUI()
    {
        GUI.Label(new Rect(25f, 5f, Screen.width, 20f), cnt.ToString() + " : " + score.ToString());
        GUI.Label(new Rect(25f,25f,Screen.width,20f),"( "+ x.ToString() + ", " + y.ToString() + ", 0)");
        if(cnt == 5)
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height/2, Screen.width, Screen.height), "press 'R' button to restart");
        }
    }
}
