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

namespace CenterCLR.XorRandomGenerator.Internals
{
	internal struct XorRandom
	{
		private uint seed0_;
		private uint seed1_;
		private uint seed2_;
		private uint seed3_;

		public XorRandom(uint seed)
		{
			seed0_ = 1812433253U * (seed ^ (seed >> 30)) + 1U;
			seed1_ = 1812433253U * (seed0_ ^ (seed0_ >> 30)) + 1U;
			seed2_ = 1812433253U * (seed1_ ^ (seed1_ >> 30)) + 1U;
			seed3_ = 1812433253U * (seed2_ ^ (seed2_ >> 30)) + 1U;
		}

		public uint Next()
		{
			var t = seed0_ ^ (seed0_ << 11);

			seed0_ = seed1_;
			seed1_ = seed2_;
			seed2_ = seed3_;
			seed3_ = (seed3_ ^ (seed3_ >> 19)) ^ (t ^ (t >> 8));

			return seed3_;
		}
	}
}
