// Copyright (c) 2007-2010 SlimDX Group
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

//------------------------------------------------------------------------------
// <auto-generated>
//     Structs for SlimDX2.XAudio2 namespace.
//     This code was generated by a tool.
//     Date : 11/15/2010 14:52:48
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;

namespace SlimDX2.XAudio2 {

    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_DEVICE_DETAILS</unmanaged>
    public  partial struct DeviceDetails {	
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>wchar_t DeviceID[256]</unmanaged>
        public string DeviceID;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>wchar_t DisplayName[256]</unmanaged>
        public string DisplayName;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>XAUDIO2_DEVICE_ROLE Role</unmanaged>
        public SlimDX2.XAudio2.DeviceRole Role;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>WAVEFORMATEXTENSIBLE OutputFormat</unmanaged>
        public SlimDX2.Windows.WaveFormatExtensible OutputFormat;

        // Internal native struct used for marshalling
        [StructLayout(LayoutKind.Sequential, Pack = 1 )]
        internal unsafe partial struct __Native {	
            public fixed char DeviceID[256];
            public fixed char DisplayName[256];
            public SlimDX2.XAudio2.DeviceRole Role;
            public SlimDX2.Windows.WaveFormatExtensible.__Native OutputFormat;
		    // Method to free native struct
            internal unsafe void __MarshalFree()
            {
                this.OutputFormat.__MarshalFree();
            }
        }
		// Method to marshal from native to managed struct
        internal unsafe void __MarshalFrom(ref __Native @ref)
        {            
            fixed (char* __ptr = @ref.DeviceID) this.DeviceID = new string(__ptr, 0, 256);
            fixed (char* __ptr = @ref.DisplayName) this.DisplayName = new string(__ptr, 0, 256);
            this.Role = @ref.Role;
            this.OutputFormat = new SlimDX2.Windows.WaveFormatExtensible();
			this.OutputFormat.__MarshalFrom(ref @ref.OutputFormat);
        }
        // Method to marshal from managed struct tot native
        internal unsafe void __MarshalTo(ref __Native @ref)
        {
            fixed (char* __psrc = this.DeviceID) fixed (char* __ptr = @ref.DeviceID) Utilities.CopyMemory((IntPtr)__ptr, (IntPtr)__psrc, DeviceID.Length * 2);
            fixed (char* __psrc = this.DisplayName) fixed (char* __ptr = @ref.DisplayName) Utilities.CopyMemory((IntPtr)__ptr, (IntPtr)__psrc, DisplayName.Length * 2);
            @ref.Role = this.Role;
			@ref.OutputFormat = SlimDX2.Windows.WaveFormatExtensible.__NewNative();
			if (this.OutputFormat != null)
                this.OutputFormat.__MarshalTo(ref @ref.OutputFormat);
		
		}
    }
    
    /// <summary>	
    /// Contains information about the creation flags, input channels, and sample rate of a voice.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_VOICE_DETAILS</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct VoiceDetails {	
        
        /// <summary>	
        ///  Flags used to create the voice; see the individual voice {{interfaces}} for more information. 	
        /// </summary>	
        /// <unmanaged>int CreationFlags</unmanaged>
        public int CreationFlags;
        
        /// <summary>	
        ///  The number of input channels the voice expects. 	
        /// </summary>	
        /// <unmanaged>int InputChannels</unmanaged>
        public int InputChanneCount;
        
        /// <summary>	
        ///  The input sample rate the voice expects. 	
        /// </summary>	
        /// <unmanaged>int InputSampleRate</unmanaged>
        public int InputSampleRate;
    }
    
    /// <summary>	
    /// Defines a destination voice that is the target of a send from another voice and specifies whether a filter should be used.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_SEND_DESCRIPTOR</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct VoiceSendDescriptor {	
        
        /// <summary>	
        ///  Indicates whether a filter should be used on data sent to the voice pointed to by pOutputVoice.   Flags can be 0 or XAUDIO2_SEND_USEFILTER. 	
        /// </summary>	
        /// <unmanaged>int Flags</unmanaged>
        public SlimDX2.XAudio2.VoiceSendFlags Flags;
        
        /// <summary>	
        ///  A pointer to an <see cref="SlimDX2.XAudio2.Voice"/> that will be the target of the send.   The pOutputVoice member cannot be NULL. 	
        /// </summary>	
        /// <unmanaged>IXAudio2Voice* pOutputVoice</unmanaged>
        internal IntPtr OutputVoicePointer;
    }
    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_VOICE_SENDS</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    internal  partial struct VoiceSendDescriptors {	
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int SendCount</unmanaged>
        public int SendCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>XAUDIO2_SEND_DESCRIPTOR* pSends</unmanaged>
        internal IntPtr SendPointer;
    }
    
    /// <summary>	
    /// Contains information about an {{XAPO}} for use  in an effect chain.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_EFFECT_DESCRIPTOR</unmanaged>
    public  partial class EffectDescriptor {	
        
        /// <summary>	
        ///  Pointer to the IUnknown interface of the  {{XAPO}} object. 	
        /// </summary>	
        /// <unmanaged>IUnknown* pEffect</unmanaged>
        internal IntPtr EffectPointer;
        
        /// <summary>	
        ///  TRUE if the effect should begin in the enabled state. Otherwise, FALSE. 	
        /// </summary>	
        /// <unmanaged>BOOL InitialState</unmanaged>
        public bool InitialState { 
            get { 
                return (_InitialState!=0)?true:false; 
            }
            set { 
                _InitialState = value?1:0;
            }
        }
        internal int _InitialState;
        
        /// <summary>	
        ///  Number of output channels the effect should produce. 	
        /// </summary>	
        /// <unmanaged>int OutputChannels</unmanaged>
        public int OutputChannelCount;

        // Internal native struct used for marshalling
        [StructLayout(LayoutKind.Sequential, Pack = 1 )]
        internal unsafe partial struct __Native {	
            public IntPtr EffectPointer;
            public int _InitialState;
            public int OutputChannelCount;
		    // Method to free native struct
            internal unsafe void __MarshalFree()
            {
            }
        }
		// Method to marshal from native to managed struct
        internal unsafe void __MarshalFrom(ref __Native @ref)
        {            
            this.EffectPointer = @ref.EffectPointer;
            this._InitialState = @ref._InitialState;
            this.OutputChannelCount = @ref.OutputChannelCount;
        }
        // Method to marshal from managed struct tot native
        internal unsafe void __MarshalTo(ref __Native @ref)
        {
            @ref.EffectPointer = this.EffectPointer;
            @ref._InitialState = this._InitialState;
            @ref.OutputChannelCount = this.OutputChannelCount;
		
		}
    }
    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_EFFECT_CHAIN</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    internal  partial struct EffectChain {	
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int EffectCount</unmanaged>
        public int EffectCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>XAUDIO2_EFFECT_DESCRIPTOR* pEffectDescriptors</unmanaged>
        internal IntPtr EffectDescriptorPointer;
    }
    
    /// <summary>	
    /// Defines filter parameters for a source voice.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_FILTER_PARAMETERS</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct FilterParameters {	
        
        /// <summary>	
        ///  An <see cref="SlimDX2.XAudio2.FilterType"/> indicating whether the filter is low pass, band pass, high pass, or notch. 	
        /// </summary>	
        /// <unmanaged>XAUDIO2_FILTER_TYPE Type</unmanaged>
        public SlimDX2.XAudio2.FilterType Type;
        
        /// <summary>	
        ///  Filter radian frequency calculated as (2 * sin(pi * (desired filter cutoff frequency) / sampleRate)).  The frequency must be greater than or equal to 0 and less than or equal to XAUDIO2_MAX_FILTER_FREQUENCY.  The maximum frequency allowable is equal to the source sound's sample rate divided by six which corresponds  to the maximum filter radian frequency of 1. For example, if a sound's sample rate is 48000 and the desired  cutoff frequency is the maximum allowable value for that sample rate, 8000, the value for  Frequency will be 1. If XAUDIO2_HELPER_FUNCTIONS is defined, XAudio2.h will include the {{XAudio2RadiansToCutoffFrequency}} and {{XAudio2CutoffFrequencyToRadians}} helper functions for converting between hertz and radian frequencies. 	
        /// </summary>	
        /// <unmanaged>float Frequency</unmanaged>
        public float Frequency;
        
        /// <summary>	
        ///  Reciprocal of Q factor.  Controls how quickly frequencies beyond Frequency are dampened. Larger values result in quicker dampening while smaller values cause dampening to occur more gradually. Must be greater  than 0 and less than or equal to XAUDIO2_MAX_FILTER_ONEOVERQ. 	
        /// </summary>	
        /// <unmanaged>float OneOverQ</unmanaged>
        public float OneOverQ;
    }
    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_BUFFER</unmanaged>
    public  partial class AudioBuffer {	
        
        /// <summary>Constant None.</summary>
        public const int LoopInfinite = 255;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int Flags</unmanaged>
        public SlimDX2.XAudio2.BufferFlags Flags;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int AudioBytes</unmanaged>
        public int AudioBytes;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>const byte* pAudioData</unmanaged>
        internal IntPtr AudioDataPointer;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int PlayBegin</unmanaged>
        public int PlayBegin;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int PlayLength</unmanaged>
        public int PlayLength;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int LoopBegin</unmanaged>
        public int LoopBegin;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int LoopLength</unmanaged>
        public int LoopLength;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int LoopCount</unmanaged>
        public int LoopCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>void* pContext</unmanaged>
        public IntPtr Context;

        // Internal native struct used for marshalling
        [StructLayout(LayoutKind.Sequential, Pack = 1 )]
        internal unsafe partial struct __Native {	
            public SlimDX2.XAudio2.BufferFlags Flags;
            public int AudioBytes;
            public IntPtr AudioDataPointer;
            public int PlayBegin;
            public int PlayLength;
            public int LoopBegin;
            public int LoopLength;
            public int LoopCount;
            public IntPtr Context;
		    // Method to free native struct
            internal unsafe void __MarshalFree()
            {
            }
        }
		// Method to marshal from native to managed struct
        internal unsafe void __MarshalFrom(ref __Native @ref)
        {            
            this.Flags = @ref.Flags;
            this.AudioBytes = @ref.AudioBytes;
            this.AudioDataPointer = @ref.AudioDataPointer;
            this.PlayBegin = @ref.PlayBegin;
            this.PlayLength = @ref.PlayLength;
            this.LoopBegin = @ref.LoopBegin;
            this.LoopLength = @ref.LoopLength;
            this.LoopCount = @ref.LoopCount;
            this.Context = @ref.Context;
        }
        // Method to marshal from managed struct tot native
        internal unsafe void __MarshalTo(ref __Native @ref)
        {
            @ref.Flags = this.Flags;
            @ref.AudioBytes = this.AudioBytes;
            @ref.AudioDataPointer = this.AudioDataPointer;
            @ref.PlayBegin = this.PlayBegin;
            @ref.PlayLength = this.PlayLength;
            @ref.LoopBegin = this.LoopBegin;
            @ref.LoopLength = this.LoopLength;
            @ref.LoopCount = this.LoopCount;
            @ref.Context = this.Context;
		
		}
    }
    
    /// <summary>	
    /// Used with <see cref="SlimDX2.XAudio2.SourceVoice.SubmitSourceBuffer"/> when submitting xWMA data.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_BUFFER_WMA</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct BufferWma {	
        
        /// <summary>	
        ///  Decoded packet cumulative data size array, each element is the number of bytes accumulated  after the corresponding xWMA packet is decoded in order, must have PacketCount elements. 	
        /// </summary>	
        /// <unmanaged>const int* pDecodedPacketCumulativeBytes</unmanaged>
        public IntPtr DecodedPacketCumulativeBytesPointer;
        
        /// <summary>	
        ///  Number of xWMA packets submitted, must be &gt;= 1 and divide evenly into  the respective {{XAUDIO2_BUFFER.AudioBytes}} value passed to  <see cref="SlimDX2.XAudio2.SourceVoice.SubmitSourceBuffer"/>. 	
        /// </summary>	
        /// <unmanaged>int PacketCount</unmanaged>
        public int PacketCount;
    }
    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_VOICE_STATE</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct VoiceState {	
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>void* pCurrentBufferContext</unmanaged>
        public IntPtr Context;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int BuffersQueued</unmanaged>
        public int BuffersQueued;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>__int64 SamplesPlayed</unmanaged>
        public long SamplesPlayed;
    }
    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_PERFORMANCE_DATA</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct PerformanceData {	
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>__int64 AudioCyclesSinceLastQuery</unmanaged>
        public long AudioCyclesSinceLastQuery;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>__int64 TotalCyclesSinceLastQuery</unmanaged>
        public long TotalCyclesSinceLastQuery;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int MinimumCyclesPerQuantum</unmanaged>
        public int MinimumCyclesPerQuantum;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int MaximumCyclesPerQuantum</unmanaged>
        public int MaximumCyclesPerQuantum;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int MemoryUsageInBytes</unmanaged>
        public int MemoryUsageInBytes;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int CurrentLatencyInSamples</unmanaged>
        public int CurrentLatencyInSamples;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int GlitchesSinceEngineStarted</unmanaged>
        public int GlitchesSinceEngineStarted;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int ActiveSourceVoiceCount</unmanaged>
        public int ActiveSourceVoiceCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int TotalSourceVoiceCount</unmanaged>
        public int TotalSourceVoiceCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int ActiveSubmixVoiceCount</unmanaged>
        public int ActiveSubmixVoiceCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int ActiveResamplerCount</unmanaged>
        public int ActiveResamplerCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int ActiveMatrixMixCount</unmanaged>
        public int ActiveMatrixMixCount;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int ActiveXmaSourceVoices</unmanaged>
        public int ActiveXmaSourceVoices;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int ActiveXmaStreams</unmanaged>
        public int ActiveXmaStreams;
    }
    
    /// <summary>	
    /// No documentation.	
    /// </summary>	
    /// <unmanaged>XAUDIO2_DEBUG_CONFIGURATION</unmanaged>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    public  partial struct DebugConfiguration {	
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int TraceMask</unmanaged>
        public int TraceMask;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>int BreakMask</unmanaged>
        public int BreakMask;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>BOOL LogThreadID</unmanaged>
        public bool LogThreadID { 
            get { 
                return (_LogThreadID!=0)?true:false; 
            }
            set { 
                _LogThreadID = value?1:0;
            }
        }
        internal int _LogThreadID;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>BOOL LogFileline</unmanaged>
        public bool LogFileline { 
            get { 
                return (_LogFileline!=0)?true:false; 
            }
            set { 
                _LogFileline = value?1:0;
            }
        }
        internal int _LogFileline;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>BOOL LogFunctionName</unmanaged>
        public bool LogFunctionName { 
            get { 
                return (_LogFunctionName!=0)?true:false; 
            }
            set { 
                _LogFunctionName = value?1:0;
            }
        }
        internal int _LogFunctionName;
        
        /// <summary>	
        /// No documentation.	
        /// </summary>	
        /// <unmanaged>BOOL LogTiming</unmanaged>
        public bool LogTiming { 
            get { 
                return (_LogTiming!=0)?true:false; 
            }
            set { 
                _LogTiming = value?1:0;
            }
        }
        internal int _LogTiming;
    }
}
