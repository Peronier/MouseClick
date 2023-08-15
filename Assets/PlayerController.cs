using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    bool isMoving;

    private void Update()
    {
        if (isMoving)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
