// <copyright file="BaseClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MerchantsGuideToTheGalaxy
{
    using System.Collections.Generic;

    /// <summary>
    /// Base class
    /// </summary>
    internal class BaseClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClass" /> class 
        /// </summary>
        public BaseClass()
        {
            this.Primitives = new Dictionary<string, RomanNumber>();
            this.Units = new Dictionary<string, double>();
            this.Questions = new List<string>();
        }

        /// <summary>
        /// Gets or sets symbols unit
        /// </summary>
        public string PrimUnit { get; set; }

        /// <summary>
        /// Gets or sets Primitives
        /// </summary>
        public Dictionary<string, RomanNumber> Primitives { get; set; }

        /// <summary>
        /// Gets or sets unit
        /// </summary>
        public Dictionary<string, double> Units { get; set; }

        /// <summary>
        /// Gets or sets all questions
        /// </summary>
        public List<string> Questions { get; set; }
    }
}
