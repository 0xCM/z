//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static PartId part(FileName src)
        {
            var i = src.Name.Text.IndexOf(Chars.Dot);
            if(i == NotFound)
                return default;
            else
                return ApiParsers.part(text.segment(src.Name.Text,0, i - 1));
        }
    }
}