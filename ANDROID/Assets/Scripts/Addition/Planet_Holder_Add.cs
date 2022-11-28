using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Planet_Holder_Add : MonoBehaviour
{
    public bool holded;

    public int Total;

    public int Global_Value;
    public int temp_Value;

    public Number_Display holdedPlanet_Value;
    public Transform planetHolder;
    public Transform planet;

    public GameObject PHolder;
    public AudioSource deathPlanet;
    public AudioSource grabPlanet;

    int A;
    int B;

    public List<int> equation = new List<int>();


    //int[] equation_Values = {1,2,3,4,6,8,9,12,16};

    private void Awake()
    {
        A = Random.Range(2,5);
        B = Random.Range(1,5);

        Global_Value = A + B;
        
        //Global_Value = equation_Values[Random.Range(0, (equation_Values.Length))];

        //equation_Values[Random.Range(0,(equation_Values.Length))];
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
        deathPlanet = GameObject.FindGameObjectWithTag("deathPlanetAudio").GetComponent<AudioSource>();
        grabPlanet = GameObject.FindGameObjectWithTag("grabPlanetAudio").GetComponent<AudioSource>();

        if (planet != null && holded == true)
        {
            planet.transform.position = new Vector3(planetHolder.transform.position.x, planetHolder.transform.position.y, planetHolder.transform.position.z);            
        }
        else
        {
            holded = false;
        }

         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Planets" && holded == false)
        {
            holded = true;
            grabPlanet.Play();
            Debug.Log(collision.collider.tag);
            planet = collision.transform;
            holdedPlanet_Value = collision.gameObject.GetComponent<Number_Display>();
            temp_Value = holdedPlanet_Value.number;
        }

        if(collision.collider.name == "Sun" && holded == true)
        {
            holded = false;
            deathPlanet.Play();
            Destroy(planet.gameObject);
            equation.Add(temp_Value);
        }
    }
}
