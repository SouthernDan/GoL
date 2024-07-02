using System;

using Microsoft.Xna.Framework;

namespace engine_0;

public interface IComponent
{
    abstract void Initialize();
    abstract void Update();
    abstract void Draw();
}
