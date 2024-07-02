using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace engine_0;

public class InputMap
{

    protected Dictionary<InputType, Keys> KeyBindings = new Dictionary<InputType, Keys>();

    protected Dictionary<InputType, Keys> DefaultKeyBindings = new Dictionary<InputType, Keys>();

    private bool _defaultKeys = false;

    public InputMap()
    {
        SetDefaultKeyBindings();
    }

    public bool DefaultKeys
    {
        get
        {
            return _defaultKeys;
        }
        set
        {
            _defaultKeys = value;
        }
    }

    public void AddKeyBinding(InputType type, Keys key)
    {
        KeyBindings.Add(type, key);
    }

    public Keys GetKey(InputType type)
    {
        if (_defaultKeys)
        {
            return DefaultKeyBindings[type];
        }
        return KeyBindings[type];
    }

    private void SetDefaultKeyBindings()
    {
        DefaultKeyBindings.Clear();

        DefaultKeyBindings.Add(InputType.UP, Keys.W);
        DefaultKeyBindings.Add(InputType.DOWN, Keys.S);
        DefaultKeyBindings.Add(InputType.LEFT, Keys.A);
        DefaultKeyBindings.Add(InputType.RIGHT, Keys.D);

        // DefaultKeyBindings.Add(InputType.UP, Keys.Up);
        // DefaultKeyBindings.Add(InputType.DOWN, Keys.Down);
        // DefaultKeyBindings.Add(InputType.LEFT, Keys.Left);
        // DefaultKeyBindings.Add(InputType.RIGHT, Keys.Right);

        DefaultKeyBindings.Add(InputType.JUMP, Keys.Space);
    }

}
