//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        public static Index<ApiCodeRow> apirows(FS.FilePath src)
        {
            var result = Outcome.Success;
            var data = src.ReadLines().Storage.Skip(1);
            var count = data.Length;
            var dst = list<ApiCodeRow>();
            var j=0;
            for(var i=0; i<count; i++)
            {
                result = parse(skip(data,i), out ApiCodeRow row);
                if(result)
                {
                    dst.Add(row);
                    j++;
                }
                else
                    sys.@throw(result.Message);
            }
            return dst.Index();
        }
    }
}