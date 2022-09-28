using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class cubes : MonoBehaviour
{

    public GameObject[] boxes;
    float ranZ;
    float ranX;
    Vector3 wheretospawn;
    public float spawnrate = 1f;
    public float nextspawn = 1f;
    public Text money;
    public float coin = 0;

    public bool mousedown = false;
    public Joystick joystick;
    public Rigidbody rb;
    public float speed;
    public float tumblingDuration = 0.2f;

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
        if (Input.GetMouseButtonDown(0))
        {
            mousedown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mousedown = false;
        }
        money.text = "Score: " + coin.ToString();
        var dir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector3.forward;

        if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector3.back;

        if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector3.right;

        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }
    }

    bool isTumbling = false;
    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }

        isTumbling = false;
    }
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