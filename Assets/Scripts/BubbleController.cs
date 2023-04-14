using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Vector3 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        direction = new Vector3(1, 1, 0);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            int num = Random.Range(0, 2);

            if(num == 0)
            {
                direction = new Vector3(1, -1, 0);
            } else
            {
                direction = new Vector3(-1, -1, 0);
            }
        }
        if (collision.gameObject.CompareTag("Bottom"))
        {
            int num = Random.Range(0, 2);

            if (num == 0)
            {
                direction = new Vector3(1, 1, 0);
            }
            else
            {
                direction = new Vector3(-1, 1, 0);
            }
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            int num = Random.Range(0, 2);

            if (num == 0)
            {
                direction = new Vector3(1, 1, 0);
            }
            else
            {
                direction = new Vector3(1, -1, 0);
            }
        }
        if (collision.gameObject.CompareTag("Right"))
        {
            int num = Random.Range(0, 2);

            if (num == 0)
            {
                direction = new Vector3(-1, 1, 0);
            }
            else
            {
                direction = new Vector3(-1, -1, 0);
            }
        }
    }
}
