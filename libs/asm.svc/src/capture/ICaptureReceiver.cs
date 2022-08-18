//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICaptureReceiver : IDisposable
    {
        void Running(ReadOnlySeq<PartId> src);

        void Capturing(Assembly src);

        void Captured(Assembly src);

        void Captured(ReadOnlySeq<ApiEncoded> src);

        ICompositeDispenser Dispenser {get;}
    }
}