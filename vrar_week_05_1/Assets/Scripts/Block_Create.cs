using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Create : MonoBehaviour
{
    public GameObject[] block_prf;
    private int block_cnt;
    public void CreateBlock(Vector3 block_pos)
    {
        int next_block_type = block_cnt % block_prf.Length;

        GameObject game_obj = GameObject.Instantiate(block_prf[next_block_type]) as GameObject;
        game_obj.transform.position = block_pos;
        block_cnt++;
    }
}
