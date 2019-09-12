using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InputSystems : Feature
{
	public InputSystems(Contexts contexts) : base("Input System")
	{
		Add(new EmitInputSystem(contexts))
		.Add(new CreateMoverSystem(contexts))
		.Add(new CommandMoveSystem(contexts));
	}
}
