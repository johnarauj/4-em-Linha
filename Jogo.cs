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
	/// Description of Jogo.
	/// </summary>
	public class Jogo
	{
		private Tabuleiro tab;
		private Jogador jogadorX;
        private Jogador jogadorO;
        private string winner;
        private Jogo jog;
        public Jogador currentPlayer; // Jogador atual (começa com X)

        public bool gameOver; // Verifica se o jogo acabou
        
        private bool contraMaquina; // Indica se o jogo é contra a máquina
        public string currentPlayerName;
        
        public Jogo(string winner)
        {
        	this.winner=winner;
        }
        public Jogo(string nomeJogadorX, string nomeJogadorO, bool contraMaquina)
        {         
        	this.jogadorX = new JogadorHumano(nomeJogadorX,'X');
         //this.jogadorX = new JogadorMaquina(nomeJogadorX,'X');
         
         if (contraMaquina==true)
         	this.jogadorO=new JogadorMaquina(nomeJogadorO,'O');
         else
         	this.jogadorO= new JogadorHumano(nomeJogadorO,'O');
         	
         this.currentPlayer=jogadorX;		// primeiro a jogar é o X
         
         this.contraMaquina = contraMaquina;
        }

        public char Iniciar()
        {
        	this.jog=new Jogo(winner);
        	this.tab= new Tabuleiro();
  			this.currentPlayer=jogadorX;		// primeiro a jogar é o X
            gameOver = false;
            int coluna;
            bool pode;
            while (!gameOver)
            {
                tab.DesenharTabuleiro();
                System.Threading.Thread.Sleep(100);
                do
	              {
                	if (currentPlayer==jogadorX)
                		coluna = currentPlayer.ObterJogada(this.tab);
                	//else if (currentPlayer==jogadorO)
                		//coluna = currentPlayer.ObterJogada(this.tab);
                	else
                		coluna=currentPlayer.ObterJogadaMaquina(this.tab, this.jog);
                     pode=tab.EstaColunaDisponivel(coluna);
                     if (pode==false)
                     {
                     	Console.WriteLine("erro...");                     
                     }
                } while (pode==false);
                
                
                RealizarJogada(coluna,currentPlayer.simbolo);			// colocar a Peça

                 	
                if (VerificarVitoria())
                {
                    tab.DesenharTabuleiro();
                  	Console.WriteLine("\n" +
                    	                  "!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                    	                  "\n!!!Jogador {0} ganhou!!!!" +
                    	                  "\n!!!!!!!!!!!!!!!!!!!!!!!!!!",this.currentPlayer);
                    gameOver = true;
                }
                
                else if (VerificarEmpate())
                {
                    tab.DesenharTabuleiro();
                    Console.WriteLine("\n:(:(:(:(:(:(:(:(:(:(:(:" +
                                      "\n:(:(O jogo empatou!:(:(" +
                                      "\n:(:(:(:(:(:(:(:(:(:(:(:");
                    gameOver = true;
                }
                else
                {
                	if (currentPlayer.simbolo=='X')
                		this.currentPlayer = this.jogadorO;
                	else
                		this.currentPlayer = this.jogadorX;
                }
            } 
            return this.currentPlayer.simbolo;
        }
        
       

        private void RealizarJogada(int coluna, char simb)
        {
        	tab.InserirPeca(coluna, simb);
        }

        
       
        
        private bool VerificarVitoria()
        {
        	return tab.VerificarVitoria();
        }

        private bool VerificarEmpate()
        {
        	return tab.TabuleiroCompleto();
        }

       
    }
	}
