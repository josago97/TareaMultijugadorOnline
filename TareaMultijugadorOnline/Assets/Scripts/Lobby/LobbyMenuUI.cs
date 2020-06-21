﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuUI : UIBase
{
    private SceneLoader _sceneLoader;

    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Exit()
    {
        _sceneLoader.Exit();
    }
}
