using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private GameObject player = null;
    private Vector3 positiom_offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        positiom_offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 new_position = transform.position;
        new_position.x = player.transform.position.x + positiom_offset.x;
        transform.position = new_position;
    }
}
