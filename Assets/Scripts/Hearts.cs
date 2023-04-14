using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{

    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.hearts = 3;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariables.hearts == 2 ) 
        {
            anim.SetBool("twoH", true);
            anim.SetBool("threeH", false);
        } else if(GlobalVariables.hearts == 1 ) {
            anim.SetBool("oneH", true);
            anim.SetBool("twoH", false);
        } else if(GlobalVariables.hearts == 3) {
            anim.SetBool("threeH", true);
            anim.SetBool("oneH", false);
            anim.SetBool("twoH", false);
        }
    }
}
