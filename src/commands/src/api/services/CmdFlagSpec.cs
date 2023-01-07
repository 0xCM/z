//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    /// <summary>
    /// Defines a tool flag argument
    /// </summary>
    public readonly record struct CmdFlagSpec
    {
        public static ReadOnlySeq<CmdFlagSpec> load(FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    continue;

                var name = text.trim(Asci.format(SQ.left(content,i)));
                var desc = text.trim(Asci.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        /// <summary>
        /// The flag name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The flag description
        /// </summary>
        public readonly string Description;

        [MethodImpl(Inline)]
        public CmdFlagSpec(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public string Format()
            => string.Format("{1,-34} {2}", Name, Description);

        public override string ToString()
            => Format();
    }
}