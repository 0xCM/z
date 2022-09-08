//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the content of a binary resource
    /// </summary>
    public readonly struct BinaryResSpec
    {
        public readonly string Name;

        public readonly BinaryCode Encoded;

        [MethodImpl(Inline)]
        public BinaryResSpec(string name, BinaryCode code)
        {
            Name = name;
            Encoded = code;
        }
    }
}