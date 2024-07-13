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
	/// Description of Tabuleiro.
	/// </summary>
	public class Tabuleiro
	{
		public char[,] board; // Tabuleiro 6x7

        public Tabuleiro()
        {
            IniciarTabuleiro();
        }

        private void IniciarTabuleiro()
        {
            board = new char[6, 7];

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                	board[row, col] = ' ';
                }
            }
        }

        public void DesenharTabuleiro()
        {
            Console.Clear();
            Console.WriteLine(" 1 2 3 4 5 6 7");

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.Write("|" + board[row, col]);
                }

                Console.WriteLine("|");
            }
        }

        public bool EstaColunaDisponivel(int coluna)
        {
            return board[0, coluna] == ' ';
        }

        public void InserirPeca(int coluna, char peca)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, coluna] == ' ')
                {
                    board[row, coluna] = peca;
                    break;
                }
            }
        }

        public bool VerificarVitoria()
        {
            // Verificar linhas
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] != ' ' &&
                        board[row, col] == board[row, col + 1] &&
                        board[row, col] == board[row, col + 2] &&
                        board[row, col] == board[row, col + 3])
                    {
                        return true;
                    }
                }
            }

            // Verificar colunas
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[row, col] != ' ' &&
                        board[row, col] == board[row + 1, col] &&
                        board[row, col] == board[row + 2, col] &&
                        board[row, col] == board[row + 3, col])
                    {
                        return true;
                    }
                }
            }

            // Verificar diagonais
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] != ' ' &&
                        board[row, col] == board[row + 1, col + 1] &&
                        board[row, col] == board[row + 2, col + 2] &&
                        board[row, col] == board[row + 3, col + 3])
                    {
                        return true;
                    }
                }
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 3; col < 7; col++)
                {
                    if (board[row, col] != ' ' &&
                        board[row, col] == board[row + 1, col - 1] &&
                        board[row, col] == board[row + 2, col - 2] &&
                        board[row, col] == board[row + 3, col - 3])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TabuleiroCompleto()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void RemoverUltimaPeca(int coluna)
	    {
	        for (int linha = 0; linha < 6; linha++)
	        {
	            if (board[linha, coluna] != ' ')
	            {
	                board[linha, coluna] = ' ';
	                break;
	            }
	        }
	    }
        public static Tabuleiro CopiarTabuleiro(Tabuleiro original)
	    {
	        Tabuleiro copia = new Tabuleiro();

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                copia.board[row, col] = original.board[row, col];
            }
	        }
	
	        return copia;
	    }
        public bool EstaColunaDisponivelMaquina(int coluna)
		{
		    for (int row = 0; row < 6; row++)
		    {
		        if (board[row, coluna] == ' ')
		        {
		            return true;
		        }
		    }
		
		    return false;
		}
        public bool IsMoveValid(int row, int col)
	    {
	        return col >= 0 && col < 3 && board[row, col] == ' ';
	    }
    }
}
