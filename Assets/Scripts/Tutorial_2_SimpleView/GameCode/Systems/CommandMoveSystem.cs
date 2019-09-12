using Entitas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommandMoveSystem : ReactiveSystem<InputEntity>
{
	readonly GameContext _gameContext;
	readonly IGroup<GameEntity> _movers;

	public CommandMoveSystem(Contexts contexts) : base(contexts.input)
	{
		_movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover).NoneOf(GameMatcher.Move));
	}

	protected override void Execute(List<InputEntity> entities)
	{
		foreach (InputEntity e in entities)
		{
			GameEntity[] movers = _movers.GetEntities();
			if (movers.Length <= 0)
			{
				return;
			}

			movers[Random.Range(0, movers.Length)].ReplaceMove(e.mouseDown.position);

			// changed all movers
			//foreach (GameEntity m in movers)
			//{
			//	m.ReplaceMove(e.mouseDown.position);
			//}
		}
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.hasMouseDown;
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
	}
}
