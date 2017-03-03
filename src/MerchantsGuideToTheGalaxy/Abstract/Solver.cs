// <copyright file="Solver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MerchantsGuideToTheGalaxy.Abstract
{
    /// <summary>
    /// Solver class for input
    /// </summary>
    internal abstract class Solver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Solver" /> class 
        /// </summary>
        /// <param name="ctx">Base class object</param>
        public Solver(BaseClass ctx)
        {
            this.Context = ctx;
        }

        /// <summary>
        /// Gets Base class context
        /// </summary>
        public BaseClass Context { get; private set; }
       
        /// <summary>
        /// Solve input questions
        /// </summary>
        /// <param name="input">input from file</param>
        /// <param name="answer">return answer string</param>
        /// <returns>true if solved, false otherwise</returns>
        public abstract bool Solve(string input, out string answer);
    }
}
