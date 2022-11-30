using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMover : MonoBehaviour
{
    [SerializeField] GameObject player;
    





    void Update()
    {
        if (player == null)
            return;
        Vector3 new_pos;
        new_pos = player.transform.position;
        new_pos.y = transform.position.y;

        transform.position = new_pos;
    }

}
