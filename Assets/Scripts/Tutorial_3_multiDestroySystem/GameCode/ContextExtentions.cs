using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ContextExtentions
{
	private static readonly Dictionary<string, IContext> _contextsLookup = new Dictionary<string, IContext>();

	public static IContext GetContextByName(this Contexts contexts, string name)
	{
		if (_contextsLookup.Count == 0)
		{
			SetContextsDictionary(contexts);
		}

		return _contextsLookup[name];
	}

	private static void SetContextsDictionary(Contexts contexts)
	{
		foreach (var context in contexts.allContexts)
		{
			_contextsLookup.Add(context.contextInfo.name, context);
		}
	}
}
