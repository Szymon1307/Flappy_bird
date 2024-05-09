using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D Rb2D;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Rb2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
