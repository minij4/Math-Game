
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class BubbleAnime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject bubbleReference;

    private GameObject spawnedBubble;

    [SerializeField]
    private Transform leftPos, leftMiddlePos, rightMiddlePos, rightPos;

    private int randomIndex;
    private int randomSide;
    private int randomSize;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBubble());
    }
    IEnumerator SpawnBubble()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            randomSide = Random.Range(0, 3);
            //randomSize = Random.Range(1, 3);

            System.Random random = new System.Random();
            double randomSize = (random.NextDouble() * (1.5 - 0.1) + 0.1);

            spawnedBubble = Instantiate(bubbleReference);

            if (randomSide == 0)
            {
                spawnedBubble.transform.position = (leftPos.position) + new Vector3(Random.Range(0, 4), 0, 0);
                spawnedBubble.transform.localScale = new Vector3((float)randomSize, (float)randomSize, (float)randomSize);
                spawnedBubble.transform.SetParent(GameObject.Find("Canvas2").transform);
            }
            else if(randomSide == 1)
            {
                spawnedBubble.transform.position = leftMiddlePos.position;
                spawnedBubble.transform.localScale = new Vector3((float)randomSize, (float)randomSize, (float)randomSize);
                spawnedBubble.transform.SetParent(GameObject.Find("Canvas2").transform);
            }
            else if( randomSide == 2)
            {
                spawnedBubble.transform.position = rightMiddlePos.position;
                spawnedBubble.transform.localScale = new Vector3((float)randomSize, (float)randomSize, (float)randomSize);
                spawnedBubble.transform.SetParent(GameObject.Find("Canvas2").transform);
            }
            else
            {
                spawnedBubble.transform.position = rightPos.position;
                spawnedBubble.transform.localScale = new Vector3((float)randomSize, (float)randomSize, (float)randomSize);
                spawnedBubble.transform.SetParent(GameObject.Find("Canvas2").transform);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
