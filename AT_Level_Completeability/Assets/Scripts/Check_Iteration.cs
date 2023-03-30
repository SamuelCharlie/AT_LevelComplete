using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Iteration : MonoBehaviour
{
    #region [References]
    [Header("References")]
    [SerializeField]
    private Transform[] platforms;

    public GameObject platform_holder;
    public GameObject check_box;
    #endregion

    #region [Variables]
    [Header("Platform Amount")]
    [SerializeField]
    private float _child_count;
    #endregion

    private void Awake()
    {
        platforms = gameObject.GetComponentsInChildren<Transform>();

        _child_count = platform_holder.transform.childCount;
        MoveToTransform();
    }

    private void MoveToTransform()
    {
        for (int i = 0; i < (_child_count + 1); i++)
        {
            check_box.transform.position = platforms[i].position;
            Debug.Log(platforms[i]);
        }
    }
}
