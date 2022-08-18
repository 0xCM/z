//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiClass : ITextual
    {
        ApiClassKind ClassId {get;}

        string ITextual.Format()
            => ClassId.ToString().ToLower();
    }
}