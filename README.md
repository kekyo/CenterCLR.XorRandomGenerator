# Random number generator by xor-shift calculation for Portable Class Library

![Random number generator by xor-shift calculation for Portable Class Library](https://raw.githubusercontent.com/kekyo/CenterCLR.XorRandomGenerator/master/CenterCLR.XorRandomGenerator.100.png)

## Status

* NuGet Package: [![NuGet XorRandomGenerator](https://img.shields.io/nuget/v/CenterCLR.XorRandomGenerator.svg?style=flat)](https://www.nuget.org/packages/CenterCLR.XorRandomGenerator)
* Continuous integration: [![AppVeyor XorRandomGenerator](https://img.shields.io/appveyor/ci/kekyo/centerclr-xorrandomgenerator.svg?style=flat)](https://ci.appveyor.com/project/kekyo/centerclr-XorRandomGenerator)

## What is this?

* CenterCLR.XorRandomGenerator is a random number generator by xor-shift calcuration for Portable Class Library.
 * "xor-shift" random generate algorithm is simple xor and shift based calculation.
 * More information, see http://en.wikipedia.org/wiki/Xorshift
* Very replaceable, "System.Random class". (Inherited from System.Random class, type-safe, usage-safe)
* Include thread-safe version, named "SafeRandom class".
* Include LINQ extensions (ex: var enumerable = XorRandom.Sequence(1000); )

## Target platforms
* .NET Framework 2.0 or upper.
* Silverlight 4 or upper.
* Windows phone 7 or upper.
* Windows store apps (Windows 8 or upper).
* Xbox 360.
* .NET Standard 1.0 or upper.
* (PCL Profile 1/259/344)

## Build requirements
* Visual Studio 2017

## History
* 1.1.0:
  * Fixed "Inconsistent behavior between XorRandom and System.Random" #1
  * Add support .NET 4.0 Client / .NET Standard 1.0 / PCL Profile 259
  * Switch environment to Visual Studio 2017
* 1.0.4:
  * Add .NET 2.0.
  * Add dnxcore moniker.
  * Add xml comments.
  * Add strongsign.
  * Change project naming base of PCL profile.
  * Using RelaxVersioner.
* 1.0.3:
  * Random class obsoleted. Try XorRandom class instead.
  * Seed generator improvement.
  * Next(maxValue) implemented.
* 1.0.2: Fixed misconfigure package.
* 1.0.1: Add tests, Add LINQ extensions, Add NextValues method.
* 1.0.0: First release.
