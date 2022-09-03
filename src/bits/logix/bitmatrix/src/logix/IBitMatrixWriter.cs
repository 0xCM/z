//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IBitMatrixWriter : IArchiveWriter
    {
        void Write<T>(in BitMatrix<T> src)
            where T: unmanaged;

        void Write<M,N,T>(in BitMatrix<M,N,T> src)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged;

        void Write<M,N,T,K>(in BitMatrix<M,N,T> src, K kind)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
            where K: struct, Enum;
    }

    public interface IBitMatrixWriter<H> : IBitMatrixWriter, IArchiveWriter<H>
        where H : struct, IBitMatrixWriter<H>
    {

    }
}