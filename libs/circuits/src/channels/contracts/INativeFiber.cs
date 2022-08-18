//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeFiber
    {
        /// <summary>
        /// The channel over which the fiber is defined
        /// </summary>
        INativeChannel Source {get;}

        /// <summary>
        /// The selected cell
        /// </summary>
        uint Cell {get;}

        /// <summary>
        /// The offset of the fiber within the cell
        /// </summary>
        ushort Offset {get;}

        /// <summary>
        /// The fiber width
        /// </summary>
        byte Width {get;}
    }

    [Free]
    public interface INativeFiber<T> : INativeFiber
        where T : unmanaged, INativeChannel
    {
        /// <summary>
        /// The channel over which the fiber is defined
        /// </summary>
        new T Source {get;}

        INativeChannel INativeFiber.Source
            => NativeChannels.channel(Source.CellCount, Source.CellWidth, Source.Mask);
    }
}