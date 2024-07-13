/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/06/2023
 * Time: 20:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace abc
{
	/// <summary>
	/// Description of JogadorMaquina.
	/// </summary>
	public class JogadorMaquina: Jogador
	{
		public static char aiPlayer='O';
		private static char humanPlayer='X';
		private static char[,] board = new char[6, 7];
		public JogadorMaquina(string nome, char simbolo)
		{
			this.Nome=nome;
			this.simbolo=simbolo;
		}
		
		//public override int ObterJogada(Tabuleiro tab)
        //{
			//Random random = new Random();
        	// Gerar um número aleatório entre 1 e 100
        	//int coluna = random.Next(0, 6);
			
	
	        //Console.WriteLine("A máquina escolheu a coluna {coluna}.");
	
	        //return coluna;
	    //}
		public override int ObterJogadaMaquina(Tabuleiro tab, Jogo jog)
    	{
			
        Console.WriteLine("Vez da IA...");

        // Simulação de atraso para parecer que a IA está "pensando"
        System.Threading.Thread.Sleep(1000);

        // Encontrar a melhor jogada usando o algoritmo Minimax
        int bestScore = int.MinValue;
        int bestRow = -1;
        int bestCol = -1;

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (tab.IsMoveValid(row, col))
                {
                    board[row, col] = aiPlayer;

                    int score = Minimax(board, 0, false, tab, jog);

                    board[row, col] = ' ';

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
        }
        return bestCol -1;
    }
		
		private static bool IsGameOver(Tabuleiro tab)
    {
			return tab.TabuleiroCompleto() || tab.VerificarVitoria();	
    }

    private static int Minimax(char[,] board, int depth, bool isMaximizingPlayer, Tabuleiro tab, Jogo jog)
    {
    	if (IsGameOver(tab))
        {
            int gameResult = EvaluateGameResult(jog);
            return gameResult;
        }

        if (isMaximizingPlayer)
        {
            int bestScore = int.MinValue;

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (tab.IsMoveValid(row, col))
                    {
                        board[row, col] = aiPlayer;

                        int score = Minimax(board, depth + 1, false, tab, jog);

                        board[row, col] = ' ';

                        bestScore = Math.Max(bestScore, score);
                    }
                }
            }

            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (tab.IsMoveValid(row, col))
                    {
                        board[row, col] = humanPlayer;

                        int score = Minimax(board, depth + 1, true, tab, jog);

                        board[row, col] = ' ';

                        bestScore = Math.Min(bestScore, score);
                    }
                }
            }

            return bestScore;
        }
    }
    private static int EvaluateGameResult(Jogo jog)
    {
        if (jog.currentPlayer.simbolo=='X')	
        {
            return -1;
        }

        if (jog.currentPlayer.simbolo=='O')
        {
            return 1;
        }

        return 0; // Empate
    }
    
	}
}