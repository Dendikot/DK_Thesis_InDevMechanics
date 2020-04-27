using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponShake : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 1;

    [SerializeField]
    private float m_Distance = 1;

    public bool Walking
    {
        set { m_Walking = value; }
    }

    private bool m_Walking = false;

    // Update is called once per frame
    void Update()
    {
        if ( !m_Walking )
        {
            return;
        }

        WalkShake ( );
    }

    private void WalkShake ()
    {
        transform.position += 
            new Vector3 ( 0.0f , Mathf.Sin ( Time.time * m_Speed) , 0.0f ) * m_Distance;
    }
}
