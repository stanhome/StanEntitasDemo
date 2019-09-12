using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// make sure the position of GameObject is the same as the value of PositionComponent.
/// reacts to PositionComponent
/// </summary>
public class RenderPositionSystem : ReactiveSystem<GameEntity>
{
	public RenderPositionSystem(Contexts contexts) : base(contexts.game)
	{ }

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity e in entities)
		{
			e.view.gameObject.transform.position = e.position.value;
		}
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasPosition && entity.hasView;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Position);
	}
}
