using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ShotHole, m_Bullet;

    [SerializeField]
    private Transform m_FPSCam;

    // google bit shift
    // Bit shift the index of the layer (8) to get a bit mask
    // This would cast arrays only against colliders in layer 8
    private int m_GroundMask = 1 << 8;
    private int m_EnemieMask = 9;

    private void Awake ( )
    {
        // if instead we want to collide against everything except layer 8
        // the ~ operator does this, it inverts a bitmask
        // layerMask = ~layerMask;
    }

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {
        if ( Input.GetKeyDown ( KeyCode.Mouse0 ) )
        {
            Shot ( );
        }
    }

    private GameObject Shot ( )
    {
        RaycastHit hit;

        if ( Physics.Raycast (
             m_FPSCam.position , transform.TransformDirection ( Vector3.forward ) ,
             out hit , Mathf.Infinity ) )
        {
            if ( hit.collider.gameObject.tag == "Ground" )
            {
                Instantiate ( m_ShotHole , hit.point , Quaternion.LookRotation ( hit.normal ) );
            }
            else if ( hit.collider.gameObject.tag == "Enemie" )
            {
                hit.transform.gameObject.GetComponent<Enemie> ( ).TestHit ( );
            }
        }
        else
        {
            Debug.Log ( "Not hit" );
        }

        return null;
    }


    // =============================================================================
    // Possibility for the future development, projectile spawner
    // =============================================================================

    //private void ShootBullet( Vector3 Position )
    //{
    //    GameObject Bullet = Instantiate ( 
    //       m_Bullet, 
    //       transform.position, 
    //       transform.rotation);

    //    Bullet.GetComponent<Rigidbody> ( ).velocity =
    //        ( Position - transform.position).normalized * 2500 * Time.deltaTime;
    //}

}
