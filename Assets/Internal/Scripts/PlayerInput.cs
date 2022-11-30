using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInput : NetworkBehaviour
{
    void Update()
    {
        HandlePlayerInput();
    }
    float movement_speed = 5;

    void HandlePlayerInput()
    {
        if (!isLocalPlayer)
            return;

        HandleMovement();
        HandleRotation();
    }
    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 shift = new Vector3(horizontal, 0, vertical).normalized;

        transform.position += shift * Time.deltaTime * movement_speed;
    }
    void HandleRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        foreach(RaycastHit hit in Physics.RaycastAll(ray))
            if(hit.transform.gameObject.tag == "MouseIntersectionCollider")
            {
                transform.LookAt(hit.transform.position);
                vec = transform.position - hit.transform.position;
                break;
            }

        
    }

    Vector3 vec = Vector3.zero;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, vec);
    }
}
