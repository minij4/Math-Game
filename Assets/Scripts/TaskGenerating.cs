
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

        ScoreField = GameObject.Find("Score");
        Text score = ScoreField.GetComponent<Text>();

        int Score = Convert.ToInt32(score.text);
        // lvl set
        if (Score  >= 250 && Score < 500)
        {
            GlobalVariables.lvl =2;
            // pirmos klasės antro lygio skaičių diapazono nustatymas.
            if (GlobalVariables.level == 1)
            {
                GlobalVariables.range = 20;
            }
        } else
        {
            GlobalVariables.lvl = 3;
        }
        

        if (gameId == 1)
        {
            Game1();
        } else if(gameId == 2)
        {
            Game2();
        } else if(gameId == 3)
        {
            Game3();
        } else if(gameId == 4)
        {
            Game4();
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
    public void CheckAnswerForGame34()
    {
        // pasirinktas atsakymo onjektas
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Text userAnswer = button.GetComponent<Text>();

        GameObject Spawner = GameObject.Find("Spawner");

        Debug.Log(userAnswer.text.ToString());

        //tikrina ar teisingas atsakymas
        if (GlobalVariables.answer2 == userAnswer.text)
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
            if ((newScore % 50 == 0 && (3 + newScore / 50) < 11) && GlobalVariables.difficulty < 9)
            {
                GlobalVariables.difficulty = 3 + newScore / 50;
            }

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
    public void Game3()
    {
        if(GlobalVariables.level == 2)
        {
            int randomCondition;

            randomCondition = UnityEngine.Random.Range(0, 12);

            switch (randomCondition)
            {
                case 0: t = "Pusė = ?";
                    GlobalVariables.answer2 = "1/2";
                    break;
                case 1: t = "Trečdalis = ?";
                    GlobalVariables.answer2 = "1/3";
                    break;
                case 2: t = "Ketvirtadalis = ?";
                    GlobalVariables.answer2 = "1/4";
                    break;
                case 3: t = "Vienetas = ?";
                    GlobalVariables.answer2 = "1";
                    break;
                case 4:
                    t = "Penktadalis = ?";
                    GlobalVariables.answer2 = "1/5";
                    break;
                case 5:
                    t = "Šeštadalis = ?";
                    GlobalVariables.answer2 = "1/6";
                    break;
                case 6:
                    t = "Septintadalis = ?";
                    GlobalVariables.answer2 = "1/7";
                    break;
                case 7:
                    t = "Aštuntadalis = ?";
                    GlobalVariables.answer2 = "1/8";
                    break;
                case 8:
                    t = "Devintadalis = ?";
                    GlobalVariables.answer2 = "1/9";
                    break;
                case 9:
                    t = "Viena dešimtoji = ?";
                    GlobalVariables.answer2 = "1/10";
                    break;
                case 10:
                    t = "1/2 + 1/2 = ?";
                    GlobalVariables.answer2 = "1";
                    break;
                case 11:
                    t = "1/3 + 1/3 + 1/3 = ?";
                    GlobalVariables.answer2 = "1";
                    break;

            }

            Debug.Log("answer2 == " + GlobalVariables.answer2);
        }

        // isvedamas uzdavinys i ekrana
        TaskField = GameObject.Find("Task");
        Text task = TaskField.GetComponent<Text>();
        task.text = t;

    }
    public void Game4()
    {
        if (GlobalVariables.level == 1)
        {
            GlobalVariables.randomUnit = 0;
            // cm - m/cnt - eur/ kg


            GlobalVariables.randomUnit = UnityEngine.Random.Range(0, 3);
            
            

            switch (GlobalVariables.randomUnit)
            {
                // centimetrai ir metrai
                case 0:
                    int num1 = UnityEngine.Random.Range(0, 10);
                    int num2 = UnityEngine.Random.Range(0, 10);
                    int sal = UnityEngine.Random.Range(0, 2);

                    switch(sal)
                    {
                        case 0:
                            t = "Vienas daiktas(x) yra " + num1.ToString() + " cm. ilgio, o kitas(y) " + num2.ToString() + " cm. ilgesnis. y = ?";
                            GlobalVariables.answer2 = (num1 + num2).ToString() + "cm";
                            break;
                        case 1:
                            t = "Vienas daiktas(x) yra " + num1.ToString() + " cm. ilgio, o kitas(y) " + num2.ToString() + " cm. trumpesnis. y = ?";
                            GlobalVariables.answer2 = (num1 - num2).ToString() + "cm";
                            break;
                    }
                    
                    break;

                //eurai
                case 1:
                    t = "";
                    int[] skc = { 1, 2, 5, 10, 20, 50, 100 };

                    int tskc = 0;
                    
                    int cnt = 0;
                    int eur = 0;

                    while(tskc < 3)
                    {
                        sal = UnityEngine.Random.Range(0, 1);

                        if(tskc < 2)
                        {
                            if (sal == 0)
                            {
                                num1 = UnityEngine.Random.Range(0, 6);
                                t = t + skc[num1].ToString() + "cnt. +";
                                cnt += skc[num1];
                                tskc++;
                            }
                            else
                            {
                                t = t + " 1 eur. +";
                                eur += 1;
                                    tskc++;
                            }
                        } else
                        {
                            if (sal == 0)
                            {
                                num1 = UnityEngine.Random.Range(0, 6);
                                t = t + skc[num1].ToString() + " cnt = ?";
                                cnt += skc[num1];
                                tskc++;
                            }
                            else
                            {
                                t = t + " 1 eur = ?";
                                eur += 1;
                                tskc++;
                            }
                        }
                    }

                    eur = eur + cnt / 100;
                    cnt = cnt - eur * 100;
                    string cntCorrected;
                    if (cnt < 10)
                    {
                        cntCorrected = "0" + cnt.ToString();
                    } else
                    {
                        cntCorrected = cnt.ToString();
                    }
                    if (eur != 0)
                    {
                        GlobalVariables.answer2 = eur.ToString() + "." + (cnt % 100).ToString() + "eur";
                    } else
                    {
                        GlobalVariables.answer2 = eur.ToString() + "." + cntCorrected + "eur";
                    }

                    break;

                case 2:
                    t = "";
                    int kg; 
                    tskc = 0;
                    int kgansw = 0;
                    while (tskc < 3)
                    { 
                        if (tskc < 2)
                        {
                            kg = UnityEngine.Random.Range(1, 10);
                            kgansw += kg;
                            t = t + kg.ToString() + "kg. + ";
                            tskc++;
                        }
                        else
                        {
                            kg = UnityEngine.Random.Range(1, 10);
                            kgansw += kg;
                            tskc++;
                            t = t + kg.ToString() + "kg. = ?";
                        }
                    }

                    GlobalVariables.answer2 = kgansw.ToString() + "kg";

                    break;
            }

            Debug.Log("answer2 == " + GlobalVariables.answer2);
        }

        // isvedamas uzdavinys i ekrana
        TaskField = GameObject.Find("Task");
        Text task = TaskField.GetComponent<Text>();
        task.text = t;

    }

}
