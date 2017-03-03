//-----------------------------------------------------------------------
// <copyright file="UnitSolver.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy.Resolvers
{
    using System;
    using System.Linq;
    using MerchantsGuideToTheGalaxy.Abstract;

    /// <summary>
    ///
    /// </summary>
    internal class UnitSolver : Solver
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ctx"></param>
        public UnitSolver(BaseClass ctx)
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
            var primUnit = this.Context.PrimUnit;
            var qulifier = string.Format("how many {0} is", primUnit);
            if (!question.StartsWith(qulifier))
            {
                answer = null;
                return false;
            }

            var body = question.Substring(qulifier.Length + 1);
            var lexers = body.Split(' ');
            var unit = lexers.Last().Trim();
            var unitValue = this.Context.Units[unit];
            var value = RepeatChecker.Check(string.Join(" ", lexers.Take(lexers.Length - 1)), this.Context.Primitives).Calculate();
            answer = (value * unitValue) + " " + primUnit;
            Console.WriteLine(body + " is " + answer);
            return true;
        }
    }
}
