// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MerchantsGuideToTheGalaxy.Abstract
{
    /// <summary>
    ///  Parser class for all inputs
    /// </summary>
    internal abstract class Parser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser" /> class.
        /// </summary>
        /// <param name="ctx">Base Class</param>
        public Parser(BaseClass ctx)
        {
            this.Context = ctx;
        }

        /// <summary>
        /// Gets base class object
        /// </summary>
        public BaseClass Context { get; private set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        /// <param name="input">input from file</param>
        /// <returns>true if parse, false otherwise</returns>
        public abstract bool Parse(string input);
    }
}
