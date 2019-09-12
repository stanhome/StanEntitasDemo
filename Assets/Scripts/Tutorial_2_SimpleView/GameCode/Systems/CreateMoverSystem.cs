using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CreateMoverSystem : ReactiveSystem<InputEntity>
{
	readonly GameContext _gameContext;
	
	public CreateMoverSystem(Contexts contexts) : base(contexts.input)
	{
		_gameContext = contexts.game;
	}

	protected override void Execute(List<InputEntity> entities)
	{
		foreach (InputEntity e in entities)
		{
			GameEntity mover = _gameContext.CreateEntity();
			mover.isMover = true;
			mover.AddPosition(e.mouseDown.position);
			mover.AddDirection(Random.Range(0, 360));
			mover.AddScale(Random.Range(0.2f, 0.8f));
			mover.AddSprite("Bee");
		}
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.hasMouseDown;
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
	}

}
