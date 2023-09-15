//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

/// <summary>
/// https://learn.microsoft.com/en-us/cpp/cpp/declspec?view=msvc-170
/// </summary>
public class DeclSpecs
{
    public sealed record Align : DeclSpec<Align,uint>, IAstFactory<uint,Align>
    {        
        public const string Keyword = "align";

        public static Align create(uint width) => new(width);

        public Align(uint width)
            : base(Keyword)
        {

        }        
    }
}