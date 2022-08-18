//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines a nexus of shared state and services for assembly-related services
    /// </summary>
    public interface IAsmContextDepr : IMessageQueue, IPolyrandProvider
    {
        IMessageQueue MessageQueue {get;}

        AsmDecoder Decoder {get;}

        AsmFormatConfig FormatConfig {get;}
    }
}