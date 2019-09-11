using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HelloWorldSystem : IInitializeSystem
{
	readonly GameContext _context;

	public HelloWorldSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		_context.CreateEntity().AddDebugMessage("Hello world!", "Hello", 1);
	}
}
