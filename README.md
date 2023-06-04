# Tic-Tac-Toe AI

This is a console-based Tic-Tac-Toe game implementation with an AI opponent using the minimax algorithm. The game allows you to play against an AI that makes optimal moves based on the current game state.

## How to Use

1. Compile and run the code.
2. The game starts by displaying an empty Tic-Tac-Toe board.
3. Each player takes turns making their moves.
4. As a human player (X), you are prompted to enter the row (0-2) and column (0-2) where you want to place your mark.
5. The AI player (O) will automatically make its move after a short delay.
6. The game continues until a player wins, it is a tie, or you decide to quit.
7. After each game outcome (win, tie, or quit), you are given the option to play again or exit.

## Dependencies

This code is written in C# and does not have any external dependencies. It should be compatible with any modern C# compiler and runtime.

## Minimax Algorithm

The AI opponent in this game uses the minimax algorithm to make optimal moves. The minimax algorithm is a recursive algorithm that searches through all possible moves and their outcomes to determine the best move to make. The AI player assumes that the human player will also make optimal moves.

The algorithm assigns scores to each terminal game state: +10 for a win, -10 for a loss, and 0 for a tie. The AI player tries to maximize its score, assuming the human player will try to minimize it. By recursively evaluating all possible moves and their outcomes, the AI player selects the move with the highest score.

## Limitations

- The game currently lacks any input validation for human player moves. Ensure that you enter valid row and column values between 0 and 2.
- The AI opponent is not optimized for large game trees, and it might take longer to make moves as the game progresses.
- The game does not have a graphical user interface and is limited to console-based interactions.

Feel free to modify and enhance the code to address these limitations or add additional features.

**Note:** This code snippet assumes you have basic knowledge of C# programming.
