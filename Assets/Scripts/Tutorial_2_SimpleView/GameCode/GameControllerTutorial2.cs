using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameControllerTutorial2 : MonoBehaviour
{
	private Systems _systems;
	private Contexts _contexts;

	private void Start()
	{
		_contexts = Contexts.sharedInstance;
		_systems = CreateSystems(_contexts);
		_systems.Initialize();
	}

	private void Update()
	{
		_systems.Execute();
		_systems.Cleanup();
	}

	private static Systems CreateSystems(Contexts contexts)
	{
		return new Feature("Systems Tutorial2")
			.Add(new InputSystems(contexts))
			.Add(new MovementSystems(contexts))
			.Add(new ViewSystems(contexts));
	}
}
