using System;
using System.Collections.Generic;

namespace Exam9
{
    class Node
    {
        public string Message;

        public Node(string messageValue)
        {
            Message = messageValue;
        }
    }

    class QuestionNode : Node
    {
        public Node Left;
        public Node Right;

        public QuestionNode(string messageValue) : base(messageValue) { }
    }

    class DeceaseNode : Node
    {
        public DeceaseNode(string messageValue) : base(messageValue) { }
    }

    class Program
    {
        static void AddNode(ref Node node)
        {
            Console.WriteLine("Add dependency for SkillName ? (Y/N):");
            char answer = char.Parse(Console.ReadLine());
            if (answer == 'Y')
            {
                string message = Console.ReadLine();
                node = new QuestionNode(message);
                AddNode(ref (node as QuestionNode).Left);
                AddNode(ref (node as QuestionNode).Right);
            }
            else
            {
                string message = Console.ReadLine();
                node = new DeceaseNode(message);
            }
        }

        static void Main(string[] args)
        {
            Node root = null;
            AddNode(ref root);

            Node ptr = root;
            string SkillName = Console.ReadLine();
            Console.WriteLine("Input skill name:");
            Console.WriteLine("Add dependency for"+SkillName+"? (Y/N):");

            while (true)
            {
                Console.WriteLine(ptr.Message);
                if (ptr is QuestionNode)
                {
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'Y')
                    {
                        ptr = (ptr as QuestionNode).Left;
                    }
                    else
                    {
                        ptr = (ptr as QuestionNode).Right;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
