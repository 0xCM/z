//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;
    using static XedRules;
    using static XedOps;

    using P = XedRules.InstPattern;
    using M = XedModels;
    using R = XedRules;

    public class XedMachines : IDisposable
    {        
        static IMachine allocate(XedRuntime xed)
            => new MachineState(xed);

        XedRuntime Xed;

        uint6 Current = 0;

        int Counter = 0;

        ConcurrentDictionary<uint, IMachine> Allocations = new();

        const byte Capacity = uint6.MaxValue + 1;

        bool Allocated = false;

        public bool Machine(uint id, out IMachine dst)
            => Allocations.TryGetValue(id, out dst);

        public IMachine Machine()
        {
            var m =  XedMachines.allocate(Xed);
            Allocations.TryAdd(m.Id,m);
            return m;
        }

        void Allocate()
        {
            if(!Allocated)
            {
                for(var i=0; i<Capacity; i++)
                {
                    var machine = XedMachines.allocate(Xed);
                    Allocations[machine.Id] = machine;
                }
                Allocated = true;
            }
        }

        public void Dispose()
            => iter(Allocations.Values, machine => machine.Dispose());

        public XedMachine Run(XedRuntime xed)
        {
            Xed = xed;
            Allocate();
            return new XedMachine(xed);
        }

        public void Reset()
        {
            iter(Allocations.Values, machine => machine.Reset());
        }

        public void Run(bool rent, Action<IMachine> f)
        {
            var machine = default(IMachine);
            if(rent)
            {
                Current = (byte)inc(ref Counter);
                machine = Allocations[Current];
                if(Counter > Capacity)
                    machine.Reset();
            }
            else
                machine = XedMachines.allocate(Xed);

            f(machine);
        }

        internal class MachineState : IMachine<InstPattern>
        {
            InstPattern Pattern;

            OperandState OpState;

            MachineMode MachineMode;

            ConcurrentDictionary<uint,MachineState> Allocations = new();

            bool Allocated = false;

            const byte Capacity = uint6.MaxValue + 1;

            void Allocate()
            {
                if(!Allocated)
                {
                    for(var i=0; i<Capacity; i++)
                    {
                        var machine = new MachineState(Xed);
                        Allocations[machine.Id] = machine;
                    }
                    Allocated = true;
                }
            }

            XedInstForm Form;

            Fields Expressions;

            AsmInfo Asm;

            readonly XedRuntime Xed;

            readonly uint Id;

            static uint Seq;

            public MachineState(XedRuntime xed)
            {
                Id = core.inc(ref Seq);
                Expressions = Fields.allocate();
                Xed = xed;
                LoadLookups();
                Reset();
            }

            public void Reset()
            {
                OpState = OperandState.Empty;
                Pattern = XedRules.InstPattern.Empty;
                MachineMode = default;
                Form = XedInstForm.Empty;
                Expressions.Clear();
                Asm = AsmInfo.Empty;
            }

            public void Dispose()
            {

            }


            void Load(in CellValue src)
            {
                ref readonly var fk = ref src.Field;
                ref readonly var ck = ref src.CellKind;

            }

            /// <summary>
            /// Specifies the encoding of the current instruction
            /// </summary>
            public ref readonly AsmHexCode Encoding
            {
                [MethodImpl(Inline)]
                get => ref Asm.Encoded;
            }

            void Load(in InstFieldSeg src)
            {

            }

            void Load(in CellExpr src)
            {

            }

            void Load(in FieldSeg src)
            {

            }

            void Load(in InstCells src)
            {
                for(var i=z8; i<src.Count; i++)
                {
                    ref readonly var cell = ref src[i];
                    if(cell.IsExpr)
                    {
                        Load(cell.ToCellExpr());
                    }
                    else if(cell.CellType.IsInstSeg)
                    {
                        Load(cell.AsInstSeg());
                    }
                    else if(cell.CellType.IsFieldSeg)
                    {
                        Load(cell.ToFieldSeg());

                    }

                    Load(cell);
                }
            }

            void Load(in LayoutCell src)
            {

            }

            void Load(in InstLayoutRecord src)
            {
                for(var i=z8; i<src.Count; i++)
                    Load(src[i]);
            }

            void Load(in PatternOp src)
            {

            }

            void Load(in PatternOps src)
            {
                for(var i=z8; i<src.Count; i++)
                    Load(src[i]);
            }

            public void Load(in FieldBuffer src)
            {
                OpState = src.State;
                Form = src.Form;
            }

            public void Run(InstPattern src)
            {
                Reset();
                Form = src.InstForm;
                Load(src.Cells);
                Load(src.Ops);
                Pattern = src;
            }

            public ref readonly InstCells Layout
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            public ref readonly InstCells Expr
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            public ref readonly uint MachineId
            {
                [MethodImpl(Inline)]
                get => ref Id;
            }

            public ref readonly OperandState Operands
            {
                [MethodImpl(Inline)]
                get => ref OpState;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Mode;
            }

            /// <summary>
            /// Specifies the current <see cref='P'/>
            /// </summary>
            public ref readonly InstPattern InstPattern
            {
                [MethodImpl(Inline)]
                get => ref Pattern;
            }

            public ref readonly XedInstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Form;
            }

            public ref readonly XedInstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref View.iclass(Operands);
            }

            /// <summary>
            /// Specifies the dependency <see cref='M.OpName'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly Index<OpName> OpNames
            {
                [MethodImpl(Inline)]
                get => ref Pattern.OpNames;
            }

            public byte OpCount
            {
                [MethodImpl(Inline)]
                get => (byte)Pattern.Ops.Count;
            }

            /// <summary>
            /// Specifies the dependency <see cref='R.FieldSet'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly FieldSet FieldDeps
            {
                [MethodImpl(Inline)]
                get => ref Pattern.FieldDeps;
            }

            /// <summary>
            /// Specifies the expression-related <see cref='R.InstCells'/>  of the current <see cref='P'/>
            /// </summary>
            public ref readonly InstCells InstExpr
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Expr;
            }

            /// <summary>
            /// Specifies the <see cref='XedOpCode'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Pattern.OpCode;
            }

            /// <summary>
            /// Specifies the <see cref='M.Isa'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly InstIsa Isa
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Isa;
            }

            /// <summary>
            /// Specifies the <see cref='M.InstCategory'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly InstCategory Category
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Category;
            }

            /// <summary>
            /// Specifies the <see cref='M.Extension'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly Extension Extension
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Extension;
            }

            /// <summary>
            /// Specifies the pattern Id of the<see cref='P'/>
            /// </summary>
            public ref readonly ushort PatternId
            {
                [MethodImpl(Inline)]
                get => ref Pattern.PatternId;
            }

            /// <summary>
            /// Specifies layout <see cref='R.InstCells'/> associated with the current <see cref='P'/>
            /// </summary>
            public ref readonly InstCells LayoutFields
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            /// <summary>
            /// Specifies <see cref='R.PatternOps'/> associated with the current <see cref='P'/>
            /// </summary>
            public ref readonly PatternOps Ops
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Ops;
            }

            /// <summary>
            /// Specifies the asm source text of the current instruction
            /// </summary>
            public ref readonly asci64 AsmText
            {
                [MethodImpl(Inline)]
                get => ref Asm.Asm;
            }

            /// <summary>
            /// Specifies the IP of the current instruction
            /// </summary>
            public ref readonly MemoryAddress IP
            {
                [MethodImpl(Inline)]
                get => ref Asm.IP;
            }

            /// <summary>
            /// Specifies <see cref='R.InstOpDetail'/> associated with the current <see cref='P'/>
            /// </summary>
            public ref readonly Index<InstOpDetail> OpDetail
            {
                [MethodImpl(Inline)]
                get => ref Pattern.OpDetails;
            }

            /// <summary>
            /// Specifies <see cref='InstGroupMember'/> associated with the current <see cref='LoadPattern'/>
            /// </summary>
            public InstGroupMember PatternGroup
                => _GroupMemberLookup.Find(PatternId, out var dst) ? dst : InstGroupMember.Empty;

            /// <summary>
            /// Specifies <see cref='InstForm'/> associated with the current <see cref='InstClass'/>
            /// </summary>
            public Index<XedInstForm> ClassForms
                => _ClassFormLookup.Find(InstClass, out var dst) ? dst : sys.empty<XedInstForm>();

            /// <summary>
            /// Specifies <see cref='InstGroupMember'> associated with the current <see cref='InstClass'/>
            /// </summary>
            public Index<InstGroupMember> ClassGroups
                => _ClassGroupLookup.Find(InstClass, out var dst) ? dst : sys.empty<InstGroupMember>();

            /// <summary>
            /// Specifies <see cref='LoadPattern'/> associated with the current <see cref='InstClass'/>
            /// </summary>
            public Index<InstPattern> ClassPatterns
                => _ClassPatternLookup.Find(InstClass, out var x) ? x : sys.empty<InstPattern>();

            uint IMachine.Id
                => Id;

            void LoadLookups()
            {
                var rules = Xed.Rules;
                var patterns = Xed.Views.Patterns;
                var groups = rules.CalcInstGroups(patterns);
                var members = groups.SelectMany(x => x.Members);
                _GroupMemberLookup = members.Select(x => (x.PatternId,x)).ToDictionary();
                _ClassPatternLookup = patterns.ClassPatterns();
                _ClassFormLookup = patterns.ClassForms();
                _ClassGroupLookup = groups.ClassGroups();
            }

            ConstLookup<ushort,InstGroupMember> _GroupMemberLookup;

            SortedLookup<XedInstClass,Index<InstGroupMember>> _ClassGroupLookup;

            SortedLookup<XedInstClass,Index<InstPattern>> _ClassPatternLookup;

            SortedLookup<XedInstClass,Index<XedInstForm>> _ClassFormLookup;
        }
    }
}