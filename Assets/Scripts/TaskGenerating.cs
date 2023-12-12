
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
            GlobalVariables.lvl = 2;
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
        Hearts hearts = new Hearts();
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

            //sumažina gyvybes
            hearts.decrease();
        }
    }
    public void CheckAnswerForGame2()
    {
        Hearts hearts = new Hearts();
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

            hearts.decrease();
        }
    }
    public void CheckAnswerForGame34()
    {
        Hearts hearts = new Hearts();
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

            ////padidina burbulu kieki zaidime
            //if ((newScore % 50 == 0 && (3 + newScore / 50) < 11) && GlobalVariables.difficulty < 9)
            //{
            //    GlobalVariables.difficulty = 3 + newScore / 50;
            //}

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


            hearts.decrease();
        }
    }
    
    public void Game1()
    {
        ScoreField = GameObject.Find("Score");
        Text score = ScoreField.GetComponent<Text>();

        int Score = Convert.ToInt32(score.text);

            // // generuojamas uzdavinio skaičia

        num1 = Random.Range(1, GlobalVariables.range);
        num2 = Random.Range(1, GlobalVariables.range);


        // daugybos ir dalybos pridejima saukštesniame lygyje
        if(GlobalVariables.level > 1)
        {
            randomSign = Random.Range(0, 4);
        } else 
        {
            randomSign = Random.Range(0, 2);
        }


        switch (randomSign)
        {
            case 0:
                
                GlobalVariables.answer = num1 + num2;
                t = $"{num1} + {num2}";
                break;
            case 1:
                while(num1 - num2 < 0)
                {
                    num1 = Random.Range(1, GlobalVariables.range);
                    num2 = Random.Range(1, GlobalVariables.range);
                }
                GlobalVariables.answer = num1 - num2;
                t = $"{num1} - {num2}";
                break;
            case 2:
                //daugybos skaičių rėžiai
                int multiplyRange = 0;
                if(GlobalVariables.level == 2)
                {
                    multiplyRange = 5;
                } else if(GlobalVariables.level == 3)
                {
                    multiplyRange = 10;
                }
                else if (GlobalVariables.level == 4)
                {
                    multiplyRange = 10000;
                }


                do
                {
                    //// IŠ VIENAŽENKLIO SKAČIAUS !
                    num1 = Random.Range(1, multiplyRange);
                    num2 = Random.Range(1, 10);
                    GlobalVariables.answer = (double)num1 / num2;
                } while (GlobalVariables.answer % 2 != 0 || (int)GlobalVariables.answer == 0);
                t = $"{num1} / {num2}";
                break;
            case 3:
                do
                {
                    num1 = Random.Range(1, GlobalVariables.range);
                    num2 = Random.Range(1, GlobalVariables.range);
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
        num1 = Random.Range(1, GlobalVariables.range);
        
        randomSign = Random.Range(0, 3);
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

            randomCondition = Random.Range(0, 12);

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
        else if(GlobalVariables.level == 3 || GlobalVariables.level == 4)
        {
            int number = Random.Range(0, 3);
     
            int flo = Random.Range(0, 10);
            int first;
            int second;
            int third;
            int fourth;

            switch (number)
            {
                case 0:
                    first = Random.Range(1, 10);
                    second = Random.Range(1, 10);
                    while ((second + first) > flo)
                    {
                        first = Random.Range(1, 10);
                        second = Random.Range(1, 10);
                        flo = Random.Range(0, 10);
                    }

                    t = first.ToString() + "/" + flo.ToString() + "+" + second.ToString() + "/" + flo.ToString();
                    GlobalVariables.answer2 = (first + second).ToString() + "/" + flo.ToString();
                    break;
                case 1:
                    first = Random.Range(1, 10);
                    second = Random.Range(1, 10);
                    third = Random.Range(1, 10);
                    while ((second + first + third) > flo)
                    {
                        first = Random.Range(1, 10);
                        second = Random.Range(1, 10);
                        third = Random.Range(1, 10);
                        flo = Random.Range(0, 10);

                    }

                    t = first.ToString() + "/" + flo.ToString() + "+"
                        + second.ToString() + "/" + flo.ToString() + "+"
                        + third.ToString() + "/" + flo.ToString();
                    GlobalVariables.answer2 = (first + second + third).ToString() + "/" + flo.ToString();
                    break;
                case 2:
                    first = Random.Range(1, 10);
                    second = Random.Range(1, 10);
                    third = Random.Range(1, 10);
                    fourth = Random.Range(1, 10);
                    while ((second + first + third + fourth) > flo)
                    {
                        first = Random.Range(1, 10);
                        second = Random.Range(1, 10);
                        third = Random.Range(1, 10);
                        fourth = Random.Range(1, 10);
                        flo = Random.Range(0, 10);
                    }

                    t = first.ToString() + "/" + flo.ToString() + "+"
                        + second.ToString() + "/" + flo.ToString() + "+"
                        + third.ToString() + "/" + flo.ToString() + "+"
                        + fourth.ToString() + "/" + flo.ToString();
                    GlobalVariables.answer2 = (first + second + third + fourth).ToString() + "/" + flo.ToString();
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

        GlobalVariables.randomUnit = 0;
        // cm - m/cnt - eur/ kg


        // nustatymas lygiams
        if (GlobalVariables.level == 1)
        {
            GlobalVariables.randomUnit = Random.Range(0, 3);
        }
        else if (GlobalVariables.level == 2)
        {
            GlobalVariables.randomUnit = Random.Range(0, 5);
        } 
        else if(GlobalVariables.level == 3 || GlobalVariables.level == 4)
        {
            GlobalVariables.randomUnit = Random.Range(0, 7);
        }



        // Užduočių formatai
        // naujai užduočiai pridėti prie matavimo vienetu
        switch (GlobalVariables.randomUnit)
        {
            // centimetrai ir metrai
            case 0:
                num1 = Random.Range(0, 10);
                num2 = Random.Range(0, 10);
                int sal = Random.Range(0, 2);

                switch (sal)
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

                while (tskc < 3)
                {
                    sal = Random.Range(0, 1);

                    if (tskc < 2)
                    {
                        if (sal == 0)
                        {
                            num1 = Random.Range(0, 6);
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
                    }
                    else
                    {
                        if (sal == 0)
                        {
                            num1 = Random.Range(0, 6);
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
                }
                else
                {
                    cntCorrected = cnt.ToString();
                }
                if (eur != 0)
                {
                    GlobalVariables.answer2 = eur.ToString() + "." + (cnt % 100).ToString() + "eur";
                }
                else
                {
                    GlobalVariables.answer2 = eur.ToString() + "." + cntCorrected + "eur";
                }

                break;
                // kilogramai
            case 2:
                t = "";
                int kg;
                tskc = 0;
                int kgansw = 0;
                while (tskc < 3)
                {
                    if (tskc < 2)
                    {
                        kg = Random.Range(1, 10);
                        kgansw += kg;
                        t = t + kg.ToString() + "kg. + ";
                        tskc++;
                    }
                    else
                    {
                        kg = Random.Range(1, 10);
                        kgansw += kg;
                        tskc++;
                        t = t + kg.ToString() + "kg. = ?";
                    }
                }

                GlobalVariables.answer2 = kgansw.ToString() + "kg";

                break;
            case 3:

                GlobalVariables.temp = Random.Range(0, 3);
                num1 = 0;

                // x < 10 — salta
                // 10 < x < 30 – silta
                // 30 < x — karsta
                switch (GlobalVariables.temp)
                {
                    case 0:
                        num1 = Random.Range(-20, 10);

                        t = "Šalta = ?";
                        GlobalVariables.answer2 = num1.ToString() + "°C";
                        break;
                    case 1:
                        num1 = Random.Range(10, 30);
                        t = "Šilta = ?";
                        GlobalVariables.answer2 = num1.ToString() + "°C";
                        break;
                    case 2:
                        num1 = Random.Range(30, 50);
                        t = "Karšta = ?";
                        GlobalVariables.answer2 = num1.ToString() + "°C";
                        break;
                }

                break;
            // litrai
            case 4:
                t = "";
                int l;
                tskc = 0;
                int lansw = 0;
                while (tskc < 3)
                {
                    if (tskc < 2)
                    {
                        l = Random.Range(1, 10);
                        lansw += l;
                        t = t + l.ToString() + "l. + ";
                        tskc++;
                    }
                    else
                    {
                        l = Random.Range(1, 10);
                        lansw += l;
                        tskc++;
                        t = t + l.ToString() + "l. = ?";
                    }
                }

                GlobalVariables.answer2 = lansw.ToString() + "l";

                break;
                //gramai kilogramai
            case 5:
                t = "";
                kg = Random.Range(1, 10);
                int g = Random.Range(1, 1000);
                string gansw = kg.ToString() + g.ToString() + "g";

                if (g < 100)
                {
                    GlobalVariables.answer2 = kg.ToString() + "0" + g.ToString() + "g";
                }
                else
                {
                    GlobalVariables.answer2 = kg.ToString() + g.ToString() + "g";
                }
                
                t = kg + " kg." + g + " g. = ";

                break;
            // km ir m
            case 6:
                t = "";
                int km  = Random.Range(1, 10);
                int m = Random.Range(1, 1000);

                if (m < 100)
                {
                    GlobalVariables.answer2 = km.ToString() + "0" + m.ToString() + "m";
                }
                else
                {
                    GlobalVariables.answer2 = km.ToString() + m.ToString() + "m";
                }
                t = km + " km." + m + " m. = ";

                break;

        }

        Debug.Log("answer2 == " + GlobalVariables.answer2);
        // isvedamas uzdavinys i ekrana
        TaskField = GameObject.Find("Task");
        Text task = TaskField.GetComponent<Text>();
        task.text = t;

    }
}

