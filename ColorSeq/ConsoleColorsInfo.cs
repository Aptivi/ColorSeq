/*
 * MIT License
 * 
 * Copyright (c) 2022 Aptivi
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using Newtonsoft.Json.Linq;

namespace ColorSeq
{
    public class ConsoleColorsInfo
    {

        /// <summary>
        /// The color ID
        /// </summary>
        public int ColorID { get; }
        /// <summary>
        /// The red color value
        /// </summary>
        public int R { get; }
        /// <summary>
        /// The green color value
        /// </summary>
        public int G { get; }
        /// <summary>
        /// The blue color value
        /// </summary>
        public int B { get; }
        /// <summary>
        /// Is the color bright?
        /// </summary>
        public bool IsBright { get; }
        /// <summary>
        /// Is the color dark?
        /// </summary>
        public bool IsDark { get; }

        /// <summary>
        /// Makes a new instance of 255-color console color information
        /// </summary>
        /// <param name="ColorValue">A 255-color console color</param>
        public ConsoleColorsInfo(ConsoleColors ColorValue)
        {
            if (!((int)ColorValue < 0 | (int)ColorValue > 255))
            {
                JObject ColorData = (JObject)Color255.ColorDataJson[Convert.ToInt32(ColorValue)];
                ColorID = (int)ColorData["colorId"];
                R = (int)ColorData["rgb"]["r"];
                G = (int)ColorData["rgb"]["g"];
                B = (int)ColorData["rgb"]["b"];
                IsBright = R + 0.2126 + G + 0.7152 + B + 0.0722 > 255 / (double)2;
                IsDark = R + 0.2126 + G + 0.7152 + B + 0.0722 < 255 / (double)2;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(ColorValue), ColorValue, "The color value is outside the range of 0-255.");
        }
    }
}