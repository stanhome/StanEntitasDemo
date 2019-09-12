using Entitas;

[Input]
public sealed class ClickComponent : IComponent {
	public bool state;
}

/// <summary>
///  an indexed Input id 
///  Can now use Game.GetEntitiesWithInputId("xxx");
/// </summary>
[Input]
public sealed class InputIdComponent : IComponent {
	//[EntityIndex]
	public string value;
}

[Game]
public sealed class NameComponent : IComponent {
	public string value;
}


[Game]
public sealed class ButtonStateComponent: IComponent {
	public bool buttonState;
}