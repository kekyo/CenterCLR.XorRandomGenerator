////////////////////////////////////////////////////////////////////////////////////////////////////
//
// CenterCLR.XorRandomGenerator - Random number generator by xor-shift calculation
// Copyright (c) Kouji Matsui, All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// * Redistributions of source code must retain the above copyright notice,
//   this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
// EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace CenterCLR.XorRandomGenerator
{
    /// <summary>
    /// Extension methods for Random class.
    /// </summary>
    public static class RandomExtension
    {
        /// <summary>
        /// Generate random sequence.
        /// </summary>
        /// <param name="random">Random class instance</param>
        /// <param name="count">Number of random values.</param>
        /// <returns>Random sequence.</returns>
        public static IEnumerable<int> Sequence(this Random random, int count)
        {
            for (var index = 0; index < count; index++)
            {
                yield return random.Next();
            }
        }

        /// <summary>
        /// Generate random sequence.
        /// </summary>
        /// <param name="random">Random class instance</param>
        /// <param name="count">Number of random arrays.</param>
        /// <param name="bytes">Bytes on array.</param>
        /// <returns>Random sequence.</returns>
        public static IEnumerable<byte[]> BytesSequence(this Random random, int count, int bytes)
        {
            for (var index = 0; index < count; index++)
            {
                var buffer = new byte[bytes];
                random.NextBytes(buffer);
                yield return buffer;
            }
        }

        /// <summary>
        /// Generate random sequence.
        /// </summary>
        /// <param name="random">Random class instance</param>
        /// <param name="count">Number of random arrays.</param>
        /// <param name="values">Values on array.</param>
        /// <returns>Random sequence.</returns>
        public static IEnumerable<int[]> ValuesSequence(this Random random, int count, int values)
        {
#if PCL1
            var buffer = new byte[values * sizeof(int)];
            for (var index = 0; index < count; index++)
            {
                random.NextBytes(buffer);
                var buffer2 = new int[values];
                for (var index2 = 0; index2 < values; index2++)
                {
                    buffer2[index2] = BitConverter.ToInt32(buffer, index2*sizeof (int));
                }
                yield return buffer2;
            }
#else
            for (var index = 0; index < count; index++)
            {
                var buffer = new int[values];
                random.NextValues(buffer);
                yield return buffer;
            }
#endif
        }
    }
}
