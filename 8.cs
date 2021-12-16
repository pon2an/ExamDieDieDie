using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exam8
{
    class Node
    {
        public int DecayCount;
        public char Ray;
        public Node Next;

        public Node(int decayCountValue, char rayValue)
        {
            DecayCount = decayCountValue;
            Ray = rayValue;
        }
    }

    class Queue
    {
        private Node Root;

        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }

        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
    }

    class Program
    {
        static char GetNextRay(char ray)
        {
            switch (ray)
            {
                case 'A':
                    return 'B';
                case 'B':
                    return 'C';
                case 'C':
                    return 'D';
                case 'D':
                    return 'E';
                case 'E':
                    return 'A';
                default:
                    return '?';
            }
        }

        static void Main(string[] args)
        {
            Queue moleculeQueue = new Queue();

            int decayCount;
            char ray;
            while (true)
            {
                decayCount = int.Parse(Console.ReadLine());
                if (decayCount < 0)
                {
                    break;
                }
                ray = char.Parse(Console.ReadLine());
                Node molecule = new Node(decayCount, ray);
                moleculeQueue.Push(molecule);
            }

            Node decayMolecule;
            while (true)
            {
                decayMolecule = moleculeQueue.Pop();
                if (decayMolecule == null)
                {
                    break;
                }
                Console.Write(decayMolecule.Ray);
                if (decayMolecule.DecayCount > 1)
                {
                    Node childMolecule1 = new Node(decayMolecule.DecayCount - 1, GetNextRay(decayMolecule.Ray));
                    Node childMolecule2 = new Node(decayMolecule.DecayCount - 1, GetNextRay(decayMolecule.Ray));
                    moleculeQueue.Push(childMolecule1);
                    moleculeQueue.Push(childMolecule2);
                }
            }
        }
    }

    //class Program
    //{
    //    static string ConvertToInfix(ref Stack stack)
    //    {
    //        string result = "";
    //        if (!stack.IsRootNull())
    //        {
    //            Node node = stack.Pop();
    //            if (node.Type == NodeType.Operator)
    //            {
    //                result = ConvertToInfix(ref stack) + ")";
    //                result = node.Value + result;
    //                result = "(" + ConvertToInfix(ref stack) + result;
    //            }
    //            else
    //            {
    //                result = node.Value;
    //            }
    //        }
    //        return result;
    //    }



    //แปะ
    //static void Main(string[] args)
    //{
    //    Stack stack = new Stack();

    //    string[] allowedOperator = { "A", "B", "C", "D" , "E" };
    //    int input = Console.WriteLine();
    //    ;
    //    while (true)
    //    {
    //        input = Console.ReadLine();

    //        Node node;
    //        if (input == "")
    //        {
    //            break;
    //        }
    //        else if (Array.IndexOf(allowedOperator, input) == -1)
    //        {
    //            node = new Node(NodeType.Operand, input);
    //        }
    //        else
    //        {
    //            node = new Node(NodeType.Operator, input);
    //        }

    //        stack.Push(node);
    //    }

    //    Console.WriteLine(ConvertToInfix(ref stack));

    //{
    //    Stack<string> stack = new Stack<string>();
    //    stack.Push("A");
    //    stack.Push("B");
    //    stack.Push("C");
    //    stack.Push("D");
    //    stack.Push("E");
    //    stack.Pop();
    //    Console.WriteLine(stack.Peek());

    //    Queue<int> queue = new Queue<int>();
    //    queue.Enqueue(1);
    //    queue.Dequeue();
    //    Console.WriteLine(queue.Peek());

    //    Console.ReadLine();
    //}

}