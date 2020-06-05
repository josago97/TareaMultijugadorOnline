﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public event Action OnLevelLoaded;

    private void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene(int buildIndex)
    {
        LoadScene(SceneManager.GetSceneByBuildIndex(buildIndex));
    }

    public void LoadScene(Scene scene)
    {
        Load(scene.name);
    }

    public void LoadScene(string sceneName)
    {
        Load(sceneName);
    }

    public void Reload()
    {
        LoadScene(SceneManager.GetActiveScene());
    }

    private void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //TODO: Para la pantalla de carga
    private void LoadAsync()
    {

    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnLevelLoaded?.Invoke();
    }
}