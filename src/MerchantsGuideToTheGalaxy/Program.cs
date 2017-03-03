//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Abstract;
    using Parsers;
    using Resolvers;

    /// <summary>
    /// Main class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Default argument</param>
        public static void Main(string[] args)
        {
            using (TextReader reader = new StreamReader("Problems/Input.txt"))
            {
                var inputs = new List<string>();
                string input = null;
                Console.WriteLine("**Input**\n");

                do
                {
                    input = reader.ReadLine();
                    if (input == null)
                    {
                        break;
                    }

                    Console.WriteLine(input);
                    inputs.Add(input);
                }

                while (input != null);

                Process(inputs.ToArray());
            }
        }

        /// <summary>
        /// Process input and show out put
        /// </summary>
        /// <param name="input">Run main logic</param>
        private static void Process(string[] input)
        {
            Console.WriteLine("\n**Output**\n");

            var baseClass = new BaseClass();

            List<Parser> parsers = new List<Parser>(new Parser[] { new PrimitiveParser(baseClass), new UnitParser(baseClass), new QuestionParser(baseClass) });

            List<Solver> solvers = new List<Solver>(new Solver[] { new PrimitiveSolver(baseClass), new UnitSolver(baseClass) });

            ParseInput(Input: input, AvailableParsers: parsers);
            SolveQuestions(Questions: baseClass.Questions, AvailableSolvers: solvers);

            Console.WriteLine("\n**End**");
            Console.ReadKey();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="AvailableParsers"></param>
        private static void ParseInput(string[] Input, List<Parser> AvailableParsers)
        {
            foreach (var cmd in Input)
            {
                foreach (var parser in AvailableParsers)
                {
                    try
                    {
                        if (parser.Parse(cmd))
                        {
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Questions"></param>
        /// <param name="AvailableSolvers"></param>
        private static void SolveQuestions(dynamic Questions, List<Solver> AvailableSolvers)
        {
            foreach (var cmd in Questions)
            {
                var solved = false;
                foreach (var solver in AvailableSolvers)
                {
                    string answer = string.Empty;
                    try
                    {
                        if (solver.Solve(cmd, out answer))
                        {
                            solved = true;
                            break;
                        }
                    }
                    catch
                    {
                    }
                }

                if (!solved)
                {
                    Console.WriteLine("I have no idea what you are talking about.");
                }
            }
        }
    }
}
