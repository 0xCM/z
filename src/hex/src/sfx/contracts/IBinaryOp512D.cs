//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a vectorized binary operator over 256-bit operands that is accompanied by componentwise decomposition/evaluation
/// </summary>
/// <typeparam name="T">The vector component type</typeparam>
[Free, SFx]
public interface IBinaryOp512D<T> : IBinaryOp512<T>, IBinaryOp<T>
    where T : unmanaged
{

}
