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
	/// Description of Jogador.
	/// </summary>
	public class Jogador
	{
		protected string Nome;
		public char simbolo;

		public Jogador()
		{
		}


		public override string ToString()
		{
		return this.Nome;
		}

	
		public virtual int ObterJogada(Tabuleiro tab)
		{
		 return 0;
		}
		
		public virtual int ObterJogadaMaquina(Tabuleiro tab, Jogo jog)
		{
			return 0;
		}
		

		
	}
}
