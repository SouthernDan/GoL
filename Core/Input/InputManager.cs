using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace engine_0;

public sealed class InputManager
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InputManager();
            }
            return _instance;
        }
    }

    private Stack<InputController> _inputControllers = new Stack<InputController>();

    public void AddController(InputController controller)
    {
        _inputControllers.Push(controller);
    }

    public void RemoveController()
    {
        if (_inputControllers.Count > 0)
        {
            _inputControllers.Pop();
        }
    }

    public void ClearControllers()
    {
        while (_inputControllers.Count > 0)
        {
            _inputControllers.Pop();
        }
    }

    public void UpdateCurrentInputController()
    {
        if (_inputControllers.Count > 0)
        {
            _inputControllers.Peek().Update();
        }
    }
}
