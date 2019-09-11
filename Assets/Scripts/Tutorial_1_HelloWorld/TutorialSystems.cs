using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TutorialSystems : Feature
{
	public TutorialSystems(Contexts contexts) : base("Tutorial Systems")
	{
		Add(new HelloWorldSystem(contexts))
		.Add(new LogMouseClickSystem(contexts))
		.Add(new DebugMessageSystem(contexts))
		.Add(new CleanupDebugMessageSystem(contexts)); // new system (we want this to run last)
	}
}
