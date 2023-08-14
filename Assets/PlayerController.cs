using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector3 targetPosition;
    private Animator animator;

    [SerializeField]
    private Tilemap tilemap;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        transform.Translate(movement);

        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);
    }

    public void MoveToGridPosition(Vector3 position)
    {
        targetPosition = position;
    }

    public void MoveToPosition(Vector3 position)
    {
        Vector3 complementPos = new Vector3(tilemap.cellSize.x / 2, 0.0f, tilemap.cellSize.y / 2);
        targetPosition = position + complementPos;
    }
}
