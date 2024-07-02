using System;
using Microsoft.Xna.Framework;

using engine_0.Globals;

namespace engine_0;

public abstract class Entity : IComponent
{

    public Vector2 Position;
    private Collider _collider;

    public Entity(Vector2 position)
    {
        Position = position;
    }

    public abstract void Initialize();
    public abstract void Update();
    public abstract void Draw();
    
    
    public float X
    {
        get { return Position.X; }
        set { Position.X = value; }
    }
    
    public float Y
    {
        get { return Position.Y; }
        set { Position.Y = value; }
    }

    public float Width
    {
        get
        {
            if (_collider == null)
            {
                return 0;
            }
            else
            {
                return _collider.Width;
            }
        }
    }

    public float Height
    {
        get
        {
            if (_collider == null)
            {
                return 0;
            }
            else
            {
                return _collider.Height;
            }
        }
    }

    public Collider Collider
    {
        get { return _collider; }
        set
        {
            _collider = value;
        }
    }

    public bool Collides(Entity other)
    {
        return Collider.Collision(other.Collider);
    }
}
