using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace engine_0;

public abstract class InputController
{

    protected InputMap InputMap;

    private KeyboardState _currentKeyboardState, _previousKeyboardState;
    private MouseState _currentMouseState, _previousMouseState;

    protected InputController()
    {
        InputMap = new InputMap();
        
        _previousKeyboardState = _currentKeyboardState;
        _previousMouseState = _currentMouseState;

        _currentKeyboardState = Keyboard.GetState();
        _currentMouseState = Mouse.GetState();
    }
   
    protected Rectangle MousePosition
    {
        get 
        {
            return new Rectangle(
                Mouse.GetState().X / 3,
                Mouse.GetState().Y / 3,
                1,
                1
            );
        }
    }

    public virtual void Update()
    {
        _previousKeyboardState = _currentKeyboardState;
        _previousMouseState = _currentMouseState;

        _currentKeyboardState = Keyboard.GetState();
        _currentMouseState = Mouse.GetState();
    }
    
    public bool IsInputPressed(InputType type)
    {   
        if (_currentKeyboardState.IsKeyDown(InputMap.GetKey(type)) &&
            _previousKeyboardState.IsKeyUp(InputMap.GetKey(type)))
            return true;
        return false;
    }

    public bool IsInputReleased(InputType type)
    {   
        if (_previousKeyboardState.IsKeyDown(InputMap.GetKey(type)) &&
            _currentKeyboardState.IsKeyUp(InputMap.GetKey(type)))
            return true;
        return false;
    }

    public bool IsInputDown(InputType type)
    {   
        if (_currentKeyboardState.IsKeyDown(InputMap.GetKey(type)))
            return true;
        return false;
    }   

    public bool IsInputUp(InputType type)
    {
        if (_currentKeyboardState.IsKeyUp((InputMap.GetKey(type))))
            return true;
        return false;
    }

    public bool LeftMouseClick()
    {
        if (_currentMouseState.LeftButton == ButtonState.Pressed &&
            _previousMouseState.LeftButton == ButtonState.Released)
            return true;
        return false;
    }

    public bool RightMouseClick()
    {
        if (_currentMouseState.RightButton == ButtonState.Pressed &&
            _previousMouseState.RightButton == ButtonState.Released)
            return true;
        return false;
    }

}
