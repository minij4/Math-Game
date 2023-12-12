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
        if (GlobalVariables.level == 1)
        {
            //isjungia sunkesnius zaidimus /// pirmai klasei
            GameObject.Find("3").SetActive(false);
        }
    }
    public void Play()
    {

        int selectedGame =
          int.Parse(EventSystem.current.currentSelectedGameObject.name);

        GameManager.Instance.GameIndex = selectedGame;
        GlobalVariables.gameId = selectedGame;

        Debug.Log(selectedGame);

        Menu = GameObject.Find(selectedGame.ToString());
       
        bubble = Menu.GetComponent<Animator>();
        
        bubble.SetBool("Explode", true);
        //anim.Play("Explode");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //StartCoroutine(LoadLevel());
    }

    //IEnumerator LoadLevel()
    //{
    //    transition.SetTrigger("Start");

    //    yield return new WaitForSeconds(1);

    //    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    //}
}
