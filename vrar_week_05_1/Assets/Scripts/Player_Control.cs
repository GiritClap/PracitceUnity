using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public static float ACCELERATION = 10.0f;
    public static float SPEED_MIN = 4.0f;
    public static float SPEED_MAX = 8.0f;
    public static float JUMP_HEIGHT_MAX = 3.0f;
    public static float JUMP_POWER_REDUCE = 0.5f;
    public static float FAIL_LIMIT = -5.0f;

    public enum STEP
    {
        NONE = -1,
        RUN = 0,
        JUMP,
        MISS,
        NUM,
    };

    public STEP step = STEP.NONE;
    public STEP next_step = STEP.NONE;

    public float step_timer = 0.0f;
    private bool is_landed = false;
    private bool is_collided = false;
    private bool is_key_released = false;

    void Start()
    {
        next_step = STEP.RUN;    
    }

    void Update()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        CheckLanded();

        switch(step)
        {
            case STEP.RUN:
            case STEP.JUMP:
                if(transform.position.y < FAIL_LIMIT)
                {
                    next_step = STEP.MISS;
                }
                break;
        }

        step_timer += Time.deltaTime;

        if(next_step == STEP.NONE)
        {
            switch(step)
            {
                case STEP.RUN:
                    if(!is_landed)
                    {

                    } else if(Input.GetButton("Jump"))
                    {
                        next_step = STEP.JUMP;
                    }
                    break;
                case STEP.JUMP:
                    if(is_landed)
                    {
                        next_step = STEP.RUN;
                    }
                    break;
            }
        }

        while(next_step != STEP.NONE)
        {
            step = next_step;
            next_step = STEP.NONE;

            switch(step)
            {
                case STEP.JUMP:
                    velocity.y = Mathf.Sqrt(2.0f*9.8f*JUMP_HEIGHT_MAX);
                    is_key_released = false;
                    break;
            }
            step_timer = 0.0f;
        }

        switch (step)
        {
            case STEP.RUN:
                velocity.x += Player_Control.ACCELERATION * Time.deltaTime;
                if (Mathf.Abs(velocity.x) > Player_Control.SPEED_MAX)
                {
                    velocity.x = Player_Control.SPEED_MAX;
                }
                break;
            case STEP.JUMP:
                do
                {
                    if (!Input.GetButtonUp("Jump"))
                    {
                        break;
                    }
                    if (is_key_released)
                        break;
                    if (velocity.y <= 0.0f)
                        break;
                    Debug.Log("¤¾¤·");
                    velocity.y *= JUMP_POWER_REDUCE;
                    is_key_released = true;
                } while (false);
                break;
            case STEP.MISS:
                velocity.x -= Player_Control.ACCELERATION * Time.deltaTime;
                if(velocity.x < 0.0f)
                {
                    velocity.x = 0.0f;
                    Application.Quit();
                }
                break;
        }


        GetComponent<Rigidbody>().velocity = velocity;
    }

    private void CheckLanded()
    {
        is_landed = false;
        do
        {
            Vector3 current_position = transform.position;
            Vector3 down_position = current_position + Vector3.down * 1.0f;

            RaycastHit hit;
            if (!Physics.Linecast(current_position, down_position, out hit))
            {
                break;
            }
            if (step == STEP.JUMP)
            {
                if (step_timer < Time.deltaTime * 3.0f)
                {
                    break;
                }
            }
            is_landed = true;
        } while (false); 
    }

}
