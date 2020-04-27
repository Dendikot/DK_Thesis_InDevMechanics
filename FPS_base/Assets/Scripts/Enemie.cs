using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    private int m_TestHealth = 5;

    [SerializeField]
    private GameObject m_Target = null;

    private NavMeshAgent m_NMA = null;

    private Vector3 m_TargetPosition;

    private void Awake ( )
    {
        m_NMA = this.GetComponent<NavMeshAgent> ( );

        if ( m_NMA != null )
        {
            m_TargetPosition = m_Target.transform.position;
            m_NMA.SetDestination ( m_TargetPosition );
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.T ) )
        {
            Teleport ( );
        }

        if ( m_Target.transform.position != m_TargetPosition )
        {
            m_TargetPosition = m_Target.transform.position;
            m_NMA.SetDestination ( m_Target.transform.position );
        }
    }

    public void TestHit()
    {
        --m_TestHealth;
        Debug.Log ( m_TestHealth );

        if ( m_TestHealth == 0 )
        {
            Destroy ( gameObject );
        }
    }

    public void Teleport()
    {
        Vector3 CPosition = transform.position;

        float x = Random.Range ( -5f , 5f );
        float z = Random.Range ( -5f , 5f );

        CPosition.x += x;
        CPosition.z += z;

        m_NMA.Warp ( CPosition );
        m_NMA.SetDestination ( m_Target.transform.position );
    }

    
}
