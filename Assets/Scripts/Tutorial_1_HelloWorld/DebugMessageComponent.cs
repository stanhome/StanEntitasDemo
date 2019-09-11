using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Game]
public class DebugMessageComponent : IComponent
{
	public string message;
	public string tag;
	public int age;
}
