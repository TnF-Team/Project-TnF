using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Player MoveSpeed")]
    [SerializeField] float moveSpeed = 10f;

    private Rigidbody moveRb;
    public PlayerInput playerInput { get; set; } // 외부에서 할당받음

    Vector3 moveVec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMoveSpeed(float _speed)
    {
        moveSpeed = _speed;
    }
}
