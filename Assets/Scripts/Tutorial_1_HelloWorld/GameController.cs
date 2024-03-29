﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
	Systems _systems;

    void Start()
    {
		var contexts = Contexts.sharedInstance;
		_systems = new Feature("Systems").Add(new TutorialSystems(contexts));

		// call Initialize() on all of the IInitializeSystems
		_systems.Initialize();
    }

    void Update()
    {
		// call Execute() on all the IExecuteSystems and 
		// ReactiveSystems that were triggered last frame
		_systems.Execute();

		// call cleanup() on all the ICleanupSystems
		_systems.Cleanup();
    }
}
