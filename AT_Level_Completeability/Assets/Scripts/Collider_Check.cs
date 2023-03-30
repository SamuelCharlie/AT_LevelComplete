using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Check : MonoBehaviour
{
    #region [References]
    [Header("References")]
    Distance_Check distance_check;

    public LayerMask level_platform;
    #endregion

    #region [Box Variables]
    [Header("Colliders")]
    Collider[] hit_colliders;
    #endregion

    #region [Text Variables]
    [Header("Text")]
    public GameObject problem_text;
    private PrintProblemText print_problem_text;
    #endregion

    private void Awake()
    {
        distance_check = GetComponent<Distance_Check>();
        print_problem_text = problem_text.GetComponent<PrintProblemText>();
    }

    private void FixedUpdate()
    {
        HandleCollidersHit();
    }
    public void HandleCollidersHit()
    {
        hit_colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, level_platform);
        print_problem_text.ClearText();

        foreach (Collider hit_collider in hit_colliders)
        {
            //Debug.Log(hit_colliders.Length);
            //distance_check.check_from = hit_colliders[0].gameObject.GetComponent<Transform>();

            if (hit_colliders.Length == 2)
            {
                distance_check.check_from = hit_colliders[0].gameObject.GetComponent<Transform>();
                distance_check.check_to = hit_colliders[1].gameObject.GetComponent<Transform>();
            }
            distance_check.CalculateDistance();

            if (distance_check.distance == 0)
                print_problem_text.PrintPlatformProblem();

            Debug.Log(distance_check.distance);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);  
    }
}
