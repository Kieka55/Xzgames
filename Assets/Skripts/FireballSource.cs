using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform trgetPoint;
    public Camera cameraLink;
    public float targetISkyDistanse;

    private void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            trgetPoint.position = hit.point;
        }
        else
        {
            trgetPoint.position = ray.GetPoint(targetISkyDistanse);
        }
        transform.LookAt(trgetPoint.position);
    }

}
