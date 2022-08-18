//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a tool option
    /// </summary>
    [Free]
    public interface IOptionSpec : ITextual
    {
        @string Name {get;}

        @string Description {get;}
    }

    /// <summary>
    /// Characterizes a kinded tool option
    /// </summary>
    [Free]
    public interface IOptionSpec<K> : IOptionSpec
        where K : unmanaged
    {
        K Kind {get;}

        @string IOptionSpec.Name
            => Kind.ToString();
    }
}