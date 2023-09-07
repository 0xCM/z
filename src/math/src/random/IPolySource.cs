//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IPolySource : IBoundSource,
    IBoundSource<sbyte>,
    IBoundSource<byte>,
    IBoundSource<short>,
    IBoundSource<ushort>,
    IBoundSource<int>,
    IBoundSource<uint>,
    IBoundSource<long>,
    IBoundSource<ulong>,
    IBoundSource<float>,
    IBoundSource<double>
{

}
