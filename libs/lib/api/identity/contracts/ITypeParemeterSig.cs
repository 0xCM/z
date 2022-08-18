//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISigTypeParam
    {
        ushort Position {get;}

        string Name {get;}

        ApiTypeSig Closure => ApiTypeSig.Empty;

        bool IsClosed => Closure.IsNonEmpty;

        bool IsOpen => Closure.IsEmpty;
    }

    public interface IClosedSigParam : ISigTypeParam
    {
        bool ISigTypeParam.IsClosed
            => true;
    }

    public interface IOpenSigParam : ISigTypeParam
    {
        bool ISigTypeParam.IsClosed
            => false;
    }
}