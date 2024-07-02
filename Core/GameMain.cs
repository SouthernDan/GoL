using System;
using System.Diagnostics;
using engine_0.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using engine_0.Globals;
using Microsoft.Xna.Framework.Input;

namespace engine_0;

public class GameMain : Game
{

    private GraphicsDeviceManager _gdm;
    private RenderTarget2D _renderTarget;

    public static SpriteFont font;

    public GameMain()
    {
        _gdm = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = Data.WindowWidth,
            PreferredBackBufferHeight = Data.WindowHeight
        };
        _gdm.ApplyChanges();

        IsMouseVisible = true;
        
        Content.RootDirectory = "Content";

        
    }

    protected override void Initialize()
    {   
        Render.Initialize(GraphicsDevice);

        _renderTarget = new RenderTarget2D(
            GraphicsDevice,
            Data.ViewportWidth,
            Data.ViewportHeight
        );

        StateManager.Instance.AddState(new TestGameState(GraphicsDevice));
        
        base.Initialize();

        font = Content.Load<SpriteFont>("font");

    }

    protected override void Update(GameTime gameTime)
    {   
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Data.DeltaTime = Util.GetDeltaTimeInSeconds(gameTime);

        InputManager.Instance.UpdateCurrentInputController();

        StateManager.Instance.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.SetRenderTarget(null);

        Render.SpriteBatch.Begin();

        StateManager.Instance.Draw();

        Render.SpriteBatch.End();

        // DrawRenderTarget();

        base.Draw(gameTime);

    }

    private void DrawRenderTarget()
    {
        GraphicsDevice.SetRenderTarget(null);
        Render.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        Render.SpriteBatch.Draw(_renderTarget, new Rectangle(0, 0, Data.WindowWidth, Data.WindowHeight), Color.White);
        Render.SpriteBatch.End();
    }

}


