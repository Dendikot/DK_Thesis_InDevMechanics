using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    private Rigidbody m_RB;

    private float x, y;

    private void Awake ( )
    {
        m_RB = gameObject.GetComponent<Rigidbody> ( );
    }

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {
        MyInput ( );
    }

    private void FixedUpdate ( )
    {
        Movement ( );
    }

    private void MyInput ( )
    {
        x = Input.GetAxisRaw ( "Horizontal" );
        y = Input.GetAxisRaw ( "Vertical" );
    }

    private void Movement ( )
    {
        //m_RB.AddForceAtPosition ( );

    }
}
