//-----------------------------------------------------------------------
// <copyright file="RomanNumber.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Roman Number
    /// </summary>
    internal class RomanNumber
    {
        /// <summary>
        /// List of all primitives and values
        /// </summary>
        private static ILookup<char, RomanNumber> primitives = new List<RomanNumber>
        {
                new RomanNumber('I', 1, true, true),
                new RomanNumber('V', 5),
                new RomanNumber('X', 10, true, true),
                new RomanNumber('L', 50),
                new RomanNumber('C', 100, true, true),
                new RomanNumber('D', 500),
                new RomanNumber('M', 1000, true),
            }.ToLookup(m => m.NumberSymbol);

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanNumber" /> class 
        /// </summary>
        /// <param name="numberSymbol">Roman number symbol</param>
        /// <param name="symbolValue">Symbol value</param>
        /// <param name="allowRepeat">can number is allowed to repeat</param>
        /// <param name="allowSubtract">allow subtract</param>
        private RomanNumber(char numberSymbol, int symbolValue, bool allowRepeat = false, bool allowSubtract = false)
            {
                this.NumberSymbol = numberSymbol;
                this.SymbolValue = symbolValue;
                this.AllowRepeat = allowRepeat;
                this.AllowSubtract = allowSubtract;
            }

        /// <summary>
        /// Gets SymbolValue
        /// </summary>
        public int SymbolValue
            {
                get;
                private set;
            }

        /// <summary>
        /// Gets NumberSymbol
        /// </summary>
        public char NumberSymbol
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets a value indicating whether
            /// </summary>
            public bool AllowRepeat
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets a value indicating whether
            /// </summary>
            public bool AllowSubtract
            {
                get;
                private set;
            }

            /// <summary>
            /// check if primitives contains symbol
            /// </summary>
            /// <param name="symbol">symbol coming from input</param>
            /// <returns>first symbol</returns>
            public static RomanNumber Parse(char symbol)
            {
                if (!primitives.Contains(symbol))
                {
                    return null;
                }

                return primitives[symbol].First();
            }
        }
    }