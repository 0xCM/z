//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ApiUri
    {
        readonly Seq<string> Data;

        [MethodImpl(Inline)]
        public ApiUri(params string[] parts)
        {
            Data = parts;
        }

        public ReadOnlySpan<string> Parts
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }
    }
}