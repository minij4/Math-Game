
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

    
    private int randomSign;

    private string t;


    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.isAnswer = false;
        Debug.Log("Started");
        NewTask();
    }
    public void CheckAnswer()
    {
        // pasirinktas atsakymo onjektas
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Text userAnswer = button.GetComponent<Text>();


        //Debug.Log(userAnswer.text.ToString());

        // tikrina ar teisingas atsakymas
        //if (answer == Convert.ToInt32(userAnswer.text))
        //{
        //    Debug.Log("Atsakymas teisingas");
        //    isAnswer = false;
        //}

        NewTask();
    }
    public void NewTask()
    {
        // generuojamas uzdavinys
        num1 = UnityEngine.Random.Range(1, 50);
        num2 = UnityEngine.Random.Range(1, 50);
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
                    num1 = UnityEngine.Random.Range(1, 50);
                    num2 = UnityEngine.Random.Range(1, 50);
                    GlobalVariables.answer = (double)num1 / num2;
                } while (GlobalVariables.answer % 2 != 0 || (int)GlobalVariables.answer == 0);
                t = $"{num1} / {num2}";
                break;
            case 3:
                do
                {
                    num1 = UnityEngine.Random.Range(1, 50);
                    num2 = UnityEngine.Random.Range(1, 50);
                    GlobalVariables.answer = num1 * num2;
                } while (GlobalVariables.answer > 100);
                t = $"{num1} x {num2}";
                break;
        }

        Debug.Log(GlobalVariables.answer);

        // isvedamas uzdavinys i ekrana
        TaskField = GameObject.Find("Task");
        Text task = TaskField.GetComponent<Text>();
        task.text = t;

    }
}
