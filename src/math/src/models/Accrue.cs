//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public struct Accrue<I>
    where I : unmanaged
{
    I Total;

    [MethodImpl(Inline)]
    public void Next(I i)
        => Total = gmath.add(Total, i);

    public string Format()
        => Total.ToString();

    public override string ToString()
        => Format();
}
