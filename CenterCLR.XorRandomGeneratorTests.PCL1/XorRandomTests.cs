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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CenterCLR.XorRandomGenerator.Tests
{
    [TestClass]
    public class RandomTests
    {
        private static void AssertValues(ushort[] values, int countMultiply)
        {
            Parallel.ForEach(
                values,
                count =>
                {
                    Assert.IsTrue(
                        (count >= (29000 * countMultiply) &&
                        (count <= (31000 * countMultiply))));
                });
        }

        [TestMethod]
        public void GenerateRandomValuesTest()
        {
            Parallel.Invoke(
                () =>
                {
                    var r = new XorRandom();
                    var valueCounts = new ushort[65536];
                    for (ulong count = 0; count < (65536UL * 30000); count++)
                    {
                        var value32 = r.Next();
                        valueCounts[value32 & 0xffff]++;
                    }

                    AssertValues(valueCounts, 1);
                },
                () =>
                {
                    var r = new XorRandom();
                    var valueCounts = new ushort[32768];
                    for (ulong count = 0; count < (32768UL * 30000); count++)
                    {
                        var value32 = r.Next();
                        valueCounts[value32 >> 16]++;
                    }

                    AssertValues(valueCounts, 1);
                });
        }

        [TestMethod]
        public unsafe void GenerateRandomValuesByNextBytesTest()
        {
            var r = new XorRandom();

            var buffer = new byte[2560 * 4];
            var valueCounts1 = new ushort[65536];
            for (ulong count = 0; count < (65536UL * 30000 / 2560); count++)
            {
                r.NextBytes(buffer);

                fixed (byte* pBuffer = buffer)
                {
                    ushort* p = (ushort*)pBuffer;
                    for (var index = 0; index < (buffer.Length / 2); index++)
                    {
                        var value16 = p[index];
                        valueCounts1[value16]++;
                    }
                }
            }

            AssertValues(valueCounts1, 2);
        }

        [TestMethod]
        public void GenerateRandomValuesByNextValuesTest()
        {
            Parallel.Invoke(
                () =>
                {
                    var r = new XorRandom();

                    var buffer = new int[2560];
                    var valueCounts = new ushort[65536];
                    for (ulong count = 0; count < (65536UL * 30000 / 2560); count++)
                    {
                        r.NextValues(buffer);

                        for (var index = 0; index < buffer.Length; index++)
                        {
                            var value32 = (uint)buffer[index];
                            valueCounts[value32 & 0xffff]++;
                        }
                    }

                    AssertValues(valueCounts, 1);
                },
                () =>
                {
                    var r = new XorRandom();

                    var buffer = new int[2560];
                    var valueCounts = new ushort[32768];
                    for (ulong count = 0; count < (32768UL * 30000 / 2560); count++)
                    {
                        r.NextValues(buffer);

                        for (var index = 0; index < buffer.Length; index++)
                        {
                            var value32 = (uint)buffer[index];
                            valueCounts[value32 >> 16]++;
                        }
                    }

                    AssertValues(valueCounts, 1);
                });
        }

        [TestMethod]
        public void GenerateRandomValuesBySampleTest()
        {
            var r = new XorRandom();

            var valueCounts = new ushort[100000];
            for (ulong count = 0; count < (100000UL * 30000); count++)
            {
                var value = r.InternalSample();
                var index = (int)(value * 100000);
                valueCounts[index]++;
            }

            AssertValues(valueCounts, 1);
        }

        [TestMethod]
        public void GenerateRandomValuesByMaxTest()
        {
            var r = new XorRandom();

            var valueCounts = new ushort[100000];
            for (ulong count = 0; count < (100000UL * 30000); count++)
            {
                var value = r.Next(99999);
                valueCounts[value]++;
            }

            AssertValues(valueCounts, 1);
        }

        [TestMethod]
        public void GenerateRandomValuesByMaxAndMinTest()
        {
            var r = new XorRandom();

            var valueCounts = new ushort[50000];
            for (ulong count = 0; count < (50000UL * 30000); count++)
            {
                var value = r.Next(50000, 99999);
                valueCounts[value - 50000]++;
            }

            AssertValues(valueCounts, 1);
        }
    }
}
