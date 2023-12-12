using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestSuit
{

    
    [UnityTest, Order(0)]
    public IEnumerator TestMainScene()
    {
        // loading main scene
        SceneManager.LoadScene("MainScene");

        yield return null;
        // button reference
        var button = GameObject.Find("PlayButton").GetComponent<Button>();

        yield return new WaitForSeconds(5.0f);

        // Simulate a button click
        button.onClick.Invoke();
        //yield return null;
        yield return new WaitForSeconds(5.0f);

        // checking if loaded scene is correct
        Scene loadedScene = SceneManager.GetSceneByBuildIndex(1);
        Assert.IsTrue(loadedScene.isLoaded);
    }
    [UnityTest, Order(1)]
    public IEnumerator TestLevelSelect()
    {
        for(int i = 1; i <= 4; i++)
        {
            SceneManager.LoadScene("LevelScene");
            yield return null;
            var button = GameObject.Find("level "+ i.ToString()).GetComponent<Button>();
            Debug.Log(button.name);
            Debug.Log(i);
            yield return new WaitForSeconds(5.0f);

            button.onClick.Invoke();
            yield return new WaitForSeconds(5.0f);
            //yield return null;
            // Simulate a button click

            Assert.AreEqual(GlobalVariables.level, i);
            
        }
        
    }
    [UnityTest, Order(3)]
    public IEnumerator TestGameOverScene()
    {
        GlobalVariables.hearts = 0;
        Hearts hearts = new Hearts();
        // decrasing hearts if have, if not loading gameover scene
        hearts.decrease();
        
        yield return null;
        // button reference
        var button = GameObject.Find("RestartButton").GetComponent<Button>();

        yield return new WaitForSeconds(5.0f);

        // Simulate a button click
        button.onClick.Invoke();
        //yield return null;
        yield return new WaitForSeconds(5.0f);

        // checking if loaded scene is correct
        Scene loadedScene = SceneManager.GetSceneByBuildIndex(1);
        Assert.IsTrue(loadedScene.isLoaded);
    }
    [UnityTest, Order(4)]
    public IEnumerator TestMenuScene()
    {
        for(int i = 1; i < 5; i++)
        {
            // level auto select
            SceneManager.LoadScene("LevelScene");
            yield return null;

            var button = GameObject.Find("level 1").GetComponent<Button>();
            yield return new WaitForSeconds(5.0f);

            button.onClick.Invoke();
            yield return new WaitForSeconds(5.0f);

            // checking if menu scene is loaded
            Scene loadedScene = SceneManager.GetSceneByBuildIndex(2);
            Assert.IsTrue(loadedScene.isLoaded);
            

            yield return new WaitForSeconds(5.0f);
            // game auto select
            var gameButton = GameObject.Find(i.ToString()).GetComponent<Button>();

            yield return new WaitForSeconds(5.0f);

            gameButton.onClick.Invoke();
            yield return new WaitForSeconds(5.0f);

            // cheking if game scene is loaded
            Scene loadedGameScene = SceneManager.GetSceneByBuildIndex(3);
            Assert.IsTrue(loadedGameScene.isLoaded);

        }
    }



    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestSuitWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
