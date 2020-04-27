using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPM : MonoBehaviour
{
    // private members
    [SerializeField]
    private float m_Speed = 2;
    
    private float m_X, m_Y;
    private bool m_Jumping, m_Crouching;
    private Rigidbody m_Rb;
    private float threshold = 0.01f;
    public float counterMovement = 0.175f;

    private void Awake ( )
    {
        m_Rb = gameObject.GetComponent<Rigidbody> ( );
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate ( )
    {
        Movement ( );
    }

    // Update is called once per frame
    void Update ()
    {
        MyInput ( );
    }

    private void MyInput()
    {
        //In case of multiuse you can put it to a separate class
        m_X = Input.GetAxis ( "Horizontal" );
        m_Y = Input.GetAxis ( "Vertical" );

        m_Jumping = Input.GetButton ( "Jump" );
        m_Crouching = Input.GetKey ( KeyCode.LeftControl );

    }

    private void Movement()
    {
        //Gravity to push player to the ground 
        m_Rb.AddForce ( Vector3.down * Time.deltaTime * 10 );

        //find actual velocity relative to where player is looking
        Vector2 mag = FindVelRelativeToLook ( );
        float xMag = mag.x, yMag = mag.y;

        //Counteract sliding and sloppy movement
        CounterMovement ( m_X, m_Y, mag );


        m_Rb.AddForce ( transform.transform.forward * m_Y * m_Speed * Time.deltaTime );
        m_Rb.AddForce ( transform.transform.right * m_X * m_Speed * Time.deltaTime );
    }

    /// <summary>
    /// Find the velocity relative to where the player is looking
    /// Useful for vectors calculations regarding movement and limiting movement
    /// </summary>
    /// <returns></returns>
    public Vector2 FindVelRelativeToLook ( )
    {
        float lookAngle = transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2 ( m_Rb.velocity.x , m_Rb.velocity.z ) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle ( lookAngle , moveAngle );
        float v = 90 - u;

        float magnitue = m_Rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos ( u * Mathf.Deg2Rad );
        float xMag = magnitue * Mathf.Cos ( v * Mathf.Deg2Rad );

        return new Vector2 ( xMag , yMag );
    }

    private void CounterMovement ( float x , float y , Vector2 mag )
    {
        //if ( !grounded || jumping )
        //    return;

        ////Slow down sliding
        //if ( crouching )
        //{
        //    rb.AddForce ( moveSpeed * Time.deltaTime * -rb.velocity.normalized * slideCounterMovement );
        //    return;
        //}

        //Counter movement
        if ( Math.Abs ( mag.x ) > threshold && Math.Abs ( x ) < 0.05f || ( mag.x < -threshold && x > 0 ) || ( mag.x > threshold && x < 0 ) )
        {
            m_Rb.AddForce ( m_Speed * transform.right * Time.deltaTime * -mag.x * counterMovement );
        }
        if ( Math.Abs ( mag.y ) > threshold && Math.Abs ( y ) < 0.05f || ( mag.y < -threshold && y > 0 ) || ( mag.y > threshold && y < 0 ) )
        {
            m_Rb.AddForce ( m_Speed * transform.forward * Time.deltaTime * -mag.y * counterMovement );
        }

        //Limit diagonal running. This will also cause a full stop if sliding fast and un-crouching, so not optimal.
        //if ( Mathf.Sqrt ( ( Mathf.Pow ( rb.velocity.x , 2 ) + Mathf.Pow ( rb.velocity.z , 2 ) ) ) > maxSpeed )
        //{
        //    float fallspeed = rb.velocity.y;
        //    Vector3 n = rb.velocity.normalized * maxSpeed;
        //    rb.velocity = new Vector3 ( n.x , fallspeed , n.z );
        //}
    }
}
