//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public record struct TargetInfo
        {
            public string Framework;

            public string Runtime;

            public string RuntimeSignature;

            public bool IsPortable;
        }
    }
}