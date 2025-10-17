
using System;
using System.IO;
public class mazeGame 
{   
   
    static readonly char MAZE_START ='S';
    const char MAZE_GOAL = 'G';
    const char  RAT = 'R';
    const char WALL1 = '#';
    const char WALL2 = '|';
    static readonly ConsoleKey UP = ConsoleKey.UpArrow;
    static readonly ConsoleKey DOWN = ConsoleKey.DownArrow;
    static readonly ConsoleKey LEFT = ConsoleKey.LeftArrow;
    static readonly ConsoleKey RIGHT = ConsoleKey.RightArrow;
   


    // Game State
    int mazeStartRow, mazeStartCol, mazeGoalRow, mazeGoalCol, ratRow, ratCol, rows, cols;
    char[,] maze;
 
    public static void Main(string[] arg)
    {
        mazeGame ag = new mazeGame();
        ag.Start();
    }
    
    public mazeGame()
    {
    }
    
    public void Start()
    {
        ConsoleKey input;
        Init(); // 1. Initialize Variables
        ShowGameStartScreen(); // 2. Show Game Start Screen
        do
        {
            ShowBoard(); // 3. Show Board / Scene / Map
            do
            {
                ShowInputOptions(); // 4. Show Input Options
                input = GetInput(); // 5. Get Input
            }
            while (!IsValidInput(input)); // 6. Validate Input
            ProcessInput(input); // 7. Process Input
            UpdateGameState(); // 8. Update Game State
        }
        while (!IsGameOver()); // 9. Check for Termination Conditions
        ShowGameOverScreen(); // 10. Show Game Results
    }
    
    public void Init()
    {
        try
        {
            StreamReader mazeReader = new StreamReader("maze.txt");
            mazeStartRow = int.Parse(mazeReader.ReadLine());
            mazeStartCol = int.Parse(mazeReader.ReadLine());
            mazeGoalRow = int.Parse(mazeReader.ReadLine());
            mazeGoalCol = int.Parse(mazeReader.ReadLine());
            ratRow = mazeStartRow;
            ratCol = mazeStartCol;
            rows = int.Parse(mazeReader.ReadLine());
            cols = int.Parse(mazeReader.ReadLine());
            maze = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = (char)mazeReader.Read();
                }
                mazeReader.ReadLine(); // Consume and ignore the rest of the line
            }
            mazeReader.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Environment.Exit(-1);

        }
    }
    public void ShowGameStartScreen()
    {
        Console.WriteLine("WELCOME TOOOO!!!!...");
        Console.WriteLine(@"
 __   __  _______  _______  _______    _______  _______  __   __  _______ 
|  |_|  ||   _   ||       ||       |  |       ||   _   ||  |_|  ||       |
|       ||  |_|  ||____   ||    ___|  |    ___||  |_|  ||       ||    ___|
|       ||       | ____|  ||   |___   |   | __ |       ||       ||   |___ 
|       ||       || ______||    ___|  |   ||  ||       ||       ||    ___|
| ||_|| ||   _   || |_____ |   |___   |   |_| ||   _   || ||_|| ||   |___ 
|_|   |_||__| |__||_______||_______|  |_______||__| |__||_|   |_||_______|
");
        
    }
  
    public void ShowBoard()
    {
        
         for (int i = 0; i < rows; i++)
         {
             

            for (int j = 0; j < cols; j++)
             {
                
                if (i == ratRow && j == ratCol)
                {
                    Console.Write(RAT);
                }
                else if (i == mazeStartRow && j == mazeStartCol)
                {
                    Console.Write(MAZE_START);

                }
                else if (i == mazeGoalRow && j == mazeGoalCol)
                {
                    Console.Write(MAZE_GOAL);
                }
                else
                {
                    Console.Write(maze[i, j]);
                }
            }
            
            
            Console.Write("\n");
            
            
           
            

         }
       
            
    }
     
    public void ShowInputOptions()
    {
        Console.WriteLine($"Enter {UP} for UP | {DOWN} for DOWN | {LEFT} for LEFT | {RIGHT} for  RIGHT: ");
    }
   
    public ConsoleKey GetInput()
    {
          
       ConsoleKey input = Console.ReadKey(true).Key;
    
       return input;
    }

    public bool IsValidInput(ConsoleKey input)
    {

        if (input != UP && input != DOWN && input != LEFT && input != RIGHT)
        {
            Console.WriteLine("You can't put nothing that is not a character. Please try again");
            return false;
        }

        int outRow = ratRow, outCol = ratCol;
        if (input == UP)
        {
            outRow--;
        }

        else if (input == DOWN)
        {
            outRow++;
        }
        else if (input == LEFT)
        {
            outCol--;
        }
        else if (input == RIGHT)
        {
            outCol++;
        }

        
    
       /* if (input.Length < 1)
        {
       
            Console.WriteLine("The moves has to be one character long.\nPlease try again. ");
            return false;
        }
        else if (input.Length > 1)
        {
            Console.WriteLine("The moves can't be more than one character long.\nPlease try again");
            return false;
        }*/

        if (maze[outRow, outCol] == WALL1 || maze[outRow, outCol] == WALL2)
        {
        Console.WriteLine("Cannot move through a wall.");
        return false;
        }
        
        else
        {
        return true;
        }
        
       
    }
            public void ProcessInput(ConsoleKey input)
            {
                if (input == UP)
                {
                    ratRow--;

                }
                else if (input == DOWN)
                {
                    ratRow++;


                }
                else if (input == LEFT)
                {
                    ratCol--;

                }
                else if (input == RIGHT)
                {
                    ratCol++;

                }
                else
                {
                    Console.WriteLine("Something went really wrong! This is never supposed to happen! ");
                }
        Console.Clear();
            }
     
    public void UpdateGameState()
    {
        
    }
    
    public bool IsGameOver()
    {
        if (ratCol  == mazeGoalCol && ratRow == mazeGoalRow)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
    public void ShowGameOverScreen()
    {
        Console.Clear();
        ShowBoard();
        Console.WriteLine("CONGRATULATIONS YOU WOOOOONNN!!!!");
    }
}