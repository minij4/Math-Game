using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.ComponentModel;
using UnityEngine.EventSystems;


public class MenuController : MonoBehaviour
{
    private GameObject Menu;
    private Animator bubble;
    

    //private GameObject Crossfade;
    //private Animator transition;

    public void Start()
    {
        if(GlobalVariables.level == 1)
        {
            //isjungia sunkesnius zaidimus nei sudetis ir palyginimai/// pirmai klasei
            for (int i = 3; i <= 4; i++)
            {
                GameObject.Find(i.ToString()).SetActive(false);
            }
        }
    }
    public void Play()
    {
        int selectedGame =
          int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.Instance.GameIndex = selectedGame;
        GlobalVariables.gameId = selectedGame;

        Debug.Log(selectedGame);

        Menu = GameObject.Find(selectedGame.ToString());
        //Crossfade = GameObject.Find("Crossfade");

        //transition = Crossfade.GetComponent<Animator>();
        bubble = Menu.GetComponent<Animator>();
        
        bubble.SetBool("Explode", true);
        //anim.Play("Explode");
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        //StartCoroutine(LoadLevel());
    }

    //IEnumerator LoadLevel()
    //{
    //    transition.SetTrigger("Start");

    //    yield return new WaitForSeconds(1);

    //    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    //}
}
