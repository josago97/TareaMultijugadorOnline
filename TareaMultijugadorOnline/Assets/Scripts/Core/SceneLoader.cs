﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    public event Action OnLevelLoaded;

    private SceneSettings _settings;

    [Inject]
    private void Construct(SceneSettings settings)
    {
        Debug.Log("Puta madre");
        _settings = settings;
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Start()
    {
        GetComponentInParent<ProjectContext>().Container.Inject(this);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    public void LoadLobby()
    {
        Load(_settings.Lobby);
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
