using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using engine_0.Globals;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace engine_0.States;

public class TestGameState : State
{

    private List<Vector2> cell = new List<Vector2>();

    private int frameCount = 0;

    private int cellWidth = 2;
    private int cellHeight = 2;

    private int totalCells = 400;  

    private int[,] cellValues;
    private Vector2[,] cells;
    private int[,] newCellValues;

    private Color liveCell = Color.Green;

    
    private float totalTime = 0;


    public TestGameState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
    {
        cellValues = new int[totalCells, totalCells];
        cells = new Vector2[totalCells, totalCells];
        newCellValues = new int[totalCells, totalCells];

        

        for (int x = 0; x < totalCells; x++)
        {
            for (int y = 0; y < totalCells; y++)
            {
                cells[x, y] = new Vector2(x * cellWidth, y * cellHeight);
                cellValues[x, y] = Util.Range(Util.Random, 0, 2);
                // Debug.WriteLine(cells[x, y].X + ", " + cells[x, y].Y);
            }
        }
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update()
    {   
            
        frameCount ++;

        if (frameCount % 4 == 0)
        {
            for (int x = 1; x < totalCells - 1; x++)
            {
                for (int y = 1; y < totalCells - 1; y++)
                {

                    int count = 0;

                    if (x > 0 && y > 0 && cellValues[x - 1, y - 1] == 1)
                    {
                        count++;
                    }

                    if (y > 0 && cellValues[x, y - 1] == 1)
                    {
                        count++;
                    }

                    if (x < totalCells - 1 && y > 0 && cellValues[x + 1, y - 1] == 1)
                    {
                        count++;
                    }

                    if (x > 0 && cellValues[x - 1, y] == 1)
                    {
                        count++;
                    }

                    if (x < totalCells - 1 && cellValues[x + 1, y] == 1)
                    {
                        count++;
                    }

                    if (x > 0 && y < totalCells - 1 && cellValues[x - 1, y + 1] == 1)
                    {
                        count++;
                    }

                    if (y < totalCells - 1 && cellValues[x, y + 1] == 1)
                    {
                        count++;
                    }

                    if (x < totalCells - 1 && y < totalCells - 1 && cellValues[x + 1, y + 1] == 1)
                    {
                        count++;
                    }

                    
                
                
                

                    // 1. Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                    if (cellValues[x, y] == 1 && count < 2)
                    {
                        newCellValues[x, y] = 0;
                    }


                    // 2. Any live cell with two or three live neighbours lives on to the next generation.
                    if (cellValues[x, y] == 1 && count == 2 || count == 3)
                    {
                        newCellValues[x, y] = 1;
                    }

                    
                    // 3. Any live cell with more than three live neighbours dies, as if by overpopulation.
                    if (cellValues[x, y] == 1 && count > 3)
                    {
                        newCellValues[x, y] = 0;
                    }


                    // 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    if (cellValues[x, y] == 0 && count == 3)
                    {
                        newCellValues[x, y] = 1;
                    }

                }
            }

            for (int x = 0; x < totalCells; x++)
            {
                for (int y = 0; y < totalCells; y++)
                {
                    cellValues[x, y] = newCellValues[x, y];
                    newCellValues[x, y] = 0;
                }
            }
        }

        totalTime += Data.DeltaTime;
    }

    public override void Draw()
    {
        _graphicsDevice.Clear(Color.Black);

        int livingCells = 0;


        for (int x = 0; x < totalCells; x++)
        {
            for (int y = 0; y < totalCells; y++)
            {
                if (cellValues[x, y] == 1)
                {
                    Render.FilledRect(new Rectangle((int)cells[x, y].X, (int)cells[x, y].Y, cellWidth, cellHeight), Color.Lime);
                    livingCells ++;
                }
                // else
                // {
                //     Render.Rect(new Rectangle((int)cells[x, y].X, (int)cells[x, y].Y, cellWidth, cellHeight), Color.White);
                // }
            }
        }



        Render.FilledRect(new Rectangle(0, Data.WindowHeight - 75, 200, 75), Color.Black);
        Render.Rect(new Rectangle(0, Data.WindowHeight - 75, 200, 75), Color.Lime);

        Render.SpriteBatch.DrawString(GameMain.font, "Game Of Life", new Vector2(50, Data.WindowHeight - 70), Color.Lime);
        Render.SpriteBatch.DrawString(GameMain.font, "Elapsed Time : " + totalTime.ToString("0.0"), new Vector2(10, Data.WindowHeight - 50), Color.Lime);
        Render.SpriteBatch.DrawString(GameMain.font, "Living Cells : " + livingCells.ToString(), new Vector2(10, Data.WindowHeight - 35), Color.Lime);

    }
}
