//-----------------------------------------------------------------------
// <copyright file="PrimitiveSolver.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy.Resolvers
{
    using System;
    using MerchantsGuideToTheGalaxy.Abstract;

    /// <summary>
    ///
    /// </summary>
    internal class PrimitiveSolver : Solver
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ctx"></param>
        public PrimitiveSolver(BaseClass ctx)
            : base(ctx)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public override bool Solve(string question, out string answer)
        {
            var qulifier = "how much is";
            if (!question.StartsWith(qulifier))
            {
                answer = null;
                return false;
            }

            var body = question.Substring(qulifier.Length + 1);
            var value = RepeatChecker.Check(body, this.Context.Primitives).Calculate();
            answer = value.ToString();
            Console.WriteLine(body + " is " + answer);
            return true;
        }
    }
}
