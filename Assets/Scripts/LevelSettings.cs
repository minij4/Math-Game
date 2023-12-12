using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSettings : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    // 
    public void PlayGame()
    {
        anim.SetBool("Explode", true);
    }
    public void load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void level1()
    {
        anim = GameObject.Find("level 1")?.GetComponent<Animator>();

        GlobalVariables.range = 9;
        GlobalVariables.level = 1;

        PlayGame();

    }
    public void level2()
    {
        anim = GameObject.Find("level 2")?.GetComponent<Animator>();

        GlobalVariables.range = 100;
        GlobalVariables.level = 2;
        PlayGame();
    }
    public void level3()
    {
        anim = GameObject.Find("level 3")?.GetComponent<Animator>();

        GlobalVariables.range = 1000;
        GlobalVariables.level = 3;
        PlayGame();
    }
    public void level4()
    {
        //anim = GameObject.Find(EventSystem.current.currentSelectedGameObject.name)?.GetComponent<Animator>();
        anim = GameObject.Find("level 4")?.GetComponent<Animator>();
        GlobalVariables.range = 10000;
        GlobalVariables.level = 4 ;
        PlayGame();
    }
}
