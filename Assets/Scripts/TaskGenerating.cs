
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskGenerating : MonoBehaviour
{
    private GameObject TaskField;
   

    private int num1, num2;
    private double answer;
    private int randomSign;

    private string t;


    // Start is called before the first frame update
    void Start()
    {
        NewTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewTask()
    {
        num1 = UnityEngine.Random.Range(1, 50);
        num2 = UnityEngine.Random.Range(1, 50);
        randomSign = UnityEngine.Random.Range(0, 4);

        switch (randomSign)
        {
            case 0:
                answer = num1 + num2;
                t = $"{num1} + {num2}";
                break;
            case 1:
                answer = num1 - num2;
                t = $"{num1} - {num2}";
                break;
            case 2:
                do
                {
                    num1 = UnityEngine.Random.Range(1, 50);
                    num2 = UnityEngine.Random.Range(1, 50);
                    answer = (double)num1 / num2;
                } while (answer % 2 != 0 || (int)answer == 0);
                t = $"{num1} / {num2}";
                break;
            case 3:
                do
                {
                    num1 = UnityEngine.Random.Range(1, 50);
                    num2 = UnityEngine.Random.Range(1, 50);
                    answer = num1 * num2;
                } while (answer > 100);
                t = $"{num1} x {num2}";
                break;
        }

        Debug.Log(answer);

        TaskField = GameObject.Find("Task");

        Text task = TaskField.GetComponent<Text>();
        task.text = t;
    }
}
