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
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CenterCLR.XorRandomGenerator.Internals.Tests
{
	[TestClass()]
	public class XorRandomTests
	{
		[TestMethod()]
		public void GenerateRandomValuesTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var valueCounts = new ushort[65536];
			for (ulong count = 0; count < (65536UL * 30000); count++)
			{
				var value32 = r.Next();
				valueCounts[value32 & 0xffff]++;
				valueCounts[value32 >> 16]++;
			}

			for (var index = 0; index < valueCounts.Length; index++)
			{
				var count = valueCounts[index];
				Assert.IsTrue((count >= 58000) && (count <= 62000));
			}
		}

		[TestMethod()]
		public void GenerateRandomValuesWithMaxValueTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var valueCounts = new ushort[65536];
			for (ulong count = 0; count < (65536UL * 30000); count++)
			{
				var value32 = r.Next();
				valueCounts[value32 & 0xffff]++;
				valueCounts[value32 >> 16]++;
			}

			for (var index = 0; index < valueCounts.Length; index++)
			{
				var count = valueCounts[index];
				Assert.IsTrue((count >= 58000) && (count <= 62000));
			}
		}

		[TestMethod()]
		public void GenerateRandomValuesByNextValuesTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var buffer = new int[2560];
			var valueCounts = new ushort[65536];
			for (ulong count = 0; count < (65536UL * 30000 / 2560); count++)
			{
				r.NextValues(buffer);

				for (var index = 0; index < buffer.Length; index++)
				{
					var value32 = (uint)buffer[index];
					valueCounts[value32 & 0xffff]++;
					valueCounts[value32 >> 16]++;
				}
			}

			for (var index = 0; index < valueCounts.Length; index++)
			{
				var count = valueCounts[index];
				Assert.IsTrue((count >= 58000) && (count <= 62000));
			}
		}

		[TestMethod()]
		public unsafe void GenerateRandomValuesByNextBytesTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var buffer = new byte[2560 * 4];
			var valueCounts = new ushort[65536];
			for (ulong count = 0; count < (65536UL * 30000 / 2560); count++)
			{
				r.NextBytes(buffer);

				fixed (byte* pBuffer = buffer)
				{
					ushort* p = (ushort*)pBuffer;
					for (var index = 0; index < (buffer.Length / 2); index++)
					{
						var value16 = p[index];
						valueCounts[value16]++;
					}
				}
			}

			for (var index = 0; index < valueCounts.Length; index++)
			{
				var count = valueCounts[index];
				Assert.IsTrue((count >= 58000) && (count <= 62000));
			}
		}

		[TestMethod()]
		public void GenerateRandomValuesTimeTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var sw = new Stopwatch();
			sw.Start();

			for (ulong count = 0; count < (65536UL * 30000); count++)
			{
				var value32 = r.Next();
			}

			sw.Stop();
			Trace.WriteLine("GenerateRandomValuesTimeTest: " + sw.Elapsed);
		}

		[TestMethod()]
		public void GenerateRandomValuesByNextValuesTimeTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var buffer = new int[2560];

			var sw = new Stopwatch();
			sw.Start();

			for (ulong count = 0; count < (65536UL * 30000 / 2560); count++)
			{
				r.NextValues(buffer);
			}

			sw.Stop();
			Trace.WriteLine("GenerateRandomValuesByNextValuesTimeTest: " + sw.Elapsed);
		}

		[TestMethod()]
		public void GenerateRandomValuesByNextBytesTimeTest()
		{
			var r = new XorRandom(Seeder.GetSeed());

			var buffer = new byte[2560 * 4];

			var sw = new Stopwatch();
			sw.Start();

			for (ulong count = 0; count < (65536UL * 30000 / 2560); count++)
			{
				r.NextBytes(buffer);
			}

			sw.Stop();
			Trace.WriteLine("GenerateRandomValuesByNextBytesTimeTest: " + sw.Elapsed);
		}
	}
}
