//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class JsonPacket
    {
        public readonly dynamic Content;

        public readonly string Type;

        [MethodImpl(Inline)]
        public JsonPacket(dynamic content, string type)
        {
            Content = content ?? RP.Null;
            Type = type ?? RP.Null;
        }
    }
}