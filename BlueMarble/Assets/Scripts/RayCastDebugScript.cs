using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDebugScript : MonoBehaviour
{
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
    }

  

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction*1000, Color.red);
    }
}
