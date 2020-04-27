using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_Controller;

    [SerializeField]
    private float m_Speed = 12;

    [SerializeField]
    private float gravity = -9.81f;

    private float jumpHeight = 6f;

    private Vector3 velocity;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance = 0.1f;

    [SerializeField]
    private LayerMask groundMask;

    private bool isGrounded;

    private void Awake ( )
    {
        m_Controller = GetComponent<CharacterController> ( );
    }

    // Update is called once per frame
    void Update ( )
    {
        isGrounded = Physics.CheckSphere ( groundCheck.position, groundDistance, groundMask );

        if ( isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis ( "Horizontal" );
        float z = Input.GetAxis ( "Vertical" );

        //take the value of player right and multiply it either by 1 or -1 and od the 
        //same for forward
        Vector3 move = transform.right * x + transform.forward * z;

        m_Controller.Move ( move * m_Speed * Time.deltaTime );

        if ( Input.GetButtonDown("Jump") && isGrounded )
        {
            velocity.y = Mathf.Sqrt ( jumpHeight * -2f * gravity );
        }

        velocity.y += gravity * Time.deltaTime;

        m_Controller.Move ( velocity * Time.deltaTime );
    }
}
