using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightSide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-17.6f, collision.gameObject.transform.position.y, 0f);
        }
    }
}
