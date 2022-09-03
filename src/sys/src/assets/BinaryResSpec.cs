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
        public string Identifier {get;}

        public BinaryCode Encoded {get;}

        [MethodImpl(Inline)]
        public BinaryResSpec(string name, BinaryCode code)
        {
            Identifier = name;
            Encoded = code;
        }
    }
}