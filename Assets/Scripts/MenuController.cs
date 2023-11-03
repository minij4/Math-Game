using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.ComponentModel;
using UnityEngine.EventSystems;


public class MenuController : MonoBehaviour
{
    private Animator anim;
    private GameObject Menu;

    public void Play()
    {
        int selectedGame =
          int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.Instance.GameIndex = selectedGame;
        GlobalVariables.gameId = selectedGame;

        Debug.Log(selectedGame);

        Menu = GameObject.Find(selectedGame.ToString());

        anim = Menu.GetComponent<Animator>();

        anim.SetBool("explode", true);
        //anim.Play("Explode");
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
