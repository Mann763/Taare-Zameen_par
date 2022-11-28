using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy_Subtraction : MonoBehaviour
{

    public Planet_Holder_Sub PH;
    public GameManager GM;
    public GameObject player;
    public GameObject Equation;
    public GameObject Win_Text;
    public GameObject SSystem_Temp;
    public GameObject Game_Over;

    public ScoreSystem_Subtraction SSystem;

    public GameObject Equation_Group;

    // Start is called before the first frame update
    void Start()
    {    
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        Equation = GameObject.FindGameObjectWithTag("Equation_Text");
        Equation_Group = GameObject.FindGameObjectWithTag("Equation_Group");

        PH = player.GetComponent<Planet_Holder_Sub>();

        GM.closeButton.SetActive(true);
        GM.scoreCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PH.Global_Value == PH.Total)
        {
            // Equation.gameObject.SetActive(false);
            // Win_Text.gameObject.SetActive(true);
            // SceneManager.LoadScene(Random.Range(0,2));

            StartCoroutine(Correct());
        }
        
        if(PH.Global_Value > PH.Total)
        {
            // Equation_Group.gameObject.SetActive(false);

            // Equation.gameObject.SetActive(false);
            // Game_Over.gameObject.SetActive(true);
            // Time.timeScale = 0f;

            StartCoroutine(GameOver());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Planets")
        {
            Destroy(collision.gameObject);
            PH.Total = PH.Total - PH.temp_Value;
            PH.equation.Add(PH.temp_Value);
        }
    }

    IEnumerator Correct()
    {
        player.SetActive(false);
        Equation.gameObject.SetActive(false);
        Win_Text.gameObject.SetActive(true);
        // score = 5;

        yield return new WaitForSeconds(2f);
        GameManager.instance.AddScore();
        // GM.score = GM.score + 5;
        // SceneManager.LoadScene(Random.Range(1,4));
        // player.SetActive(true);

        // SceneManager.LoadScene(Random.Range(0,2));
    }

    IEnumerator GameOver()
    {
        Equation_Group.gameObject.SetActive(false);

        Equation.gameObject.SetActive(false);
        Game_Over.gameObject.SetActive(true);
        GM.canSubtract();
        //Time.timeScale = 0f;
        
        yield return new WaitForSeconds(2f);
        Debug.Log("Game Over");
         GM.canSubtract();
        //SceneManager.LoadScene(Random.Range(0,2));
    }

    
}
