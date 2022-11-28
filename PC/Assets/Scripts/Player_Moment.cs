using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moment : MonoBehaviour
{
    public float Speed = 10;
    public float rotSpeed = 180;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;

        float z = rot.eulerAngles.z;

        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);

        transform.rotation = rot;

        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, 0);

        pos += rot * velocity;

        transform.position = pos;
    }
}
