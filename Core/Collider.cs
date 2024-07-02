using System;
using Microsoft.Xna.Framework;

using engine_0.Globals;

namespace engine_0;

public class Collider
{

    public Vector2 Position;
    public int Width { get; set; }
    public int Height { get; set; }
    public Rectangle Bounds;

    public Collider(Vector2 position, int width, int height)
    {
        Position = position;
        Width = width;
        Height = height;
        Bounds = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
    }

    public Vector2 Centre 
    { 
        get
        {
            return new Vector2(Position.X + Width / 2, Position.Y + Height / 2);
        } 
    }
    public float Right 
    {
        get
        {
            return Position.X + Width;
        }
    }
    public float Left 
    {
        get
        {
            return Position.X;
        }
    }
    public float Top 
    { 
        get
        {
            return Position.Y;
        }
    }
    public float Bottom 
    { 
        get { return Position.Y + Height; }
    }

    public void UpdatePosition(Vector2 nextPos)
    {
        Position = nextPos;
        Bounds.X = (int)Position.X;
        Bounds.Y = (int)Position.Y;
    }

    public void Draw(Color color)
    {
        Render.Rect(Bounds, color);
    }

    public bool Collision(Collider other)
    {
        return Bounds.Right > other.Bounds.Left &&
                Bounds.Left < other.Bounds.Right &&
                Bounds.Top < other.Bounds.Bottom &&
                Bounds.Bottom > other.Bounds.Top;
    }

    public float Distance(Collider collider)
    {
        return Vector2.Distance(Centre, collider.Centre);
    }
    
}
