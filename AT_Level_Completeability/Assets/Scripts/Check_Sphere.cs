using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Sphere : MonoBehaviour
{
    #region [References]
    [Header("References")]
    Distance_Check distance_check;

    public LayerMask level_platform;
    #endregion

    #region [Sphere Variables]
    [Header("Sphere")]
    public float sphere_radius = 0.0f;
    #endregion

    private void Awake()
    {
        distance_check = GetComponent<Distance_Check>();
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, sphere_radius, level_platform))
            Debug.Log("Something is here");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, sphere_radius);
    }
}
