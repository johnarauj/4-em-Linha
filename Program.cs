/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/06/2023
 * Time: 20:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace abc
{
	class Program
	{
		static void Main(string[] args)
        {          

            while (true)
            {
            	Console.WriteLine("Bem-vindo ao 4 em Linha!");
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Jogar contra outro jogador");
                Console.WriteLine("2. Jogar contra a máquina");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Jogar(false);
                        break;
                    case "2":
                        Jogar(true);
                        break;
                    case "3":
                        Console.WriteLine("Obrigado por jogar! Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.Clear();
                        break;
                }
            }
        }

        static void Jogar(bool contraMaquina)
        {
            Console.Clear();
            Console.WriteLine("Iniciando o jogo...");

            Console.Write("\nDigite o nome do 1º jogador: ");
            string jogador1 = Console.ReadLine();
            if (jogador1=="")
            {
		        do
		            {
		            	Console.Clear();
		            	Console.WriteLine("Iniciando o jogo...");
		            	Console.Write("\nNome inválido, por favor digite o nome do primeiro jogador: ");
		            	jogador1 = Console.ReadLine();
		            } while (jogador1=="");
            }

            string jogador2;
            
            if (contraMaquina==true)
            	jogador2 = "XPTO";
            else
            {
               Console.Write("\nDigite o nome do 2º jogador: ");
               jogador2 = Console.ReadLine();
               if (jogador2=="")
                {
		           do
		            {
		            	Console.Clear();
		            	Console.WriteLine("Iniciando o jogo...");
		            	Console.Write("\nNome inválido, por favor digite o nome do Segundo jogador: ");
		            	jogador2 = Console.ReadLine();
		            } while (jogador2=="");
                }
            }

            
            
            Jogo jogo = new Jogo(jogador1, jogador2, contraMaquina);
            jogo.Iniciar();
	
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
            Console.ReadKey();
            Console.Clear();
            
            
        }
	}
}