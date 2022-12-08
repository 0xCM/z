//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public interface IDataChannel
    {   
        Task<ExecToken> Emit(ISeqEmitter src, ISeqReceiver dst);
    }

    public interface IDataChannel<S,T> : IDataChannel
        where T : ISeqReceiver<T>
        where S : ISeqEmitter<S>
    {
        Task<ExecToken> Emit(S src, T dst);

        Task<ExecToken> IDataChannel.Emit(ISeqEmitter src, ISeqReceiver dst)
            => Emit((S)src, (T)dst);    
    }
}