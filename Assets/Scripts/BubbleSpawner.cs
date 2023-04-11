
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : TaskGenerating
{
    [SerializeField]
    private GameObject[] bubbleReference;

    private GameObject spawnedBubble;

    [SerializeField]
    private Transform rightPos, leftPos;

    private int randomIndex;
    private int randomSide;

    private int randomAnswer;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, bubbleReference.Length);
            randomSide = Random.Range(0, 2);
            randomAnswer = Random.Range(0, 100);

            spawnedBubble = Instantiate(bubbleReference[randomIndex]);
            spawnedBubble.transform.SetParent(GameObject.Find("Canvas").transform);
            spawnedBubble.transform.position = new Vector3(0, 0, 0);

            // left side
            if (randomSide == 0)
            {
                GameObject answerComponent = spawnedBubble.transform.GetChild(0).gameObject;

                Text answer = answerComponent.GetComponent<Text>();
                answer.text = randomAnswer.ToString();
          
                spawnedBubble.transform.position = new Vector3(leftPos.position.x, leftPos.position.y, leftPos.position.z);
                spawnedBubble.transform.localScale = new Vector3(85, 85, 85);
            }
            else //right side
            {
                GameObject answerComponent = spawnedBubble.transform.GetChild(0).gameObject;

                Text answer = answerComponent.GetComponent<Text>();
                answer.text = randomAnswer.ToString();

                spawnedBubble.transform.position = new Vector3(rightPos.position.x, rightPos.position.y, rightPos.position.z);
                spawnedBubble.transform.localScale = new Vector3(85, 85, 85);
                                
            }

            GameObject component = spawnedBubble.transform.GetChild(0).gameObject;
            Button myButton = component.GetComponent<Button>();

            myButton.onClick.AddListener((UnityEngine.Events.UnityAction) NewTask);
        }
    }
}
