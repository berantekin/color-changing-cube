using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube : MonoBehaviour
{
    public GameObject[] boxes;
    float ranZ;
    float ranX;
    Vector3 wheretospawn;
    public float spawnrate = 1f;
    public float nextspawn = 1f;
    public Text money;
    public float coin = 0;
    //public int speed = 30;
    private bool isMoving = false;
    public bool mousedown = false;
    public Joystick joystick;
    public Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;
            ranZ = Random.Range(-8f, 8f);
            ranX = Random.Range(-8f, 8f);
            wheretospawn = new Vector3(ranX, .6f, ranZ);

            Instantiate(boxes[Random.Range(0, 3)], wheretospawn, Quaternion.identity);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mousedown = true;
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    mousedown = false;
        //}
        money.text = "Score: " + coin.ToString();


       
    }
    //IEnumerator Roll(Vector3 direction)
    //{
    //    isMoving = true;

    //    float remainingAngle = 90;
    //    Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
    //    Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

    //    while (remainingAngle > 0)
    //    {
    //        float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
    //        transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
    //        remainingAngle -= rotationAngle;
    //        yield return null;
    //    }
    //    isMoving = false;
    //}
    //private void FixedUpdate()
    //{
    //    if (mousedown == true)
    //    {
    //        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
    //        transform.Rotate(Vector3.up * -100 * Time.deltaTime, Space.Self);
    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "blue")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
            
            coin = coin + 2f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "red")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
            
            coin = coin + 1f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "green")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
            
            coin = coin + 3f;
            Destroy(other.gameObject);
        }
    }
}
