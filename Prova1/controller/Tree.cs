using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prova1.model;

namespace Prova1.controller
{
    class Tree
    {
        private Node root;
        public Tree()
        {
        }
        public void AddRoot(int value)
        {
            root = new Node(value, null);
        }
        public void Add(int value)
        {
            Add(null, value);
        }
        protected virtual void Add(Node node, int value)
        {
            if (node == null)
            {
                node = root;
            }
            if (value < node.value)
            {
                if (node.left == null)
                    node.left = new Node(value, node);
                else
                {
                    Add(node.left, value);
                    node.left.father = node;
                }
            }
            else
            {
                if (node.right == null)
                    node.right = new Node(value, node);
                else
                {
                    Add(node.right, value);
                    node.right.father = node;
                }
            }
        }
        public void ViewTree()
        {
            Console.WriteLine("\nVisualização da Árvore: ");
            Console.WriteLine("  Root: Node - {0}", root.value);
            ViewTree(root);
        }
        protected virtual void ViewTree(Node node)
        {
            if (node.left != null)
            {
                Console.WriteLine("  Esquerda do '{0}': Node - {1}", node.value, node.left.value);
                ViewTree(node.left);
            }
            if (node.right != null)
            {
                Console.WriteLine("  Direita do '{0}': Node - {1}", node.value, node.right.value);
                ViewTree(node.right);
            }
        }
        public void inOrdem(string sequenciaNos)
        {
            string[] todosNosString = sequenciaNos.Split("-");
            int tamanhoSequencia = todosNosString.Length;
            int[] todosNosInt = new int[tamanhoSequencia];

            for (int i = 0; i < tamanhoSequencia; i++)
            {
                int transf = Int32.Parse(todosNosString[i]);
                todosNosInt[i] = transf;
            }

            AddRoot(todosNosInt[1]);
            todosNosInt = todosNosInt.Where(val => val != todosNosInt[1]).ToArray();

            foreach (int no in todosNosInt)
            {
                Add(no);
            }
        }
        public void posOrdem(string sequenciaNos)
        {
            string[] todosNosString = sequenciaNos.Split("-");
            int tamanhoSequencia = todosNosString.Length;
            int[] todosNosInt = new int[tamanhoSequencia];

            for (int i = 0; i < tamanhoSequencia; i++)
            {
                int transf = Int32.Parse(todosNosString[i]);
                todosNosInt[i] = transf;
            }

            Tree treeTemp = new Tree();
            treeTemp.AddRoot(todosNosInt[tamanhoSequencia - 1]);
            todosNosInt = todosNosInt.Where(val => val != todosNosInt[tamanhoSequencia - 1]).ToArray();

            foreach (int no in todosNosInt)
            {
                treeTemp.Add(no);
            }

            List<int> lrn = new List<int>();
            lrn = LRN(treeTemp.root, lrn);
            int[] novaListaNos = lrn.ToArray();
            AddRoot(novaListaNos[novaListaNos.Length - 1]);
            novaListaNos = novaListaNos.Where(val => val != novaListaNos[tamanhoSequencia - 1]).ToArray();

            foreach (int no in novaListaNos)
            {
                Add(no);
            }
        }
        private List<int> LRN(Node node, List<int> lrn)
        {
            if (node.left != null)
            {
                LRN(node.left, lrn);
            }
            if (node.right != null)
            {
                LRN(node.right, lrn);
            }
            lrn.Add(node.value);
            return lrn;
        }
    }
}
