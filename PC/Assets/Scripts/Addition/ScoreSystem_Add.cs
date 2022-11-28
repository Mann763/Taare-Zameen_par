using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem_Add : MonoBehaviour
{
    public Planet_Holder_Add PA;
    public GameObject PaTemp;
    public TextMeshProUGUI Equation;

    int Total = 0;

    public TextMeshProUGUI Zero;
    public TextMeshProUGUI One;
    public TextMeshProUGUI Two;
    public TextMeshProUGUI Three;


    private void Awake()
    {
        Total = PA.Total;
    }

    private void Start()
    {
        PaTemp = GameObject.FindGameObjectWithTag("Player");
        PA = PaTemp.GetComponent<Planet_Holder_Add>();

        Equation = GetComponent<TextMeshProUGUI>();
        
        Equation.text = "" + PA.Global_Value;
    }

    private void Update()
    {
        if (PA.equation.Count >= 1)
        {
            Zero.text = PA.equation[0].ToString();
            if (PA.equation.Count >= 2)
            {
                One.text = PA.equation[1].ToString();

                if (PA.equation.Count >= 3)
                {
                    Two.text = PA.equation[2].ToString();

                    if (PA.equation.Count >= 4)
                    {
                        Three.text = PA.equation[3].ToString();

                    }
                }
            }
        }


    }
}
