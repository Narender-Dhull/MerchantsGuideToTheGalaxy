//-----------------------------------------------------------------------
// <copyright file="UnitParser.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy.Parsers
{
    using System;
    using System.Linq;
    using MerchantsGuideToTheGalaxy.Abstract;

    /// <summary>
    ///
    /// </summary>
    internal class UnitParser : Parser
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ctx"></param>
        public UnitParser(BaseClass ctx)
            : base(ctx)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override bool Parse(string input)
        {
            var lexers = input.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (lexers.Count() != 2)
            {
                return false;
            }

            var left = lexers[0].Split(' ');

            if (left.Length < 2)
            {
                return false;
            }

            var rValue = int.Parse(lexers[1].Split(' ')[0]);
            var primUnit = lexers[1].Split(' ')[1];
            this.Context.PrimUnit = primUnit;
            var roman = RepeatChecker.Check(string.Join(" ", left.Take(left.Length - 1)), this.Context.Primitives);
            var calculated = roman.Calculate();

            var unit = left.Last();
            var unitValue = (double)rValue / (double)calculated;

            this.Context.Units[unit] = unitValue;
            return true;
        }
    }
}
