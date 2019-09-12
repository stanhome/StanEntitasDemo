using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RenderScaleSystem : ReactiveSystem<GameEntity>
{
	public RenderScaleSystem(Contexts contexts) : base(contexts.game)
	{ }

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity e in entities)
		{
			e.view.gameObject.transform.localScale = new Vector3(e.scale.value, e.scale.value);
		}
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasScale && entity.hasView;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Scale);
	}
}
