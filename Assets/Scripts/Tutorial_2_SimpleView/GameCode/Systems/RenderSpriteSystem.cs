using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// reacts to the SpriteComponent
/// </summary>
public class RenderSpriteSystem : ReactiveSystem<GameEntity>
{
	public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
	{
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity e in entities)
		{
			GameObject go = e.view.gameObject;
			SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
			if (sr == null) sr = go.AddComponent<SpriteRenderer>();
			sr.sprite = Resources.Load<Sprite>(e.sprite.resPath);
		}
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasSprite && entity.hasView;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Sprite);
	}
}
