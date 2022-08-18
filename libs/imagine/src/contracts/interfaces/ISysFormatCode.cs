//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum SysFormatKind : uint
    {
        General = 0,

        Numeric = 1,
    }

    public interface ISysFormatCode : ITextual
    {
        SysFormatKind Kind {get;}

        object Code {get;}

        string ITextual.Format()
            => string.Format("{0}:{1}", Code, Kind);

        string Slot
            => "{0:" +  $"{Code}" + "}";

        string Apply<T>(T src)
            => string.Format(Slot,src);
    }

    public interface ISysFormatCode<K,C> : ISysFormatCode
        where K : unmanaged
    {
        new K Kind {get;}

        SysFormatKind ISysFormatCode.Kind
            => sys.@as<K,SysFormatKind>(Kind);

        new C Code {get;}

        object ISysFormatCode.Code
            => Code;
    }

    public interface ISysFormatCodeHost<H,K,C> : ISysFormatCode<K,C>
        where K : unmanaged
        where H : struct, ISysFormatCodeHost<H,K,C>
    {

    }
}