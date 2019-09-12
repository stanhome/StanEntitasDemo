using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovementSystems : Feature
{
	public MovementSystems(Contexts contexts) : base("Movement Systems")
	{
		Add(new MoveSystem(contexts));
	}
}
