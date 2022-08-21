//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INumericWidth : ICellWidth
    {
        /// <summary>
        /// Defines a class specifier synonym to facilitate disambiguation
        /// </summary>
        NumericWidth NumericWidth
             => (NumericWidth)BitWidth;
    }

    public interface INumericWidth<W> : INumericWidth, ITypeWidth<W>
        where W : struct, INumericWidth<W>
    {

    }
}