using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.ComponentModel;
using static UnityEngine.AsyncOperation;

// PERVADINTI BOOBLE labiau specifiskai 

public class MenuController : MonoBehaviour
{
    private Animator anim;
    private GameObject Menu1;

    public void Play()
    {
        
        Menu1 = GameObject.Find("Menu1");

        anim = Menu1.GetComponent<Animator>();
      
        anim.SetBool("explode", true);
        //anim.Play("Explode");
    }

    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
