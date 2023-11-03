using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update
    private int _gameIndex;
    public int GameIndex
    {
        get { return _gameIndex; }
        set { _gameIndex = value; }
    }

    public void Awake()
    {
        
        if(Instance == null) { 
            Instance= this;
            DontDestroyOnLoad(gameObject);

        } else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
