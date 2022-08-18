//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    public readonly struct BitFunctionDim
    {
        /// <summary>
        /// The number of input channels
        /// </summary>
        public readonly uint InputChannels;

        /// <summary>
        /// The width of each input channel
        /// </summary>
        public readonly uint InputChannelWidth;

        /// <summary>
        /// The number of output channels
        /// </summary>
        public readonly uint OutputChannels;

        /// <summary>
        /// The width of each output channel
        /// </summary>
        public readonly uint OutputChannelWidth;

        [MethodImpl(Inline)]
        public BitFunctionDim(uint cIn, uint wIn, uint cOut, uint wOut)
        {
            InputChannels = cIn;
            InputChannelWidth = wIn;
            OutputChannels = cOut;
            OutputChannelWidth = wOut;
        }

        public BitWidth TotalInputWidth
        {
            [MethodImpl(Inline)]
            get => InputChannelWidth*InputChannels;
        }

        public BitWidth TotalOutputWidth
        {
            [MethodImpl(Inline)]
            get => OutputChannelWidth*OutputChannels;
        }

        public ByteSize InstanceSize
        {
            [MethodImpl(Inline)]
            get => BitFunctions.size(this);
        }

        public string Format()
            => string.Format("{0}x{1} -> {2}x{3}", InputChannels, InputChannelWidth, OutputChannels, OutputChannelWidth);

        public override string ToString()
            => Format();
    }
}