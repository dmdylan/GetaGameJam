using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public float targetDistance;

    public void GetDistanceInfo()
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit))
        {
            targetDistance = raycastHit.distance;
        }
    }
}
