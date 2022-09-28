using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingcube : MonoBehaviour
{
    public float Inputthreshold;
    bool isrolling = false;
    float scale;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (!isrolling &&
              ((x > Inputthreshold || x < -Inputthreshold) ||
                (y > Inputthreshold || y < -Inputthreshold))
        ){
            isrolling = true;
            StartCoroutine(rollingcube(x, y));
        }
        IEnumerator rollingcube(float x, float y)
        {
            Vector3 point = Vector3.zero;
            Vector3 axis = Vector3.zero;
            float angle = 0.0f;
            Vector3 direction = Vector3.zero;

            if (x != 0)
            {
                axis = Vector3.forward;
                point = x > 0 ?
                    transform.position + (Vector3.right * scale) :
                    transform.position + (Vector3.left * scale);
                angle = x > 0 ? -90 : 90;
                direction = x > 0 ? Vector3.right : Vector3.left;

            }
            else if (y != 0)
            {
                axis = Vector3.right;
                point = y > 0 ?
                    transform.position + (Vector3.forward * scale) :
                    transform.position + (Vector3.back * scale);
                angle = y > 0 ? 90 : -90;
                direction = x > 0 ? Vector3.forward : Vector3.back;
            }
            point += new Vector3(0, -scale, 0);
            Vector3 adjustpos = point + direction * scale - new Vector3(0, -0.5f, 0);

            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                transform.RotateAround(
                    point,
                    axis,
                    angle / duration * Time.deltaTime
                    );
                elapsed += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(1);
            isrolling = false;
        }


    }


}



