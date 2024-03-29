﻿using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RenderDirectionSystem : ReactiveSystem<GameEntity>
{
	//readonly GameContext _context;

	public RenderDirectionSystem(Contexts contexts) : base(contexts.game)
	{ }

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity e in entities)
		{
			float ang = e.direction.value;
			e.view.gameObject.transform.rotation = Quaternion.AngleAxis(ang - 90, Vector3.forward);
		}
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasDirection && entity.hasView;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Direction);
	}
}
