//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedFields;
using static XedModels;
using static XedDisasm;

using K = XedRules.FieldKind;

public class XedDisasmTarget<T> : WfSvc<T>, IXedDisasmTarget
    where T : XedDisasmTarget<T>, new()
{
    IXedDisasmBuffer Buffer;

    int Counter;

    HashSet<FieldKind> Exclusions;

    readonly FieldRender _Render;

    FileRef _CurrentFile;

    ProjectContext _Context;

    public XedDisasmTarget()
    {
        Counter = 0;
        Exclusions = sys.hashset(K.TZCNT,K.LZCNT,K.MAX_BYTES);
        Running += Nothing;
        Ran += Nothing;
        OpDetailComputed += Nothing;
        OpStateComputed += StateComputed;
        InfoComputed += Nothing;
        ExtractComputed += Nothing;
        PropsComputed += Nothing;
        FieldsComputed += Nothing;
        ComputingInst += Nothing;
        ComputedInst += Nothing;
        _Render = XedFields.render();
    }

    protected event DisasmReceiver<Instruction> ComputingInst;

    protected event DisasmReceiver<Instruction> ComputedInst;

    protected new event FileReceiver Running;

    protected event Action<XedDisasmToken> Ran;

    protected event DisasmReceiver<OpDetails> OpDetailComputed;

    protected event OpStateReceiver OpStateComputed;

    protected event DisasmReceiver<AsmInfo> InfoComputed;

    protected event DisasmReceiver<EncodingExtract> ExtractComputed;

    protected event DisasmReceiver<InstFieldValues> PropsComputed;

    protected event FieldReceiver FieldsComputed;

    protected ref readonly FileRef CurrentFile
    {
        [MethodImpl(Inline)]
        get => ref _CurrentFile;
    }

    protected ref readonly ProjectContext Context
    {
        [MethodImpl(Inline)]
        get => ref _Context;
    }

    protected ref readonly FieldRender Render
    {
        [MethodImpl(Inline)]
        get => ref _Render;
    }

    void IXedDisasmTarget.Computed(uint seq, in OpDetails src)
        => OpDetailComputed(seq,src);

    void IXedDisasmTarget.Computing(uint seq, in Instruction src)
        => ComputingInst(seq, src);

    void IXedDisasmTarget.Computed(uint seq, in Instruction src)
        => ComputedInst(seq, src);

    void IXedDisasmTarget.Computed(uint seq, in OperandState src)
        => Buffer.State(seq, src, OpStateComputed);

    void IXedDisasmTarget.Computed(uint seq, in AsmInfo src)
    {
        Buffer.AsmInfo() = src;
        InfoComputed(seq, src);
    }

    void IXedDisasmTarget.Computed(uint seq, in Fields src)
        => FieldsComputed(seq,src);

    void IXedDisasmTarget.Computed(uint seq, ReadOnlySpan<FieldKind> src)
        => Buffer.Cache(src);

    void IXedDisasmTarget.Computed(uint seq, in EncodingExtract src)
    {
        Buffer.Encoding() = src;
        ExtractComputed(seq,src);
    }

    void IXedDisasmTarget.Computed(uint seq, in InstFieldValues src)
    {
        Buffer.Props() = src;
        PropsComputed(seq,src);
    }

    public XedDisasmToken Starting(ProjectContext context, in FileRef src)
    {
        _CurrentFile = src;
        _Context = context;
        XedDisasmToken t = token();
        Counter = 0;
        Buffer = buffer(context, src);
        Running(context, src);
        return t;
    }

    void IXedDisasmTarget.Finished(XedDisasmToken token)
        => Ran(token);

    void StateComputed(uint seq, in OperandState state, ReadOnlySpan<FieldKind> fields)
    {
        for(var i=0; i<fields.Length; i++)
        {
            ref readonly var kind = ref skip(fields,i);
            if(Exclusions.Contains(kind))
                continue;

            var cell = Xed.extract(state, skip(fields,i));
            inc(ref Counter);
        }
    }

    static void Nothing(ProjectContext context, in FileRef src) {}

    static void Nothing(XedDisasmToken src) {}

    static void Nothing<X>(uint seq, in X src) {}

    static void Nothing(uint seq, in Fields src) {}

    static void Nothing(uint seq){}
}
