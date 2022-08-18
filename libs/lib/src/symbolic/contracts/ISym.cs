//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISym : ITextual
    {
        SymKey Key {get;}

        SymIdentity Identity {get;}

        Identifier Type {get;}

        string Group {get;}

        string Name {get;}

        SymExpr Expr {get;}

        ulong Kind {get;}

        SymVal Value {get;}

        TextBlock Description {get;}

        bool Hidden {get;}

        object FieldValue {get;}
    }

    public interface ISym<T> : ISym
        where T : unmanaged
    {
        new T Kind {get;}

        SymVal ISym.Value
            => core.bw64(Kind);

        ulong ISym.Kind
            => Value;

        object ISym.FieldValue
            => Kind;
    }

    public interface ISym<W,T> : ISym<T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {

    }
}