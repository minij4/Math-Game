using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static double answer;
    // answe2 for fractions
    public static string answer2;
    

    public static bool isAnswer;

    public static bool restart;
    
    public static int hearts;
    
    // spawned bubble list
    public static List<GameObject> spawnedBubbles;

    // bubble amount
    public static int difficulty = 3;
    
    
    public static int gameId = 1;

    //forGame2
    public static int sign = 0;


    // LEVEL SETTINGS 
    public static int range = 25;
    //lygio nustatymas pagal surinktus taškus
    public static int lvl = 1;
    //klases
    public static int level = 1;
}
