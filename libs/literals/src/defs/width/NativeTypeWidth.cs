//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = DataWidth;

    /// <summary>
    /// Defines a <see cref="DataWidth"/> subset that is constrained to widths that correspond to scalar primitives or vectorized registers
    /// </summary>
    public enum NativeTypeWidth : ushort
    {
        /// <summary>
        /// Vapid
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a bit-width of 1
        /// </summary>
        /// <remarks>
        /// Ok, this one is synthetic; but it is useful to pretend that the type system
        /// supports 1-bit types
        /// </remarks>
        W1 = (ushort)W.W1,

        /// <summary>
        /// Indicates a bit-width of 8
        /// </summary>
        W8 = (ushort)W.W8,

        /// <summary>
        /// Indicates a bit-width of 16
        /// </summary>
        W16 = (ushort)W.W16,

        /// <summary>
        /// Indicates a bit-width of 32
        /// </summary>
        W32 = (ushort)W.W32,

        /// <summary>
        /// Indicates a bit-width of 64
        /// </summary>
        W64 = (ushort)W.W64,

        /// <summary>
        /// Indicates a bit-width of 128
        /// </summary>
        W128 = (ushort)W.W128,

        /// <summary>
        /// Indicates a bit-width of 256
        /// </summary>
        W256 = (ushort)W.W256,

        /// <summary>
        /// Indicates a bit-width of 512
        /// </summary>
        W512 = (ushort)W.W512,

        /// <summary>
        /// Indicates a bit-width of 1024
        /// </summary>
        W1024 = (ushort)W.W1024,
    }
}