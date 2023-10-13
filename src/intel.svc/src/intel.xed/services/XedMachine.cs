//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static MachineModes;
using static XedModels;

public class XedMachine : IDisposable
{
    class MachineState
    {
        MachineMode _Mode;

        AddressingKind _AddressingMode;

        uint _Id;

        public MachineState(uint id)
        {
            _Id = id;
            Reset();
        }

        public void Reset()
        {

        }

        public ref readonly uint Id
        {
            [MethodImpl(Inline)]
            get => ref _Id;
        }

        [MethodImpl(Inline)]
        public ref AddressingKind Addressing()
            => ref _AddressingMode;

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref _Mode;
    }

    public class Channel : IDisposable
    {
        public static Channel create(XedMachine machine, Action<object> status)
            => new Channel(machine,status);

        object LogLocker = new();

        TaskLog _Log;

        public Channel(XedMachine machine, Action<object> status)
        {
        }

        public void Dispose()
        {
            lock(LogLocker)
                if(_Log != null)
                    _Log.Dispose();
        }

        public void Flush()
        {
            lock(LogLocker)
            {
                if(_Log != null)
                    _Log.Flush();
            }
        }
    }        

    [MethodImpl(Inline)]
    ref MachineState State()
        => ref RuntimeState;

    MachineState RuntimeState;

    readonly Channel _Emitter;

    static int Seq;

    [MethodImpl(Inline)]
    static uint NextId() => (uint)inc(ref Seq);

    public Channel Emissions
    {
        [MethodImpl(Inline)]
        get => _Emitter;
    }

    [MethodImpl(Inline)]
    public ref MachineMode Mode()
        => ref State().Mode();

    [MethodImpl(Inline)]
    public ref AddressingKind Addressing()
        => ref State().Addressing();

    internal XedMachine(XedRuntime xed)
    {
        RuntimeState = new(NextId());
        _Emitter = Channel.create(this, StatusWriter);
    }

    void StatusWriter(object src)
    {

    }
    public void Reset()
    {
        RuntimeState.Reset();
        Emissions.Flush();
    }

    public void Dispose()
        => _Emitter.Dispose();    
}
