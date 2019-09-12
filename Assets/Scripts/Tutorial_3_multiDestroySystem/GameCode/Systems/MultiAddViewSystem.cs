using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;


// IViewEntity: "I am an Entity, I can have an AssignViewComponent and a T3ViewComponent"
public interface IViewableEntity : IAssignViewEntity, IT3ViewEntity, IEntity { }

public partial class GameEntity : IViewableEntity { }
public partial class InputEntity : IViewableEntity { }
public partial class UiEntity : IViewableEntity { }


public class MultiAddViewSystem : MultiReactiveSystem<IViewableEntity, Contexts>
{
	private readonly Transform _topViewContainer = new GameObject("Views").transform;
	private readonly Dictionary<string, Transform> _viewContainers = new Dictionary<string, Transform>();
	private readonly Contexts _contexts;

	public MultiAddViewSystem(Contexts contexts) : base(contexts)
	{
		_contexts = contexts;
		// create a view container for each context name
		foreach (var context in contexts.allContexts)
		{
			string contextName = context.contextInfo.name;
			Transform contextViewContainer = new GameObject(contextName + " Views").transform;
			contextViewContainer.SetParent(contextViewContainer);
			_viewContainers.Add(contextName, contextViewContainer);
		}
	}

	protected override void Execute(List<IViewableEntity> entities)
	{
		foreach (var e in entities)
		{
			string contextName = e.contextInfo.name;
			GameObject go = new GameObject(contextName + " View");
			go.transform.SetParent(_viewContainers[contextName]);
			e.AddT3View(go);
			go.Link(e);
			e.isAssignView = false;
		}
	}

	protected override bool Filter(IViewableEntity entity)
	{
		return entity.isAssignView && !entity.hasT3View;
	}

	protected override ICollector[] GetTrigger(Contexts contexts)
	{
		return new ICollector[] {
			contexts.game.CreateCollector(GameMatcher.AssignView),
			contexts.input.CreateCollector(InputMatcher.AssignView),
			contexts.ui.CreateCollector(UiMatcher.AssignView),
		};
	}
}

