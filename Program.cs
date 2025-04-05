using System;

class Program
{
    static char[] board = { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1;
    static char currentMarker = 'X';

    static void Main()
    {
        int move;
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            DrawBoard();

            Console.Write($"Player {currentPlayer}, enter cell number: ");
            bool validMove = int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && board[move] != 'X' && board[move] != 'O';

            if (!validMove)
            {
                Console.WriteLine("Wrong move, try again.");
                Console.ReadKey();
                continue;
            }

            board[move] = currentMarker;

            if (CheckWin())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"The player wins {currentPlayer}!");
                gameRunning = false;
                break;
            }

            if (CheckDraw())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Draw!");
                gameRunning = false;
                break;
            }

            SwitchPlayer();
        }
    }

    static void DrawBoard()
    {
        Console.WriteLine($" {board[1]} | {board[2]} | {board[3]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[4]} | {board[5]} | {board[6]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[7]} | {board[8]} | {board[9]} ");
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        currentMarker = (currentMarker == 'X') ? 'O' : 'X';
    }

    static bool CheckWin()
    {
        int[,] winPatterns =
        {
            {1, 2, 3}, {4, 5, 6}, {7, 8, 9},
            {1, 4, 7}, {2, 5, 8}, {3, 6, 9},
            {1, 5, 9}, {3, 5, 7}
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            if (board[winPatterns[i, 0]] == currentMarker &&
                board[winPatterns[i, 1]] == currentMarker &&
                board[winPatterns[i, 2]] == currentMarker)
            {
                return true;
            }
        }
        return false;
    }

    static bool CheckDraw()
    {
        for (int i = 1; i < board.Length; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
