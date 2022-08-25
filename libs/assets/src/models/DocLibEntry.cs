//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResDocInfo
    {
        public readonly Label Name;

        [MethodImpl(Inline)]
        public ResDocInfo(Label name)
        {
            Name = name;
        }

        public FileExt Type
            => FS.file(Name.Format()).Ext;

        public string Format()
            => string.Format("{0,-16} | {1}", Type, Name);
    }
}