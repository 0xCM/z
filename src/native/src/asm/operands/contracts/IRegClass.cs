//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IRegClass : ITextual
    {
        RegClassCode Kind {get;}

        text7 Name
            => Kind.ToString();

        string ITextual.Format()
            => Name.Format();
    }

    public interface IRegClass<T> : IRegClass
        where T : unmanaged, IRegClass<T>
    {

    }
}