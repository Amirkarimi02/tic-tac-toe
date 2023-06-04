using System;

class TicTacToeAI
{
    private static char[,] board = new char[3, 3];
    private static char currentPlayer = 'X';
    private static char aiPlayer = 'O';
    private static char humanPlayer = 'X';

    private static int[] scores = { 10, -10, 0 };

    static void Main(string[] args)
    {
        InitializeBoard();
        Play();
    }

    private static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '-';
            }
        }
    }

    private static void DrawBoard()
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
    }

    private static void Play()
    {
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();    
            DrawBoard();

            if (currentPlayer == humanPlayer)
            {
                Console.WriteLine("Your turn. Enter row (0-2): ");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("Your turn. Enter column (0-2): ");
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] != '-')
                {
                    Console.WriteLine("Invalid move! Try again."); //Invalid Move
                    Console.WriteLine("Press Any Key to Continue...");
                    Console.ReadKey();
                    continue;
                }

                board[row, col] = currentPlayer;
            }
            else
            {
                Console.WriteLine("AI is Thinking...");
                Thread.Sleep(2500);
                BestMove(); //AI Chance
            }

            if (CheckWin(currentPlayer))
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Player {0} wins!", currentPlayer);
                Console.WriteLine("Are you want Play again(Y/N)?");
                var ans = Console.ReadLine();
                if (ans == "y")
                {
                    gameOver = false;
                    InitializeBoard();
                }
                else
                {
                    gameOver = true;
                }
            }
            else if (IsBoardFull())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Are you want Play again(Y/N)?");
                var ans = Console.ReadLine();
                if (ans == "y")
                {
                    gameOver = false;
                    InitializeBoard();
                }
                else
                {
                    gameOver = true;
                }
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; //Swap the Players
            }
        }
    }

    private static void BestMove()
    {
        int bestScore = int.MinValue;
        int[] move = new int[2];
        int alpha = int.MinValue;
        int beta = int.MaxValue;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '-')
                {
                    board[i, j] = aiPlayer;
                    int score = Minimax(board, 0, alpha, beta, false);
                    board[i, j] = '-';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move[0] = i;
                        move[1] = j;
                    }
                }
            }
        }

        board[move[0], move[1]] = aiPlayer;
    }

    private static int Minimax(char[,] board, int depth, int alpha, int beta, bool isMaximizing)
    {
        int result = GetGameResult();
        if (result != -1)
        {
            return scores[result];
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        board[i, j] = aiPlayer;
                        int score = Minimax(board, depth + 1, alpha, beta, false);
                        board[i, j] = '-';
                        bestScore = Math.Max(score, bestScore);
                        alpha = Math.Max(alpha, bestScore);
                        if (beta <= alpha)
                            break;
                    }
                }
                if (beta <= alpha)
                    break;
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        board[i, j] = humanPlayer;
                        int score = Minimax(board, depth + 1, alpha, beta, true);
                        board[i, j] = '-';
                        bestScore = Math.Min(score, bestScore);
                        beta = Math.Min(beta, bestScore);
                        if (beta <= alpha)
                            break;
                    }
                }
                if (beta <= alpha)
                    break;
            }
            return bestScore;
        }
    }

    private static int GetGameResult()
    {
        if (CheckWin(aiPlayer))
        {
            return 0;
        }
        else if (CheckWin(humanPlayer))
        {
            return 1;
        }
        else if (IsBoardFull())
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }

    private static bool CheckWin(char player)
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
            {
                return true;
            }
        }

        // Check diagonals
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            return true;
        }

        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            return true;
        }

        return false;
    }

    private static bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }
}



