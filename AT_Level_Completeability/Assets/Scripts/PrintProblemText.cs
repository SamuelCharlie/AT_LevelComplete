using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PrintProblemText : MonoBehaviour
{
    public TMPro.TMP_Text problem_text;    

    public void ClearText()
    {
        problem_text.text = "";
    }

    public void PrintPlatformProblem()
    {
        problem_text.text = "- Player Will Be Unable To Make The Jump, Place A Platform Closer";
    }
}
