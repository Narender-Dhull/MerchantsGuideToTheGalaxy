//-----------------------------------------------------------------------
// <copyright file="QuestionParser.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy.Parsers
{
    using MerchantsGuideToTheGalaxy.Abstract;

    /// <summary>
    ///
    /// </summary>
    internal class QuestionParser : Parser
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="ctx"></param>
        public QuestionParser(BaseClass ctx)
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
            if (!input.EndsWith("?"))
            {
                return false;
            }

            this.Context.Questions.Add(input.Replace("?", string.Empty).Trim());
            return true;
        }
    }
}
