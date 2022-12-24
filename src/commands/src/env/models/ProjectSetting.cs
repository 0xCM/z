//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ProjectSetting
    {
        public readonly @string Key;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        internal ProjectSetting(@string key, dynamic value)
        {
            Key = key;
            Value = value;
        }
    }
}