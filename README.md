# Random number generator by xor-shift calculation for Portable Class Library

![Random number generator by xor-shift calculation for Portable Class Library](https://raw.githubusercontent.com/kekyo/CenterCLR.XorRandomGenerator/master/CenterCLR.XorRandomGenerator.100.png)

## What is this?

* CenterCLR.XorRandomGenerator is a random number generator by xor-shift calcuration for Portable Class Library.
 * "xor-shift" random generate algorithm is simple xor and shift based calculation.
 * More information, see http://en.wikipedia.org/wiki/Xorshift

* Target platforms:
 * .NET Framework 4.0 or upper.
 * Silverlight 4 or upper.
 * Windows phone 7 or upper.
 * Windows store apps (Windows 8 or upper).
 * Xbox 360.

* Very replaceable, "System.Random class". (Inherited from System.Random class, type-safe, usage-safe)
* Include thread-safe version, named "SafeRandom class".
* Include LINQ extensions (ex: var enumerable = Random.Sequence(1000); )

* NuGet package ID: CenterCLR.XorRandomGenerator (https://www.nuget.org/packages/CenterCLR.XorRandomGenerator/)
* GitHub: https://github.com/kekyo/CenterCLR.XorRandomGenerator.git

* Build requirements:
 * Visual Studio 2012
 * NuBuild Project System (https://visualstudiogallery.msdn.microsoft.com/3efbfdea-7d51-4d45-a954-74a2df51c5d0)

* Enjoy!

* History:
 * 1.0.1.0: Add tests, Add LINQ extensions, Add NextValues method.
 * 1.0.0.0: First release.
