//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IClassifier
    {
        Label Name {get;}

        uint ClassCount {get;}

        ReadOnlySpan<Label> ClassNames {get;}
    }
}