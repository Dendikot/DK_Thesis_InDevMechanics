using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateView : MonoBehaviour
{
    [SerializeField]
    private float m_MouseSensitivity = 2f;

    [SerializeField]
    private Transform m_PlayerBody;

    private float xRotation, yRotation = 0f;

    void Start ( )
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ( )
    {
        //set camera to the same position as player
        if ( transform.position != m_PlayerBody.transform.position )
        {
            transform.position = m_PlayerBody.transform.position;
        }

        Look ( );
    }

    private void Look ()
    {
        //get values from mouse input
        float m_MouseX = Input.GetAxis ( "Mouse X" ) * m_MouseSensitivity;
        float m_MouseY = Input.GetAxis ( "Mouse Y" ) * m_MouseSensitivity;

        //
        xRotation -= m_MouseY;
        xRotation = Mathf.Clamp ( xRotation , -90f , 90f );

        //Find current look rotation
        Vector3 rot = transform.localRotation.eulerAngles;
        float desiredX = rot.y + m_MouseX;

        //apply new rotation through eulers
        transform.localRotation = Quaternion.Euler ( xRotation , desiredX , 0f );

        //rotate player body if nessesary
        m_PlayerBody.Rotate ( Vector3.up * m_MouseX );
    }
}
