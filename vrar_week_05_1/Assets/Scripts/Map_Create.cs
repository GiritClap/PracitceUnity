using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Create : MonoBehaviour
{
    public static float BLOCK_WIDTH = 1.0f;
    public static float BLOCK_HEIGHT = 0.2f;
    public static int BLOCK_NUM_IN_SCREEN = 24;

    private Level_Control lev_ctrl = null;

    private struct FloorBlock
    {
        public bool is_create;
        public Vector3 position;
    };

    private FloorBlock last_block;
    private Player_Control player = null;
    private Block_Create block;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>();
        last_block.is_create = false;
        block = gameObject.GetComponent<Block_Create>();

        lev_ctrl = new Level_Control();
        lev_ctrl.Initialize();
    }

    void Update()
    {
        float block_generate_x = player.transform.position.x;
        block_generate_x += BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN+1) / 2.0f;
        while(last_block.position.x < block_generate_x)
        {
            CreateFloorBlock();
        }
    }

    private void CreateFloorBlock()
    {
        Vector3 block_pos;
        if(!last_block.is_create)
        {
            block_pos = player.transform.position;
            block_pos.x -= BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
            block_pos.y = 0.0f;
        }
        else
        {
            block_pos = last_block.position;
        }

        block_pos.x += BLOCK_WIDTH;

        lev_ctrl.UpdateStatus();
        block_pos.y = lev_ctrl.current_block.height * BLOCK_HEIGHT;
        Level_Control.CreationInfo current = lev_ctrl.current_block;

        if(current.block_type == Block.TYPE.FLOOR)
        {
            block.CreateBlock(block_pos);
        }

        last_block.position = block_pos;
        last_block.is_create = true;
    }

    public bool IsGone(GameObject block_obj)
    {
        bool result = false;
        float left_limit = player.transform.position.x - BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
        if(block_obj.transform.position.x < left_limit)
        {
            result = true;
        }
        return result;
    }
}
