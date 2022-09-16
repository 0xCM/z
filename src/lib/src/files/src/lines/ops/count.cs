//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Lines
    {
        [Op]
        public static uint count(FilePath src, TextEncodingKind encoding)
        {
            var counter = 0u;
            using var reader = src.Reader(encoding);
            var line = reader.ReadLine();
            while(line != null)
            {
                counter++;
                line = reader.ReadLine();
            }

            return counter;
        }
    }
}