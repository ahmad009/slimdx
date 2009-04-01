/*
* Copyright (c) 2007-2008 SlimDX Group
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/
#pragma once

#ifdef WRAP_XAUDIO2

#include "../ComObject.h"
#include "Enums.h"

//using namespace System;

namespace SlimDX
{
	namespace XAudio2
	{
		public value class EffectDescriptor
		{
			//TODO: Figure out a proper type for this
			System::IntPtr Effect;
			bool InitialState;
			int OutputChannels;
		};

		public ref class Voice abstract
		{
		private:
			IXAudio2Voice* InternalPointer;

		protected:
			Voice() { }

			property IXAudio2Voice* Pointer
			{
				IXAudio2Voice* get() { return InternalPointer; }
				void set( IXAudio2Voice* value ) { Construct(value); }
			}
		};
	}
}

#endif //WRAP_XAUDIO2