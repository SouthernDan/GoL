using System;

using Microsoft.Xna.Framework;

namespace engine_0.Globals;

public static class Util
{

    public static Random Random = new Random();


    #region Random

    public static int Range(this Random random, int min, int max)
    {
        return min + random.Next(max - min);
    }

    #endregion Random




    #region Colors

    public static Color Invert(Color color)
    {
        return new Color(255 - color.R, 255 - color.G, 255 - color.B, color.A);
    }

    #endregion



    #region Maths bits

    public const float DegreesToRadians = (float)Math.PI / 180f;
    public const float RadiansToDegrees = 180f / (float)Math.PI;


    public static float ToRadians(this float f)
    {
        return f * DegreesToRadians;
    }

    public static float ToDegrees(this float f)
    {
        return f * RadiansToDegrees;
    }

    public static float Angle(Vector2 from, Vector2 to)
    {
        return (float)Math.Atan2(to.Y - from.Y, to.X - from.X);
    }

    public static float GetDeltaTimeInSeconds(GameTime gameTime)
    { 
        return (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public static int Clamp(int value, int min, int max)
    {
        return Math.Min(Math.Max(value, min), max);
    }

    public static float Clamp(float value, float min, float max)
    {
        return Math.Min(Math.Max(value, min), max);
    }

    #endregion Maths bits
}
