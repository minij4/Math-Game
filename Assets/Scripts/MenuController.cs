using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        string name = EventSystem.current.currentSelectedGameObject.name;
        Menu = GameObject.Find(name);

        anim = Menu.GetComponent<Animator>();

        anim.SetBool("explode", true);
        //anim.Play("Explode");
    }

    public void LoadGame1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void LoadGame2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game2Scene");
    }
    public void LoadGame3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
