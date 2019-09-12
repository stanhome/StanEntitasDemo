using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTutorial3 : MonoBehaviour
{
	Systems _systems;

    // Start is called before the first frame update
    void Start()
    {
		Contexts contexts = Contexts.sharedInstance;
		_systems = new Feature("Tutorial3- multi destroy system")
			.Add(new MultiAddViewSystem(contexts))
			.Add(new MultiDestroySystem(contexts));
    }

    // Update is called once per frame
    void Update()
    {
		_systems.Execute();
		_systems.Cleanup();
    }
}
