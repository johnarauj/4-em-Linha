/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/06/2023
 * Time: 20:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace abc
{
	/// <summary>
	/// Description of JogadorHumano.
	/// </summary>
	public class JogadorHumano: Jogador
	{
		  	  
		public JogadorHumano(string nomeJogador, char simbolo)
		{
		 this.Nome=nomeJogador;
		 this.simbolo=simbolo;
		}
				
		public override int ObterJogada(Tabuleiro tab)
	    {
         int coluna;
         while (true)
            {  
             Console.Write("\nJogador {0}, escolha uma coluna (1-7): ",this.Nome);
             if (int.TryParse(Console.ReadLine(), out coluna) && coluna >= 1 && coluna <= 7)
             	return coluna-1;
              else
              {
         	    Console.Clear();
         	    tab.DesenharTabuleiro();
                Console.Write("\nEntrada inválida.");
              }
             }
	     }
    }
}
