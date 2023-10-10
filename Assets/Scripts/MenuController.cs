using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// PERVADINTI BOOBLE labiau specifiskai 

public class MenuController : MonoBehaviour
{
    private Animator anim;
    private GameObject Bobble;

    public void Play()
    {
        //Bobble = GameObject.Find("Bobble");

        //anim = Bobble.GetComponent<Animator>();
        //anim.speed = 0.6f;
        //anim.Play("Explode");

        SceneManager.LoadScene("GameScene");
    }
}
