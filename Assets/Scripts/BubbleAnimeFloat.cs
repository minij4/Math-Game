using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFloat : MonoBehaviour
{
    private Rigidbody2D bubbleBody;
    // Start is called before the first frame update
    void Start()
    {
        bubbleBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bubbleBody.velocity = new Vector2(bubbleBody.velocity.x, 1);
    }
}
