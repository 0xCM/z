//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedOps;
    using static sys;

    using K = XedRules.FieldKind;

    partial class XedDisasm
    {
        internal class XedDisasmFieldParser
        {
            XedDisasmState State;

            List<FieldKind> _ParsedFields;

            List<Facet<string>> _UnknownFields;

            Dictionary<FieldKind, string> _Failures;

            byte DispWidth;

            public XedDisasmFieldParser()
            {
                State = XedDisasmState.Empty;
                _ParsedFields = new();
                _UnknownFields = new();
                _Failures = new();
                DispWidth = 32;
            }

            void Clear()
            {
                State = XedDisasmState.Empty;
                _ParsedFields.Clear();
                _UnknownFields.Clear();
                _Failures.Clear();
                DispWidth = 32;
            }

            public XedDisasmState Parse(InstFieldValues src)
            {
                Clear();
                var count = src.Count;
                var dst = XedDisasmState.Empty;
                var names = src.Keys.Array();
                for(var i=0; i<count; i++)
                {
                    ref readonly var name = ref skip(names,i);
                    var kind = FieldKind.INVALID;
                    if(XedParsers.parse(name, out kind))
                        Parse(kind, src[name], ref dst);
                }
                dst.RuleState = State.RuleState;
                return dst;
            }

            static bool update(string src, FieldKind kind, ref XedDisasmState dstate)
                => FieldParser.parse(src, kind, ref dstate.RuleState).IsNonEmpty;


            static Outcome parse(string src, out asci32 dst)
            {
                dst = src ?? EmptyString;
                return true;
            }

            void Parse(FieldKind kind, string value, ref XedDisasmState dst)
            {
                var result = Outcome.Success;
                switch(kind)
                {
                    case K.RELBR:
                        result = Disp.parse(value, Sizes.native(DispWidth), out dst.RELBRVal);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.BRDISP_WIDTH:
                        result = NumericParser.parse(value, out DispWidth);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.AGEN:
                        result = parse(value, out dst.AGENVal);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.MEM0:
                        result = parse(value, out dst.MEM0Val);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.MEM1:
                        result = parse(value, out dst.MEM1Val);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    default:
                        result = update(value, kind, ref State);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;
                }

                if(result.Fail)
                    _Failures.Add(kind,value);
            }
       }
    }
}