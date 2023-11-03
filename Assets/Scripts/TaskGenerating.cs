
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskGenerating : MonoBehaviour
{

    private GameObject TaskField;
    private GameObject ScoreField;

    private Animator anim;
    private int num1, num2;


    private int randomSign;

    private string t;


    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.isAnswer = false;
        

        Debug.Log("Started");
        GameStart();
        
    }
    public void GameStart()
    {
        int gameId = GameManager.Instance.GameIndex;
        if (gameId == 1)
        {
            Game1();
        } else if(gameId == 2)
        {
            Game2();
        }
    }
    public void DeleteBubbles()
    {
        foreach (GameObject bubble in GlobalVariables.spawnedBubbles.ToArray())
        {
            StopCoroutine(BubbleSpawner.bubbleSpawnCoroutine);

            anim = bubble.GetComponent<Animator>();
            anim.speed = 0.6f;
            anim.Play("Explode");
            Destroy(bubble, 0.6f);



            GlobalVariables.spawnedBubbles.Remove(bubble);
            GlobalVariables.restart = true;
        }
    }
    public void CheckAnswerForGame1()
    {
        // pasirinktas atsakymo onjektas
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Text userAnswer = button.GetComponent<Text>();

        GameObject Spawner = GameObject.Find("Spawner");

        Debug.Log(userAnswer.text.ToString());

        //tikrina ar teisingas atsakymas
        if (GlobalVariables.answer == Convert.ToInt32(userAnswer.text))
        {
            Debug.Log("Atsakymas teisingas");
            GlobalVariables.isAnswer = false;

            //BubbleSpawner spawn = new BubbleSpawner();
            //spawn.Start();

            Spawner.SetActive(false);
            Spawner.SetActive(true);

            //score counting
            ScoreField = GameObject.Find("Score");
            Text score = ScoreField.GetComponent<Text>();

            int newScore = Convert.ToInt32(score.text) + 10;

            score.text = newScore.ToString();

            //padidina burbulu kieki zaidime
            if (newScore % 50 == 0 && (3 + newScore / 50) < 11)
            {
                GlobalVariables.difficulty = 3 + newScore / 50;
            }

            DeleteBubbles();
            GameStart();
        } else
        {
            Debug.Log("Atsakymas neteisingas");
            GlobalVariables.isAnswer = false;

            //BubbleSpawner spawn = new BubbleSpawner();
            Spawner.SetActive(false);
            Spawner.SetActive(true);

            DeleteBubbles();
            GameStart();


            //hearts
            if (GlobalVariables.hearts > 1)
            {
                GlobalVariables.hearts--;
            } else
            {
                GlobalVariables.difficulty = 3;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    public void CheckAnswerForGame2()
    {
        // pasirinktas atsakymo onjektas
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Text userAnswer = button.GetComponent<Text>();

        GameObject Spawner = GameObject.Find("Spawner");

        Debug.Log(userAnswer.text.ToString());

        //tikrina ar teisingas atsakymas
        if (GlobalVariables.sign == 0 && GlobalVariables.answer > Convert.ToInt32(userAnswer.text) ||
            GlobalVariables.sign == 1 && GlobalVariables.answer < Convert.ToInt32(userAnswer.text) ||
            GlobalVariables.sign == 2 && GlobalVariables.answer == Convert.ToInt32(userAnswer.text))
        {
            Debug.Log("Atsakymas teisingas");
            GlobalVariables.isAnswer = false;

            //BubbleSpawner spawn = new BubbleSpawner();
            //spawn.Start();

            Spawner.SetActive(false);
            Spawner.SetActive(true);

            //score counting
            ScoreField = GameObject.Find("Score");
            Text score = ScoreField.GetComponent<Text>();

            int newScore = Convert.ToInt32(score.text) + 10;

            score.text = newScore.ToString();

            DeleteBubbles();
            GameStart();
        }
        else
        {
            Debug.Log("Atsakymas neteisingas");
            GlobalVariables.isAnswer = false;

            //BubbleSpawner spawn = new BubbleSpawner();
            Spawner.SetActive(false);
            Spawner.SetActive(true);

            DeleteBubbles();
            GameStart();


            //hearts
            if (GlobalVariables.hearts > 1)
            {
                GlobalVariables.hearts--;
            }
            else
            {
                GlobalVariables.difficulty = 3;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    public void Game1()
    {
    
            ScoreField = GameObject.Find("Score");
            Text score = ScoreField.GetComponent<Text>();

            int Score = Convert.ToInt32(score.text);

            // // generuojamas uzdavinys
            num1 = UnityEngine.Random.Range(1, GlobalVariables.range);
            num2 = UnityEngine.Random.Range(1, GlobalVariables.range);
            randomSign = UnityEngine.Random.Range(0, 4);

            switch (randomSign)
            {
                case 0:
                    GlobalVariables.answer = num1 + num2;
                    t = $"{num1} + {num2}";
                    break;
                case 1:
                    GlobalVariables.answer = num1 - num2;
                    t = $"{num1} - {num2}";
                    break;
                case 2:
                    do
                    {
                        num1 = UnityEngine.Random.Range(1, GlobalVariables.range);
                        num2 = UnityEngine.Random.Range(1, GlobalVariables.range);
                        GlobalVariables.answer = (double)num1 / num2;
                    } while (GlobalVariables.answer % 2 != 0 || (int)GlobalVariables.answer == 0);
                    t = $"{num1} / {num2}";
                    break;
                case 3:
                    do
                    {
                        num1 = UnityEngine.Random.Range(1, GlobalVariables.range);
                        num2 = UnityEngine.Random.Range(1, GlobalVariables.range);
                        GlobalVariables.answer = num1 * num2;
                    } while (GlobalVariables.answer > 100);
                    t = $"{num1} x {num2}";
                    break;
            }

            Debug.Log(GlobalVariables.answer);
            Debug.Log(GameManager.Instance.GameIndex);
        
        

        // isvedamas uzdavinys i ekrana
        TaskField = GameObject.Find("Task");
        Text task = TaskField.GetComponent<Text>();
        task.text = t;

    }
    public void Game2()
    {
        // // generuojamas uzdavinys
        num1 = UnityEngine.Random.Range(1, GlobalVariables.range);
        
        randomSign = UnityEngine.Random.Range(0, 3);
        GlobalVariables.answer = num1;
        switch (randomSign)
        {
            case 0:
                
                t = $"{num1} > ?";
                break;
            case 1:
                t = $"{num1} < ?";
                break;
            case 2:
                t = $"{num1} = ?";

                break;   
        }
        GlobalVariables.sign = randomSign;

        Debug.Log(GlobalVariables.answer);
        Debug.Log(GameManager.Instance.GameIndex);



        // isvedamas uzdavinys i ekrana
        TaskField = GameObject.Find("Task");
        Text task = TaskField.GetComponent<Text>();
        task.text = t;

    }
}
