using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Joystick joystick;
    private bool isMoving = false;
    [SerializeField] private float playerspeed = 5f;
    [SerializeField] private float cuberotatespeed = 5f;
    [SerializeField] private Transform cubetransform;
    private float rotateangle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = false;
        }
        rotateangle = Input.GetAxis("Horizontal");

        if (isMoving)
        {
            transform.position += transform.forward * playerspeed * Time.deltaTime;
            transform.Rotate(0, rotateangle, 0);
            cubetransform.Rotate(cuberotatespeed * Time.deltaTime, 0, 0);
        }
    }
}
