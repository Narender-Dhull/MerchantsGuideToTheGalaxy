//-----------------------------------------------------------------------
// <copyright file="PrimitiveParser.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy.Parsers
{
    using System;
    using System.Linq;
    using Abstract;

    /// <summary>
    /// Parser class for Primitives
    /// </summary>
    internal class PrimitiveParser : Parser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser" /> class.
        /// </summary>
        /// <param name="ctx">base class context</param>
        public PrimitiveParser(BaseClass ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Parse input
        /// </summary>
        /// <param name="input">input from file</param>
        /// <returns>length</returns>
        public override bool Parse(string input)
        {
            var lexers = input.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (lexers.Count() != 2)
            {
                return false;
            }

            if (lexers[1].Length > 1)
            {
                return false;
            }

            var roman = RomanNumber.Parse(lexers[1][0]);
            if (roman == null)
            {
                throw new Exception("syntex error.");
            }

            var name = lexers[0].Trim();
            this.Context.Primitives[name] = roman;
            return true;
        }
    }
}
