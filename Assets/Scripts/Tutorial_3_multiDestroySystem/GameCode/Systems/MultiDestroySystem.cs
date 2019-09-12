using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;


// IDestroyed: "I'm an Entity, I can have a DestroyedComponent AND I have a ViewComponent"
public interface IDestroyableEntity : IEntity, IDestroyedEntity, IT3ViewEntity { }


// tell the compiler that our context-specific entities implement IDestroyed
public partial class GameEntity : IDestroyableEntity { }
public partial class InputEntity : IDestroyableEntity { }
public partial class UiEntity : IDestroyableEntity { }

// inherit from MultiReactiveSystem using the IDestroyed interface defined above
public class MultiDestroySystem : MultiReactiveSystem<IDestroyableEntity, Contexts>
{
	public MultiDestroySystem(Contexts contexts) : base(contexts)
	{

	}

	protected override void Execute(List<IDestroyableEntity> entities)
	{
		foreach (var e in entities)
		{
			if (e.hasT3View)
			{
				GameObject go = e.t3View.gameObject;
				go.Unlink();
				Object.Destroy(go);
			}

			Debug.Log("Destroyed Entity from " + e.contextInfo.name + " context");
			e.Destroy();
		}
	}

	protected override bool Filter(IDestroyableEntity entity)
	{
		return entity.isDestroyed;
	}

	protected override ICollector[] GetTrigger(Contexts contexts)
	{
		return new ICollector[] {
		contexts.game.CreateCollector(GameMatcher.Destroyed),
		contexts.input.CreateCollector(InputMatcher.Destroyed),
		contexts.ui.CreateCollector(UiMatcher.Destroyed),
	};
	}
}
