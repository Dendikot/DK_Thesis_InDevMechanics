using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float m_MouseSensitivity = 100f;

    [SerializeField]
    private Transform m_PlayerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float m_MouseX = Input.GetAxis ( "Mouse X" ) * m_MouseSensitivity ;
        float m_MouseY = Input.GetAxis ( "Mouse Y" ) * m_MouseSensitivity ;

        xRotation -= m_MouseY;
        xRotation = Mathf.Clamp (xRotation, -90f, 90f );

        transform.localRotation = Quaternion.Euler (xRotation, 0f, 0f );
        m_PlayerBody.Rotate ( Vector3.up * m_MouseX );
    }
}
