
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace engine_0.States;

public sealed class StateManager
{
    private static StateManager _instance;

    public static StateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StateManager();
            }
            return _instance;
        }
    }

    private Stack<State> _states = new Stack<State>();

    public void AddState(State state)
    {
        _states.Push(state);
    }

    public void RemoveState()    
    {
        _states.Pop();
    }

    public void Update() 
    {
        if (_states.Count > 0)
        {
            _states.Peek().Update();
        }
    }

    public void Draw() 
    {
        if (_states.Count > 0)
        {
            _states.Peek().Draw();
        }
    }

}
