using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 200;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    // Start is called before the first frame update
    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            ShootLaser();
            print("Activate laser weapon");
        }
        
    }

    // Update is called once per frame
    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.up))
        {
            RaycastHit2D _hit = Physics2D.Raycast
                (laserFirePoint.position, transform.up);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, 
                laserFirePoint.transform.right 
                * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos )
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
