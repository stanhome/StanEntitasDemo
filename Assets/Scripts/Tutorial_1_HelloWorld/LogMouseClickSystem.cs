using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LogMouseClickSystem : IExecuteSystem
{
	readonly GameContext _context;

	public LogMouseClickSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Execute()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_context.CreateEntity().AddDebugMessage("Left Mouse Button Clicked", "mouse", 3);
		}

		if (Input.GetMouseButtonDown(1))
		{
			_context.CreateEntity().AddDebugMessage("Right Mouse Button Clicked", "mouse", 3);
		}
	}
}
