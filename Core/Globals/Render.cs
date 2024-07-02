using System;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace engine_0.Globals;

public static class Render
{

    private static SpriteBatch _spriteBatch;

    private static Texture2D _pixel;

    public static void Initialize(GraphicsDevice graphicsDevice)
    {
        _spriteBatch = new SpriteBatch(graphicsDevice);
        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData<Color>(new Color[]{Color.White});
    }

    public static SpriteBatch SpriteBatch
    {
        get
        {
            return _spriteBatch;
        }
    }

    #region Lines

    private static void DrawLine(Vector2 start, float angle, float length, int thickness, Color color)
    {   
        SpriteBatch.Draw(_pixel, start, _pixel.Bounds, color, angle, Vector2.Zero, new Vector2(length, thickness), SpriteEffects.None, 0);
    }

    public static void Line(Vector2 start, Vector2 end, Color color)
    {
        DrawLine(start, Util.Angle(start, end), Vector2.Distance(end, start),  1, color);
    }

    public static void Line(Vector2 start, Vector2 end, int thickness, Color color)
    {
        DrawLine(start, Util.Angle(start, end), Vector2.Distance(end, start),  thickness, color);
    }

    #endregion Lines





    #region Rectangles

    public static void Rect(Rectangle rect, Color color)
    {
        Rect(new Vector2(rect.X, rect.Y), (int)rect.Width, (int)rect.Height, color);
    }

    public static void Rect(Rectangle rect, int thickness, Color color)
    {
        Rect(new Vector2(rect.X, rect.Y), (int)rect.Width, (int)rect.Height, thickness, color);
    }

    public static void Rect(Vector2 pos, int width, int height, Color color)
    {
        
        Line(pos, new Vector2(pos.X + width, pos.Y), color);
        Line(new Vector2(pos.X + width, pos.Y), new Vector2(pos.X + width, pos.Y + height), color);
        Line(new Vector2(pos.X + width, pos.Y + height),  new Vector2(pos.X, pos.Y + height), color);
        Line(new Vector2(pos.X, pos.Y + height), pos, color);
        
    }

    public static void Rect(Vector2 pos, int width, int height, int thickness, Color color)
    {
        
        Line(pos, new Vector2(pos.X + width, pos.Y), thickness, color);
        Line(new Vector2(pos.X + width, pos.Y), new Vector2(pos.X + width, pos.Y + height), thickness, color);
        Line(new Vector2(pos.X + width, pos.Y + height),  new Vector2(pos.X, pos.Y + height), thickness, color);
        Line(new Vector2(pos.X, pos.Y + height), pos, thickness, color);
        
    }

    public static void FilledRect(Vector2 pos, int width, int height, Color color)
    {
        FilledRect(new Rectangle((int)pos.X, (int)pos.Y, width, height), color);
    }

    public static void FilledRect(Rectangle rect, Color color)
    {
        SpriteBatch.Draw(_pixel, rect, color);
    }

    #endregion Rectangles

}
