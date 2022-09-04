//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static core;
    using static Delegates;

    using E = SpecializedImmEvent;

    public class ApiImmEmitter :  WfSvc<ApiImmEmitter>
    {
        const uint BufferSize = Pow2.T16;

        ImmSpecializer Specializer;

        Index<byte> Buffer;

        public ApiImmEmitter()
        {
            Buffer = alloc<byte>(BufferSize);
        }

        protected override void OnInit()
        {
            Specializer = Wf.ImmSpecializer();
        }

        bool Append = true;

        public void Emit(Index<PartName> parts, IApiPack dst)
        {
            //var selected = parts.Length == 0 ? Wf.ApiCatalog.PartIdentities : parts.Storage;
            EmitUnrefined(parts, dst);
            EmitRefined(parts, dst);
        }

        public void Emit(ReadOnlySpan<IApiHost> hosts, IApiPack pack)
        {
            var count = hosts.Length;
            var exchange = Exchange;
            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var writer = new AsmImmWriter(Wf, host.HostUri, pack);
                EmitDirectRefinements(exchange, host, writer);
                EmitGenericRefinements(exchange, host, writer);                
            }
        }

        public void Emit(ReadOnlySpan<IApiHost> hosts, IApiPack dst, SpanReceiver<AsmRoutine> receiver = null)
        {
            var count = hosts.Length;
            var exchange = Exchange;
            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var writer = new AsmImmWriter(Wf, host.HostUri,dst);
                var direct = EmitDirectRefinements(exchange, host, writer);
                receiver?.Invoke(direct);
                var generic = EmitGenericRefinements(exchange, host, writer);
                receiver?.Invoke(generic);
            }
        }

        ReadOnlySpan<AsmRoutine> EmitLiteral(byte[] imm8, Index<PartName> parts, IApiPack dst)
        {
            if(imm8.Length != 0)
                return EmitUnrefined(Exchange, imm8.ToImm8Values(ImmRefinementKind.Unrefined), parts, dst);
            else
                return default;
        }

        ReadOnlySpan<AsmRoutine> EmitUnrefined(Index<PartName> parts, IApiPack dst)
            => EmitLiteral(new byte[]{2,4,6,8,10,12}, parts, dst);

        CaptureExchange Exchange
            => Capture.exchange(Buffer.Storage);

        ReadOnlySpan<AsmRoutine> EmitRefined(Index<PartName> parts, IApiPack dst)
            => EmitRefined(Exchange, parts, dst);

        ParameterInfo RefiningParameter(MethodInfo src)
            => src.ImmParameters(ImmRefinementKind.Refined).First();

        Type RefinementType(MethodInfo src)
            => src.ImmParameters(ImmRefinementKind.Refined).First().ParameterType;

        Index<Imm8R> RefinedValues(MethodInfo src)
            => Imm8.refined(RefiningParameter(src));

        ReadOnlySpan<AsmRoutine> EmitDirectRefinements(in CaptureExchange exchange, IApiHost host, IAsmImmWriter dst)
        {
            var groups = ApiQuery.imm(host,ImmRefinementKind.Refined);
            var uri = host.HostUri;
            var generic = false;
            var routines = list<AsmRoutine>();
            foreach(var g in groups)
            {
                var gid = g.GroupId;
                foreach(var member in g.Members.Storage)
                {
                    if(member.Method.IsVectorizedUnaryImm(ImmRefinementKind.Refined))
                    {
                        var imm8 = RefinedValues(member.Method);
                        if(imm8.Length != 0)
                        {
                            var rft = RefinementType(member.Method);
                            var functions = Specializer.UnaryOps(exchange, member.Method, member.Id, imm8);
                            if(functions.Length != 0)
                            {
                                var hex = dst.SaveHexImm(gid, functions, Append, true);
                                Wf.Raise(E.refined(Host, uri, generic, rft, hex.Location));

                                dst.SaveAsmImm(gid, functions, Append, true)
                                    .OnSome(path => Wf.Raise(E.refined(Host, uri, generic, rft, path)));

                                routines.AddRange(functions);
                            }
                        }
                    }
                    else if(member.Method.IsVectorizedBinaryImm(ImmRefinementKind.Refined))
                    {
                        var values = RefinedValues(member.Method);
                        if(values.Length != 0)
                        {
                            var rft = RefinementType(member.Method);
                            var functions = Specializer.BinaryOps(exchange, member.Method, member.Id, values);
                            if(functions.Length != 0)
                            {
                                var hex = dst.SaveHexImm(gid, functions, Append, true);
                                Wf.Raise(E.refined(Host, uri, generic, rft, hex.Location));

                                dst.SaveAsmImm(gid, functions, Append, true)
                                    .OnSome(path => Wf.Raise(E.refined(Host, uri, generic, rft, path)));

                                routines.AddRange(functions);
                            }
                        }
                    }
                }
            }

            return routines.ViewDeposited();
        }

        Index<IApiHost> Hosts(Index<PartName> parts)
            => Wf.ApiCatalog.PartHosts(parts);

        ReadOnlySpan<AsmRoutine> EmitUnrefined(in CaptureExchange exchange, Index<Imm8R> imm8, Index<PartName> parts, IApiPack dst)
        {
            var routines = list<AsmRoutine>();
            routines.AddRange(EmitUnrefinedDirect(exchange, imm8, parts, dst));
            routines.AddRange(EmitUnrefinedGeneric(exchange, imm8, parts, dst));
            return routines.ViewDeposited();
        }

        ReadOnlySpan<AsmRoutine> EmitRefined(in CaptureExchange exchange, Index<PartName> parts, IApiPack dst)
        {
            var routines = list<AsmRoutine>();
            var hosts = Hosts(parts);
            foreach(var host in hosts)
            {
                var writer = new AsmImmWriter(Wf, host.HostUri, dst);
                EmitDirectRefinements(exchange, host, writer);
                routines.AddRange(EmitGenericRefinements(exchange, host, writer));
            }
            return routines.ViewDeposited();
        }

        Index<AsmRoutine> EmitUnrefinedDirect(in CaptureExchange exchange, Index<Imm8R> imm8, Index<PartName> parts, IApiPack dst)
        {
            var routines = list<AsmRoutine>();
            foreach(var host in Hosts(parts))
            {
                var writer = new AsmImmWriter(Wf, host.HostUri, dst);
                var groups = ApiQuery.imm(host, ImmRefinementKind.Unrefined);
                routines.AddRange(EmitUnrefinedDirect(exchange, groups,imm8, writer));
            }
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitUnrefinedDirect(in CaptureExchange exchange, Index<ApiGroupNG> groups, Index<Imm8R> imm8, IAsmImmWriter dst)
        {
            var routines = list<AsmRoutine>();
            var unary = from g in groups
                        let members = g.Members.Where(m => m.Method.IsVectorizedUnaryImm(ImmRefinementKind.Unrefined))
                        select (g,members.Array());

            foreach(var (g,members) in unary)
                routines.AddRange(EmitUnrefinedUnary(exchange, g.GroupId, members, imm8, dst));

            var binary = from g in groups
                        let members = g.Members.Where(m => m.Method.IsVectorizedBinaryImm(ImmRefinementKind.Unrefined))
                        select (g,members.Array());

            foreach(var (g,members) in binary)
                routines.AddRange(EmitUnrefinedBinary(exchange, g.GroupId, members, imm8, dst));
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitUnrefinedGeneric(in CaptureExchange exchange, Index<Imm8R> imm8, Index<PartName> parts, IApiPack dst)
        {
            var routines = list<AsmRoutine>();
            foreach(var host in Hosts(parts))
            {
                var writer = new AsmImmWriter(Wf, host.HostUri, dst);
                var specs = ApiQuery.immG(host, ImmRefinementKind.Unrefined);
                foreach(var spec in specs)
                    routines.AddRange(EmitUnrefinedGeneric(exchange, spec, imm8, writer));
            }
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitGenericRefinements(in CaptureExchange exchange, IApiHost host, IAsmImmWriter dst)
        {
            var specs = ApiQuery.immG(host, ImmRefinementKind.Refined);
            var routines = list<AsmRoutine>();
            foreach(var f in specs)
            {
                if(f.Method.IsVectorizedUnaryImm(ImmRefinementKind.Refined))
                    routines.AddRange(EmitUnary(exchange, f, RefinedValues(f.Method), dst, RefinementType(f.Method)));
                else if(f.Method.IsVectorizedBinaryImm(ImmRefinementKind.Refined))
                    routines.AddRange(EmitBinary(exchange, f, RefinedValues(f.Method), dst, RefinementType(f.Method)));
            }
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitUnrefinedGeneric(in CaptureExchange exchange, ApiMethodG src, Index<Imm8R> imm8, IAsmImmWriter dst)
        {
            var routines = list<AsmRoutine>();
            if(src.Method.IsVectorizedUnaryImm(ImmRefinementKind.Unrefined))
                routines.AddRange(EmitUnary(exchange, src, imm8, dst));
            else if(src.Method.IsVectorizedBinaryImm(ImmRefinementKind.Unrefined))
                routines.AddRange(EmitBinary(exchange, src, imm8, dst));

            return routines.ToArray();
        }

        Index<AsmRoutine> EmitUnrefinedUnary(in CaptureExchange exchange, _OpIdentity gid, Index<ApiMethodNG> methods, Index<Imm8R> imm8, IAsmImmWriter dst)
        {
            var generic = false;
            var routines = list<AsmRoutine>();
            foreach(var f in methods)
            {
                var host = f.Host;
                var uri = host.HostUri;
                var functions = Specializer.UnaryOps(exchange, f.Method, f.Id, imm8);
                if(functions.Length != 0)
                {
                    var hex = dst.SaveHexImm(gid, functions, Append, false);
                    Wf.Raise(E.literal(Host, uri, generic, hex.Location));

                    dst.SaveAsmImm(gid, functions, Append, false).OnSome(path => Wf.Raise(E.literal(Host, uri, generic, path)));
                    routines.AddRange(functions);
                }
            }
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitUnrefinedBinary(in CaptureExchange exchange, _OpIdentity gid, Index<ApiMethodNG> methods, Index<Imm8R> imm8, IAsmImmWriter dst)
        {
            var generic = false;
            var routines = core.list<AsmRoutine>();
            foreach(var f in methods)
            {
                var host = f.Host;
                var uri = host.HostUri;
                var functions = Specializer.BinaryOps(exchange, f.Method, f.Id, imm8);
                if(functions.Length != 0)
                {
                    var hex = dst.SaveHexImm(gid, functions, Append, false);
                    Wf.Raise(E.literal(Host, uri, generic, hex.Location));

                    dst.SaveAsmImm(gid, functions, Append, false).OnSome(path => Wf.Raise(E.literal(Host, uri, generic, path)));
                    routines.AddRange(functions);
                }
            }
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitUnary(in CaptureExchange exchange, ApiMethodG src, Index<Imm8R> imm8, IAsmImmWriter dst, Type refinement = null)
        {
            var gid = src.Id;
            var uri = src.Host.HostUri;
            var generic = true;
            var closures = ApiIdentity.closures(src);
            var count = closures.Length;
            var routines = list<AsmRoutine>();
            foreach(var closure in closures)
            {
                var functions = Specializer.UnaryOps(exchange, closure.Method, closure.Id, imm8);
                if(functions.Length != 0)
                {
                    var hex = dst.SaveHexImm(gid, functions, Append, refinement != null);
                    Wf.Raise(E.literal(Host, uri, generic, hex.Location));

                    dst.SaveAsmImm(gid, functions, Append, refinement != null).OnSome(path => Wf.Raise(E.define(Host, uri, generic, path, refinement)));
                    routines.AddRange(functions);
                }
            }
            return routines.ToArray();
        }

        Index<AsmRoutine> EmitBinary(in CaptureExchange exchange, ApiMethodG src, Index<Imm8R> imm8, IAsmImmWriter dst, Type refinement = null)
        {
            var gid = src.Id;
            var host = src.Host.HostUri;
            var generic = true;
            var closures = ApiIdentity.closures(src);
            var count = closures.Length;
            var routines = list<AsmRoutine>();

            foreach(var closure in closures)
            {
                var functions = Specializer.BinaryOps(exchange, closure.Method, closure.Id, imm8);
                if(functions.Length != 0)
                {
                    var hex = dst.SaveHexImm(gid, functions, Append, refinement != null);
                    Wf.Raise(E.define(Host, host, generic, hex.Location, refinement));

                    dst.SaveAsmImm(gid, functions, Append, refinement != null).OnSome(path => Wf.Raise(E.define(Host, host, generic, path, refinement)));
                    routines.AddRange(functions);
                }
            }
            return routines.ToArray();
        }
    }
}