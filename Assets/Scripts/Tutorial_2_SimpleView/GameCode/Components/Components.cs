using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class PositionComponent : IComponent
{
	public Vector2 value;
}

/// <summary>
/// represent the entity's diretion as a degree value.
/// </summary>
[Game]
public class DirectionComponent: IComponent
{
	public float value;
}

[Game]
public class ScaleComponent: IComponent
{
	public float value;
}


[Game]
public class ViewComponent : IComponent
{
	public GameObject gameObject;
}

/// <summary>
/// store the name of sprite we want to display
/// </summary>
[Game]
public class SpriteComponent : IComponent
{
	public string name;
	public string resPath { get { return "tutorial2/" + name; } }
}


/// <summary>
/// a flag component to indicate entities that can move
/// </summary>
[Game]
public class MoverComponent : IComponent
{

}

/// <summary>
/// hold the movement target location
/// </summary>
[Game]
public class MoveComponent : IComponent
{
	public Vector2 target;
}

/// <summary>
/// indicate that movement has completed successfully.
/// </summary>
[Game]
public class MoveCompleteComponent : IComponent
{

}


/////////////////////////////
// input

[Input, Unique]
public class LeftMouseComponent : IComponent
{

}


[Input, Unique]
public class RightMouseComponent : IComponent
{

}

[Input]
public class MouseDownComponent : IComponent
{
	public Vector2 position;
}

[Input]
public class MousePositionComponent : IComponent
{
	public Vector2 position;
}

[Input]
public class MouseUpComponent : IComponent
{
	public Vector2 position;
}

