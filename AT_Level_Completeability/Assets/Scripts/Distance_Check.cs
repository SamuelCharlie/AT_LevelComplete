using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Check : MonoBehaviour
{
    public Transform check_from;
    public Transform check_to;

    public float distance = 0.0f;

    public void CalculateDistance()
    {
        distance = Vector3.Distance(check_from.transform.position, check_to.transform.position);
    }
}
