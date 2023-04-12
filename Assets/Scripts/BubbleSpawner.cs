
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

    private int randomAnswerIndex;
    private int randomAnswer;
    private int[] answers;

    private int difficulty;




    // Start is called before the first frame update
    void Start()
    {
        difficulty = 3;
        answers = new int[difficulty];
        generateAnswers();
        StartCoroutine(SpawnBubbles());
    }

    public void generateAnswers()
    {
        for (int i = 0; i < difficulty; i++)
        {
            //tikrinimas ar yra ekrane teisingas atsakymas
            //generuojamas atsitiktinis atsakymu masyvas
            if (GlobalVariables.isAnswer)
            {
                answers[i] = Random.Range(0, 100);
            }
            else
            {
                //Debug.Log(answer);
                answers[i] = (int)GlobalVariables.answer;
                
               GlobalVariables.isAnswer = true;
            }
        }
    }
    IEnumerator SpawnBubbles()
    {
        for (int i = 0; i < difficulty; i++)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, bubbleReference.Length);
            randomSide = Random.Range(0, 2);


            //randomAnswerIndex = Random.Range(0, difficulty);
            randomAnswer = answers[i];



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


            myButton.onClick.AddListener((UnityEngine.Events.UnityAction)CheckAnswer);
        }
    }
}
