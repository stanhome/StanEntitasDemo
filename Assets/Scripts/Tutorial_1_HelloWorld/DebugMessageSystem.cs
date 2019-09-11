using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public class DebugMessageSystem : ReactiveSystem<GameEntity>
{
	public DebugMessageSystem(Contexts context) : base(context.game)
	{
		
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			Debug.LogFormat("[{0}]{1}", e.debugMessage.tag, e.debugMessage.message);
		}
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasDebugMessage;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.DebugMessage);
	}
}
