using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Control : MonoBehaviour
{
    public Map_Create map_script = null;

    // Start is called before the first frame update
    void Start()
    {
        map_script = GameObject.Find("Block_Root").GetComponent<Map_Create>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(map_script.IsGone(gameObject))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
