//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedModels;
    using static MachineModes;

    public abstract class MachineState : IDisposable
    {
        protected MachineState(uint machine)
        {
            Machine = machine;
        }

        public readonly uint Machine;

        protected abstract void Disposing();

        void IDisposable.Dispose()
        {
            Disposing();
        }
    }

    public abstract class MachineState<C> : MachineState
    {
        C _Context;

        protected MachineState(uint machine, C context)
            : base(machine)
        {

        }

        public ref readonly C Context 
        {
            [MethodImpl(Inline)]
            get => ref _Context;
        }
    }

    public abstract class MachineState<S,C> : MachineState<C>
        where S : MachineState<S,C>
    {
        public readonly uint MachineId;

        protected MachineState(uint machine, C context)
            : base(machine,context)
        {
            MachineId = machine;
        }
    }

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

            ProjectLog _Log;

            ProjectLog Log
            {
                get
                {
                    lock(LogLocker)
                    {
                        if(_Log == null)
                            _Log = Projects.log(Ws, $"xed.machine.{Machine.Id}", FileKind.Csv);
                    }
                    return _Log;
                }
            }

            readonly XedMachine Machine;

            readonly IProjectWorkspace Ws;

            readonly FS.FolderPath OutDir;

            readonly Action<object> Status;

            public Channel(XedMachine machine, Action<object> status)
            {
                Machine = machine;
                Ws = machine.Ws;
                Status = status;
                OutDir = Ws.BuildOut();
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
        ConstLookup<ushort,InstGroupMember> _GroupMemberLookup;

        SortedLookup<AsmInstClass,Index<InstGroupMember>> _ClassGroupLookup;

        SortedLookup<AsmInstClass,Index<InstPattern>> _ClassPatternLookup;

        SortedLookup<AsmInstClass,Index<InstForm>> _ClassFormLookup;

        [MethodImpl(Inline)]
        ref MachineState State()
            => ref RuntimeState;

        void LoadLookups()
        {
            var rules = Rules;
            var patterns = Xed.Views.Patterns;
            var groups = rules.CalcInstGroups(patterns);
            var members = groups.SelectMany(x => x.Members);
            _GroupMemberLookup = members.Select(x => (x.PatternId,x)).ToDictionary();
            _ClassPatternLookup = patterns.ClassPatterns();
            _ClassFormLookup = patterns.ClassForms();
            _ClassGroupLookup = groups.ClassGroups();
        }

        static AppDb AppDb => AppDb.Service;

        public InstGroupMember PatternGroup(ushort id)
            => _GroupMemberLookup.Find(id, out var dst) ? dst : InstGroupMember.Empty;

        public Index<InstForm> ClassForms(AsmInstClass @class)
            => _ClassFormLookup.Find(@class, out var dst) ? dst : sys.empty<InstForm>();

        public Index<InstGroupMember> ClassGroups(AsmInstClass @class)
            => _ClassGroupLookup.Find(@class, out var dst) ? dst : sys.empty<InstGroupMember>();

        public Index<InstPattern> ClassPatterns(AsmInstClass @class)
            => _ClassPatternLookup.Find(@class, out var x) ? x : sys.empty<InstPattern>();

        XedRuntime Xed;

        MachineState RuntimeState;

        readonly RuleTables RuleTables;

        readonly IProjectWorkspace Ws;

        readonly Channel _Emitter;

        static int Seq;

        [MethodImpl(Inline)]
        static uint NextId() => (uint)inc(ref Seq);

        const string Identifier = "xed.machine";

        public ref readonly uint Id
        {
            [MethodImpl(Inline)]
            get => ref State().Id;
        }

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
            Xed = xed;
            Ws = Projects.load(AppDb.DbOut().Root, Identifier);
            RuntimeState = new(NextId());
            RuleTables = Xed.Views.RuleTables;
            _Emitter = Channel.create(this, StatusWriter);
            LoadLookups();
        }

        [MethodImpl(Inline)]
        T Service<T>(Func<T> factory)
            => Xed.Service(factory);

        [MethodImpl(Inline)]
        void StatusWriter(object message)
            => Xed.Wf.Row(message,FlairKind.StatusData);

        public void Reset()
        {
            RuntimeState.Reset();
            Emissions.Flush();
        }

        public void Dispose()
            => _Emitter.Dispose();

        XedRules Rules => Xed.Rules;
    }
}