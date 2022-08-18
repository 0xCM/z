//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAsmRelInst : IAsmInstruction
    {
        AsmMnemonic Mnemonic {get;}

        NativeSize RelSize {get;}

        LocatedSymbol Source {get;}

        LocatedSymbol Target {get;}

        MemoryAddress SourceAddress
            => Source.Location;

        MemoryAddress TargetAddress
            => Target.Location;
    }

    [Free]
    public interface IAsmRelInst<T> : IAsmRelInst
        where T : unmanaged, IDisplacement
    {
        T Disp {get;}

        NativeSize IAsmRelInst.RelSize
            => Sizes.native(Sized.width<T>());
    }
}