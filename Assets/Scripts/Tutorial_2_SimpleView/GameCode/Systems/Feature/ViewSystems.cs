using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Feature
/// </summary>
public class ViewSystems : Feature
{
	public ViewSystems(Contexts contexts) : base("View Systems")
	{
		Add(new AddViewSystem(contexts))
		.Add(new RenderSpriteSystem(contexts))
		.Add(new RenderPositionSystem(contexts))
		.Add(new RenderScaleSystem(contexts))
		.Add(new RenderDirectionSystem(contexts));
	}
}
