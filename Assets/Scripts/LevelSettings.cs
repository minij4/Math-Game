using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
public class LevelSettings : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Button;
    private Animator anim;

    // 
    public void PlayGame()
    {
        anim.SetBool("Explode", true);
    }
    public void load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
    public void level1()
    {
        
        Button = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        anim = Button.GetComponent<Animator>();
        GlobalVariables.range = 100;
        PlayGame();

    }
    public void level2()
    {
        Button = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);

        anim = Button.GetComponent<Animator>();
        GlobalVariables.range = 1000;
        PlayGame();
    }
    public void level3()
    {
        Button = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);

        anim = Button.GetComponent<Animator>();
        GlobalVariables.range = 5000;
        PlayGame();
    }
    public void level4()
    {
        Button = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);

        anim = Button.GetComponent<Animator>();
        GlobalVariables.range = 10000;
        PlayGame();
    }
}
