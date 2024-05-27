using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Action : MonoBehaviour
{
    public AudioClip collision_sound;
    public Transform explosion_effect;


    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion_effect, this.transform.position, this.transform.rotation);
        AudioSource.PlayClipAtPoint(collision_sound, this.transform.position);

        if (other.gameObject.tag == "Obstacle")
        { 
            Destroy(other.gameObject);  
        }
        else if(other.gameObject.tag == "Enemy")
        {
            Score_Record.win++;
            if(Score_Record.win > 5)
            {
                Destroy(other.transform.root.gameObject);
            }
        }

        Destroy(this.gameObject);
    }
}
