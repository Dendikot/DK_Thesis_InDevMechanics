using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WShake : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 1;

    [SerializeField]
    private float m_Distance = 1;

    private float m_IdleVal = 5;

    public bool Walking
    {
        set { m_Walking = value; }
    }

    private bool m_Walking = false;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Transform m_camera;

    // Update is called once per frame
    void Update ( )
    {
        WalkShake ( );
    }

    private void WalkShake ( )
    {
        if ( Mathf.Abs( rb.velocity.x ) > 0.1f )
        {
            transform.position +=
            new Vector3 ( 0.0f , Mathf.Sin ( Time.time * m_Speed ) , 0.0f ) * m_Distance;

            //rotates camera on the given value through time 
            //find solution ot rotate camera differently 
            //m_camera.Rotate ( 0 , 0 , Mathf.Sin ( Time.time ) );
            
        }
        else
        {
            transform.position +=
            new Vector3 ( 0.0f , Mathf.Sin ( Time.time * 2 ) , 0.0f ) * 0.0005f;
        }
    }
}
