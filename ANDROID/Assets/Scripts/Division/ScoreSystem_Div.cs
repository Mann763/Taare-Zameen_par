using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem_Div : MonoBehaviour
{
    public Planet_Holder_Div PA;
    
    public GameObject PaTemp;
    
    public TextMeshProUGUI Equation;

    public TextMeshProUGUI Zero;
    public TextMeshProUGUI One;
    


    float Total = 1;

    private void Start()
    {
        Total = PA.Total;

        PaTemp = GameObject.FindGameObjectWithTag("Player");
        PA = PaTemp.GetComponent<Planet_Holder_Div>();

        Equation = GetComponent<TextMeshProUGUI>();

        Equation.text = PA.Global_Value.ToString();
    }

    private void Update()
    {
        if(PA.equation.Count == 1)
        {
            Zero.text = PA.equation[0].ToString();
            if(PA.equation.Count == 2)
            {
                One.text = PA.equation[1].ToString();
            }
        }


    }
}
