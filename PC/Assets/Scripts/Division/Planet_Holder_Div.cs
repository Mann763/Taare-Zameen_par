using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Holder_Div : MonoBehaviour
{
    public bool holded;

    public float Total = 1;

    public float Global_Value;
    public float temp_Value;

    public Number_Display holdedPlanet_Value;
    public Transform planetHolder;
    public Transform planet;

    public GameObject PHolder;

    public bool Total_B;

    //float A;
    //float B;

    float[] equation_Values = {0.5f,0.33f,0.25f,2,0.66f,1.5f,0.75f,2f,1.33f};

    public List<float> equation = new List<float>();

    private void Awake()
    {
        //A = Random.Range(1,4);
        //B = Random.Range(1,4);

        Global_Value = equation_Values[Random.Range(0,(equation_Values.Length))];
        //A / B;

    }

    // Start is called before the first frame update
    void Start()
    {
        PHolder = GameObject.FindGameObjectWithTag("Holder");
        planetHolder = PHolder.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (planet != null && holded == true)
        {
            planet.transform.position = new Vector3(planetHolder.transform.position.x, planetHolder.transform.position.y, planetHolder.transform.position.z);            
        }
        else
        {
            holded = false;
        }

        if(equation.Count == 2)
        {
            Total = equation[0] / equation[1];
            Total_B = true;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Planets" && holded == false)
        {
            holded = true;
            Debug.Log(collision.collider.tag);
            planet = collision.transform;
            holdedPlanet_Value = collision.gameObject.GetComponent<Number_Display>();
            temp_Value = holdedPlanet_Value.number;
        }

        if(collision.collider.name == "Sun" && holded == true)
        {
            holded = false;
            Destroy(planet.gameObject);
        }
    }
}
