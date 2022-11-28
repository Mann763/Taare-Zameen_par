using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Number_Display : MonoBehaviour
{
    public TextMeshPro Planet;
    public int number;
    // Start is called before the first frame update

    void Start()
    {
        Planet = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Planet.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
