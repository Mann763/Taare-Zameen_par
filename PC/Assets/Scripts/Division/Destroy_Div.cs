using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy_Div : MonoBehaviour
{

    public Planet_Holder_Div PH;

    public GameObject player;
    public GameObject Equation;
    public GameObject Win_Text;
    public GameObject SSystem_Temp;
    public GameObject Game_Over;

    public ScoreSystem_Div SSystem;

    public TrailRenderer TR;

    public GameObject Equation_Group;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Win_Text = GameObject.FindGameObjectWithTag("Win_Text");
        Equation = GameObject.FindGameObjectWithTag("Equation_Text");
        //Game_Over = GameObject.FindGameObjectWithTag("Game_Over");
        
        PH = player.GetComponent<Planet_Holder_Div>();
        TR = GetComponent<TrailRenderer>();

        Equation_Group = GameObject.FindGameObjectWithTag("Equation_Group");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (PH.Global_Value == PH.Total)
        {
            Win_Text.gameObject.SetActive(true);
            Debug.Log("Win");
            Equation_Group.SetActive(false);
            SceneManager.LoadScene(Random.Range(0,2));
        }

        if(PH.Global_Value != PH.Total && PH.Total_B == true)
        {

            Equation_Group.SetActive(false);

            Equation.gameObject.SetActive(false);
            Game_Over.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Planets")
        {
            Destroy(collision.gameObject);

            PH.equation.Add(PH.temp_Value);
        }
    }
}
