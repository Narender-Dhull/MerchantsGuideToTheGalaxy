//-----------------------------------------------------------------------
// <copyright file="RepeatChecker.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace MerchantsGuideToTheGalaxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    internal class RepeatChecker
    {
        /// <summary>
        ///
        /// </summary>
        private List<RomanNumber> primitives;

        /// <summary>
        ///
        /// </summary>
        public RepeatChecker()
        {
            this.primitives = new List<RomanNumber>();
        }

        /// <summary>
        /// check if we can repeat symbol
        /// </summary>
        /// <param name="str"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static RepeatChecker Check(string str, Dictionary<string, RomanNumber> map)
        {
            var left = str.Split(' ');
            var number = new StringBuilder();
            for (int i = 0; i < left.Length; i++)
            {
                number.Append(map[left[i]].NumberSymbol);
            }

            var roman = RepeatChecker.Check(number.ToString());
            return roman;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static RepeatChecker Check(string str)
        {
            var roman = new RepeatChecker();
            var chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                roman.primitives.Add(RomanNumber.Parse(chars[i]));
            }

            return roman;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public int Calculate()
        {
            var result = 0;
            var length = this.primitives.Count();
            for (int i = 0; i < length; i++)
            {
                var current = this.primitives[i];
                result += current.SymbolValue;

                if (i == length - 1)
                {
                    return result;
                }

                var next = this.primitives[i + 1];
                if (current.SymbolValue < next.SymbolValue)
                {
                    result = next.SymbolValue - result;
                    i++;
                }
                else if (current.SymbolValue == next.SymbolValue)
                {
                    if (!current.AllowRepeat)
                    {
                        throw new Exception(string.Format("{0} can't be repeated", current.NumberSymbol));
                    }

                    var count = 2;
                    for (int j = i + 2; j < length; j++)
                    {
                        if (this.primitives[j].NumberSymbol != current.NumberSymbol)
                        {
                            break;
                        }

                        count++;
                        result += current.SymbolValue;
                        i++;
                        if (count > 3)
                        {
                            throw new Exception(string.Format("{0} can't be repeated more than 3 times", current.NumberSymbol));
                        }
                    }
                }
            }

            return result;
        }
    }
}
