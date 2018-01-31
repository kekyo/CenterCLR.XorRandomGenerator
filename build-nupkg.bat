@echo off

rem CenterCLR.XorRandomGenerator - Random number generator by xor-shift calculation
rem Copyright (c) Kouji Matsui, All rights reserved.
rem 
rem Redistribution and use in source and binary forms, with or without modification,
rem are permitted provided that the following conditions are met:
rem 
rem * Redistributions of source code must retain the above copyright notice,
rem   this list of conditions and the following disclaimer.
rem * Redistributions in binary form must reproduce the above copyright notice,
rem   this list of conditions and the following disclaimer in the documentation
rem   and/or other materials provided with the distribution.
rem 
rem THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
rem AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
rem THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
rem IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
rem INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
rem (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
rem LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
rem HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
rem OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
rem EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

.nuget\nuget pack CenterCLR.XorRandomGenerator.nuspec -Prop Version=1.1.0 -Prop Configuration=Release
