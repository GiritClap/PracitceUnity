using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    MeshRenderer[] mesh;
    int range;
    // Start is called before the first frame update
    void Start()
    {
        mesh = this.GetComponentsInChildren<MeshRenderer>();
        range = RandomColor();
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(range * Time.deltaTime, 0, 0);
    }

    int RandomColor()
    {
        int range = Random.Range(-6, -3);

        if (range == -6)
        {
            mesh[0].material.color = Color.red;
            mesh[1].material.color = Color.red;
        }
        else if (range == -5)
        {
            mesh[0].material.color = Color.green;
            mesh[1].material.color = Color.green;
        }
        else if (range == -4)
        {
            mesh[0].material.color = Color.blue;
            mesh[1].material.color = Color.blue;
        }
        
        return range;
    }
}
