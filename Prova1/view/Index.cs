using System;
using Prova1.controller;

namespace Prova1
{
    class Index
    {
        static void Main(string[] args)
        {
            int verfChos = -1;
            Tree tree = new Tree();
            do
            {
                Console.WriteLine("\n---Prova 1---" +
                                    "\nOpções:" +
                                    "\n1 - Pos-Ordem" +
                                    "\n2 - In-Ordem" +
                                    "\n0 - Sair");
                Console.Write("Opção Escolhida: ");
                verfChos = Convert.ToInt32(Console.ReadLine());
                switch (verfChos)
                {
                    case 1:
                        Console.WriteLine("Insira a sequência de nós separados por '-': ");
                        string sequenciaNosPos = Console.ReadLine();
                        tree.posOrdem(sequenciaNosPos);
                        tree.ViewTree(); //até eu construir a visualização mais bonita
                        break;
                    case 2:
                        Console.WriteLine("Insira a sequência de nós separados por '-': ");
                        string sequenciaNosIn = Console.ReadLine();
                        tree.inOrdem(sequenciaNosIn);
                        tree.ViewTree(); //até eu construir a visualização mais bonita
                        break;
                }
            } while (verfChos != 0);
        }
    }
}
