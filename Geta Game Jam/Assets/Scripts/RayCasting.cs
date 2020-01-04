using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public float targetDistance;

    // Update is called once per frame
    void Update()
    {
        GetDistanceInfo();
    }

    public void GetDistanceInfo()
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit))
        {
            targetDistance = raycastHit.distance;
        }
    }
}
