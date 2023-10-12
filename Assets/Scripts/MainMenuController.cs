using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private Animator anim;
    private GameObject PlayButton;

    public void PlayGame()
    {

        PlayButton = GameObject.Find("PlayButton");

        anim = PlayButton.GetComponent<Animator>();

        anim.SetBool("explode", true);
        //anim.Play("Explode");
    }
    public void Restart()
    {
        PlayButton = GameObject.Find("RestartButton");

        anim = PlayButton.GetComponent<Animator>();

        anim.SetBool("explode", true);
    }
    public void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
