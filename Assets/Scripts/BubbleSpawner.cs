
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawner : TaskGenerating
{
    public static IEnumerator bubbleSpawnCoroutine;

    [SerializeField]
    private GameObject[] bubbleReference;
 
 

    private GameObject spawnedBubble;

    [SerializeField]
    private Transform rightPos, leftPos;

    private int randomIndex;
    private int randomSide;

    private string randomAnswer;

    private int[] answers;
    private string[] answers2;
   

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.spawnedBubbles = new List<GameObject>();
        GlobalVariables.restart = false;

        answers = new int[GlobalVariables.difficulty];
        answers2 = new string[GlobalVariables.difficulty];

        int gameId = GameManager.Instance.GameIndex;


        if (gameId == 1)
        {
            generateAnswersForGame1();
        } else if(gameId == 2)
        {
            generateAnswersForGame2();
        } else if(gameId == 3)
        {
            generateAnswersForGame3();
        }

        bubbleSpawnCoroutine = SpawnBubbles();

        StartCoroutine(bubbleSpawnCoroutine);
    }
    void Update()
    {
        if (GlobalVariables.restart)
        {
            Start();
        }

    }

    public void generateAnswersForGame1()
    {
        for (int i = 0; i < GlobalVariables.difficulty; i++)
        {
            //tikrinimas ar yra ekrane teisingas atsakymas
            //generuojamas atsitiktinis atsakymu masyvas
            if (GlobalVariables.isAnswer)
            {
                int diff = Random.Range(0, 10);
                int sign = Random.Range(0, 2);
                int answ = 0;

                if (sign == 0)
                {
                    answ = (int)GlobalVariables.answer + diff;
                }
                else if (sign == 1)
                {
                    answ = (int)GlobalVariables.answer - diff;
                } 
                // tikrinimas kad nesikartotu vienodi atsakymai
                while (answers.Contains(answ))
                {
                    diff = Random.Range(0, 10);
                    sign = Random.Range(0, 2);

                    if (sign == 0)
                    {
                        answ = (int)GlobalVariables.answer + diff;
                    }
                    else if (sign == 1)
                    {
                        answ = (int)GlobalVariables.answer - diff;
                    }
                }
                answers[i] = answ;

            }
            else
            {
                //Debug.Log(answer);
                answers[i] = (int)GlobalVariables.answer;
                
               GlobalVariables.isAnswer = true;
            }
        }
        shuffle(answers);
    }
    public void generateAnswersForGame2()
    {
        bool biggerAnsw = false;
        bool lowerAnsw = false;
        bool equalAnsw = false;

        for (int i = 0; i < GlobalVariables.difficulty; i++)
        {
            //tikrinimas ar yra ekrane teisingas atsakymas
            //generuojamas atsitiktinis atsakymu masyvas
            if (GlobalVariables.isAnswer)
            {
                int diff = Random.Range(0, 10);
                int sign = GlobalVariables.sign;
                int answ = 0;

                if (lowerAnsw == false)
                {
                    answ = (int)GlobalVariables.answer - diff;
                    lowerAnsw = true;
                }
                else if (biggerAnsw == false)
                {
                    answ = (int)GlobalVariables.answer + diff;
                    biggerAnsw = true;
                } else if(equalAnsw == false)
                {
                    answ = (int)GlobalVariables.answer;
                    equalAnsw = true;
                }
                // tikrinimas kad nesikartotu vienodi atsakymai
                while (answers.Contains(answ))
                {
                    diff = Random.Range(0, 10);
                    sign = Random.Range(0, 2);

                    if (sign == 0)
                    {
                        answ = (int)GlobalVariables.answer + diff;
                    }
                    else if (sign == 1)
                    {
                        answ = (int)GlobalVariables.answer - diff;
                    }
                }
                answers[i] = answ;

            }
            else
            {
                //Debug.Log(answer);
                answers[i] = (int)GlobalVariables.answer;

                GlobalVariables.isAnswer = true;
            }
        }
        shuffle(answers);
    }
    public void generateAnswersForGame3()
    {
        Debug.Log("generating answers");
        for (int i = 0; i < GlobalVariables.difficulty; i++)
        {
            string answ2="";
            //tikrinimas ar yra ekrane teisingas atsakymas
            //generuojamas atsitiktinis atsakymu masyvas
            if (GlobalVariables.isAnswer)
            {
                int rand = Random.Range(0, 10);

                switch(rand)
                {
                    case 0:
                        answ2 = "1/2";
                    break;
                    case 1:
                        answ2 = "1/3";
                        break;
                    case 2:
                        answ2 = "1/4";
                        break;
                    case 3:
                        answ2 = "1";
                        break;
                    case 4:
                        answ2 = "1/5";
                        break;
                    case 5:
                        answ2 = "1/6";
                        break;
                    case 6:
                        answ2 = "1/7";
                        break;
                    case 7:
                        answ2 = "1/8";
                        break;
                    case 8:
                        answ2 = "1/9";
                        break;
                    case 9:
                        answ2 = "1/10";
                        break;
                }
                while (answers2.Contains(answ2))
                {
                    rand = Random.Range(0, 10);
                    switch (rand)
                    {
                        case 0:
                            answ2 = "1/2";
                            break;
                        case 1:
                            answ2 = "1/3";
                            break;
                        case 2:
                            answ2 = "1/4";
                            break;
                        case 3:
                            answ2 = "1";
                            break;
                        case 4:
                            answ2 = "1/5";
                            break;
                        case 5:
                            answ2 = "1/6";
                            break;
                        case 6:
                            answ2 = "1/7";
                            break;
                        case 7:
                            answ2 = "1/8";
                            break;
                        case 8:
                            answ2 = "1/9";
                            break;
                        case 9:
                            answ2 = "1/10";
                            break;
                    }
                }
                answers2[i] = answ2;
            }
            else
            {
                
                answers2[i] = GlobalVariables.answer2;
                
                GlobalVariables.isAnswer = true;
            }
        }
        //shuffle(answers);
    }
    public void shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            var j = Mathf.FloorToInt(Random.value * (i + 1));
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
    IEnumerator SpawnBubbles()
    {
        Debug.Log("SpawnBubbles");
        for (int i = 0; i < GlobalVariables.difficulty; i++)
        {
            yield return 
             
            randomIndex = Random.Range(0, bubbleReference.Length);
            randomSide = Random.Range(0, 2);


            if (GlobalVariables.gameId == 3)
            {
                randomAnswer = answers2[i];
                
            } else
            {
                randomAnswer = answers[i].ToString();
            }


            // spawnina burbulus
            spawnedBubble = Instantiate(bubbleReference[randomIndex]);
            spawnedBubble.transform.SetParent(GameObject.Find("Canvas").transform);
            spawnedBubble.transform.position = new Vector3(0, 0, 0);

            // patalpina visus burbulus i list
            GlobalVariables.spawnedBubbles.Add(spawnedBubble);

            // left side
            if (randomSide == 0)
            {
                GameObject answerComponent = spawnedBubble.transform.GetChild(0).gameObject;

                Text answer = answerComponent.GetComponent<Text>();
                answer.text = randomAnswer;

                spawnedBubble.transform.position = new Vector3(leftPos.position.x, leftPos.position.y, leftPos.position.z);
                spawnedBubble.transform.localScale = new Vector3(60, 60, 60);
            }
            else //right side
            {
                GameObject answerComponent = spawnedBubble.transform.GetChild(0).gameObject;

                Text answer = answerComponent.GetComponent<Text>();
                answer.text = randomAnswer;

                spawnedBubble.transform.position = new Vector3(rightPos.position.x, rightPos.position.y, rightPos.position.z);
                spawnedBubble.transform.localScale = new Vector3(60, 60, 60);

            }

            GameObject component = spawnedBubble.transform.GetChild(0).gameObject;
            Button myButton = component.GetComponent<Button>();

            int gameId = GameManager.Instance.GameIndex;
            ///////////////// answer buttonn click
            if (gameId == 1)
            {
                myButton.onClick.AddListener((UnityEngine.Events.UnityAction)CheckAnswerForGame1);
            } else if(gameId == 2)
            {
                myButton.onClick.AddListener((UnityEngine.Events.UnityAction)CheckAnswerForGame2);
            } else if(gameId == 3)
            {
                myButton.onClick.AddListener((UnityEngine.Events.UnityAction)CheckAnswerForGame3);
            }
        }
    }
}
