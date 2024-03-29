﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using Entitas.Unity;

/// <summary>
/// 
/// </summary>
public class AddViewSystem : ReactiveSystem<GameEntity>
{
	readonly Transform _viewContainer = new GameObject("Game Views").transform;
	readonly GameContext _context;

	public AddViewSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity e in entities)
		{
			GameObject go = new GameObject("Game View");
			go.transform.SetParent(_viewContainer, false);
			e.AddView(go);
			go.Link(e);
		}
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasSprite && !entity.hasView;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Sprite);
	}

}
