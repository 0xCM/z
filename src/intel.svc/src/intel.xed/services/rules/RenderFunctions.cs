//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        partial struct CellRender
        {
            public class Functions
            {
                public static Functions Service => Instance;

                static Functions Instance;

                static Index<RuleCellKind,ITextFormatter> Lookup;

                [MethodImpl(Inline)]
                public ITextFormatter Formatter(RuleCellKind kind)
                    => Lookup[kind];

                [MethodImpl(Inline)]
                public ITextFormatter<T> Formatter<T>(RuleCellKind kind)
                    where T : unmanaged
                        => (ITextFormatter<T>)Lookup[kind];

                [MethodImpl(Inline)]
                public string Format<T>(RuleCellKind kind, T value)
                    where T : unmanaged
                        => Formatter<T>(kind).Format(value);

                readonly struct RenderFunction : ITextFormatter<object>
                {
                    [MethodImpl(Inline)]
                    public RenderFunction(Func<string> f)
                    {
                        F = _ => f();
                    }

                    [MethodImpl(Inline)]
                    public RenderFunction(Func<object,string> f)
                    {
                        F = f;
                    }

                    readonly Func<object,string> F;

                    [MethodImpl(Inline)]
                    public string Format(object src)
                        => F(src);
                }

                readonly struct RenderFunction<T> : ITextFormatter<T>
                    where T : unmanaged
                {
                    readonly Func<T,string> F;

                    [MethodImpl(Inline)]
                    public RenderFunction(Func<T,string> f)
                    {
                        F = f;
                    }

                    [MethodImpl(Inline)]
                    public RenderFunction(Func<string> f)
                    {
                        F = _ => f();
                    }

                    [MethodImpl(Inline)]
                    public string Format(T src)
                        => F(src);

                    [MethodImpl(Inline)]
                    public static implicit operator RenderFunction(RenderFunction<T> src)
                        => new RenderFunction((object o) => src.Format((T)o));

                    [MethodImpl(Inline)]
                    public static implicit operator RenderFunction<T>(Func<T,string> f)
                        => new RenderFunction<T>(f);
                }

                static RenderFunction<T> render<T>(Func<T,string> f)
                    where T : unmanaged
                        => new RenderFunction<T>(f);

                static RenderFunction render(Func<string> f)
                    => new RenderFunction(f);

                Functions()
                {
                    var kinds = Symbols.index<RuleCellKind>().Kinds;
                    Lookup = alloc<ITextFormatter>(kinds.Length);
                    for(var i=0; i<kinds.Length; i++)
                    {
                        ref readonly var kind = ref skip(kinds,i);
                        switch(kind)
                        {
                            case CK.Void:
                                Lookup[kind] = render(() => EmptyString);
                                break;
                            case CK.BitVal:
                                Lookup[kind] = render<bit>(x => ((bit)x).ToString());
                                break;
                            case CK.BitLit:
                                Lookup[kind] = render<uint5>(x => XedRender.format((uint5)x));
                                Lookup[kind] = render<uint5>(x => XedRender.format((uint5)x));
                                break;
                            case CK.HexLit:
                                Lookup[kind] = render<Hex8>(x => XedRender.format((Hex8)x));
                                break;
                            case CK.HexVal:
                                Lookup[kind] = render<Hex8>(x => XedRender.format((Hex8)x));
                                break;
                            case CK.SegVar:
                                Lookup[kind] = render<SegVar>(x => XedRender.format((SegVar)x));
                                break;
                            case CK.WidthVar:
                                Lookup[kind] = render<WidthVar>(x => XedRender.format((WidthVar)x));
                                break;
                            case CK.FieldSeg:
                                Lookup[kind] = render<FieldSeg>(x => XedRender.format((FieldSeg)x));
                                break;
                            case CK.NtCall:
                                Lookup[kind] = render<Nonterminal>(x => x is Nonterminal nt ? XedRender.format(nt) : XedRender.format((RuleName)x));
                                break;
                            case CK.IntVal:
                                Lookup[kind] = render<int>(x => x.ToString());
                                break;
                            case CK.InstSeg:
                                Lookup[kind] = render<InstFieldSeg>(x => XedRender.format((InstFieldSeg)x));
                                break;
                            case CK.Operator:
                                Lookup[kind] = render<OperatorKind>(x => x is OperatorKind k ? XedRender.format(k) : XedRender.format((RuleOperator)x));
                                break;
                            case CK.Keyword:
                                Lookup[kind] = render<KeywordKind>(x => x is KeywordKind k ? XedRender.format(k) : XedRender.format((RuleKeyword)x));
                                break;
                            case CK.EqExpr:
                            case CK.NtExpr:
                            case CK.NeqExpr:
                                Lookup[kind] = render<CellExpr>(x => XedRender.format((CellExpr)x));
                                break;
                            default:
                                Lookup[kind] = render(() => RP.Error);
                            break;
                        }
                    }
                }

                static Functions()
                {
                    Instance = new();
                }
            }
        }
    }
}