using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CleanupDebugMessageSystem : ICleanupSystem
{
	readonly GameContext _context;
	readonly IGroup<GameEntity> _debugMessage;


	public CleanupDebugMessageSystem(Contexts contexts)
	{
		_context = contexts.game;
		_debugMessage = _context.GetGroup(GameMatcher.DebugMessage);
	}

	public void Cleanup()
	{
		foreach (var e in _debugMessage.GetEntities())
		{
			e.Destroy();
		}
	}
}
