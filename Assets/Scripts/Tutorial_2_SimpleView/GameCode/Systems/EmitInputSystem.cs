using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
	private readonly InputContext _context;
	private InputEntity _leftMouseEntity;
	private InputEntity _rightMouseEntity;

	public EmitInputSystem(Contexts contexts)
	{
		_context = contexts.input;
	}


	public void Initialize()
	{
		_context.isLeftMouse = true;
		_leftMouseEntity = _context.leftMouseEntity;

		_context.isRightMouse = true;
		_rightMouseEntity = _context.rightMouseEntity;
	}

	public void Execute()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// left mouse button
		if (Input.GetMouseButtonDown(0))
		{
			_leftMouseEntity.ReplaceMouseDown(mousePos);
		}

		if (Input.GetMouseButton(0))
		{
			_leftMouseEntity.ReplaceMousePosition(mousePos);
		}

		if (Input.GetMouseButtonUp(0))
		{
			_leftMouseEntity.ReplaceMouseUp(mousePos);
		}


		// right mouse button
		if (Input.GetMouseButtonDown(1))
		{
			_rightMouseEntity.ReplaceMouseDown(mousePos);
		}

		if (Input.GetMouseButton(1))
		{
			_rightMouseEntity.ReplaceMousePosition(mousePos);
		}

		if (Input.GetMouseButtonUp(1))
		{
			_rightMouseEntity.ReplaceMouseUp(mousePos);
		}
	}

}
