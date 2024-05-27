using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pf_wall;

    IEnumerator Start()
    {
        while(true)
        {
            Instantiate(pf_wall, new Vector3(transform.position.x,Random.Range(-3,5),transform.position.z), transform.rotation);
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
        }
    }
}
