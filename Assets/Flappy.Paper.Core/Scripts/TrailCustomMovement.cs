using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCustomMovement : MonoBehaviour
{
    private TrailRenderer tr;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (GameControl.instance.gameOver == false && PauseMenu.GameIsPaused == false)
        {
            for (int i = 0; i < tr.positionCount; i++)
            {
                Vector3 vec = tr.GetPosition(i);
                vec.x = vec.x - 0.02f;
                tr.SetPosition(i, vec);
            }
        }     
    }
}
