using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Record : MonoBehaviour
{
    public static int win = 0;
    public static int lose = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 120, 120), "Win : " + win);
        GUI.Label(new Rect(10, 30, 120, 120), "Lose : " + lose);

    }
}
