using System;
using Microsoft.Xna.Framework.Graphics;

namespace engine_0.States;

public abstract class State : IComponent
{   
    protected GraphicsDevice _graphicsDevice;
    private bool _isLoaded = false;

    public State(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
    }

    public virtual void Initialize()
    {
        _isLoaded = true;
    }
    public abstract void Update();

    public abstract void Draw();

    public bool IsLoaded()
    {
        return _isLoaded;
    }

    public void Dispose()
    {
        this.Dispose();
    }
}
