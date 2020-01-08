﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour {

    
	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    /*
    public void ExitGame()
    {

        var result = EditorUtility.DisplayDialog("Exit Current Game", "Are you sure you want to Exit?", "Yes", "No");
        if (result)
        {
            LoadStartScene();
        }
        
    }*/
}
