using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public Transform targetd;
    public float sped = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 disiredposition = targetd.position + offset;
        Vector3 smothposiyion = Vector3.Lerp(transform.position, disiredposition, sped);
        transform.position = smothposiyion;





    }
    //[SerializeField]
    //private Transform arget;

    //[SerializeField]
    //private Vector3 offsetPosition;

    //[SerializeField]
    //private Space offsetPositionSpace = Space.Self;

    //[SerializeField]
    //private bool lookAt = true;

    //private void FixedUpdate()
    //{
    //    Refresh();
    //}
    //-25 15 67
    //public void Refresh()
    //{
    //    if (arget == null)
    //    {
    //        Debug.LogWarning("Missing target ref !", this);

    //        return;
    //    }

    //    // compute position
    //    if (offsetPositionSpace == Space.Self)
    //    {
    //        transform.position = arget.TransformPoint(offsetPosition);
    //    }
    //    else
    //    {
    //        transform.position = arget.position + offsetPosition;
    //    }

    //    // compute rotation
    //    if (lookAt)
    //    {
    //        transform.LookAt(arget);
    //    }
    //    else
    //    {
    //        transform.rotation = arget.rotation;
    //    }
    //}
}
