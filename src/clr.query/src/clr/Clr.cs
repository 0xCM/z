//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ReflectionFlags;
    using static TypeAttributes;
    using System.Linq;
 
    [ApiHost]
    public readonly partial struct Clr
    {
        const NumericKind Closure = UnsignedInts;

        const BindingFlags BF = ReflectionFlags.BF_All;

        [MethodImpl(Inline), Op]
        public static AssemblyVersion version(AssemblyName src)
        {
            var version = src.Version;
            var dst = new AssemblyVersion((ushort)version.Major, (ushort)version.Minor, (ushort)version.Build, (ushort)version.Revision);
            return dst;
        }

        /// <summary>
        /// Determines whether an identified <see cref='PrimalKind'/> can be a compile-time literal
        /// </summary>
        /// <param name="src">The kind to test</param>
        [MethodImpl(Inline), Op]
        public static bool literal(PrimalKind src)
            => ((byte)src > 2 && (byte)src<16) || (byte)src == 18;

        [MethodImpl(Inline), Op]
        public static MemoryAddress address(Type src)
            => src.TypeHandle.Value;

        [MethodImpl(Inline), Op]
        public static MemoryAddress address(Delegate src)
            => src.Method.MethodHandle.GetFunctionPointer();

        [MethodImpl(Inline), Op]
        public static MemberAddress address(ClrMember member, MemoryAddress address)
            => new MemberAddress(member,address);

        /// <summary>
        /// Computes the <see cref='MemberAddress'/> of a specified <see cref='MethodInfo'/>
        /// </summary>
        /// <param name="src">The source member</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemberAddress address(MethodInfo src)
            => new MemberAddress(src, src.MethodHandle.GetFunctionPointer());

        /// <summary>
        /// Computes the <see cref='MemberAddress'/> of a specified <see cref='FieldInfo'/>
        /// </summary>
        /// <param name="src">The source member</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemberAddress address(FieldInfo src)
            => new MemberAddress(src, src.FieldHandle.Value.ToPointer());

        [MethodImpl(Inline), Op]
        public static Index<object> attributes(Type src)
            => src.GetCustomAttributes(false);

        [MethodImpl(Inline), Op]
        public static FieldInfo[] fields(Type src)
            => src.GetFields(BF);

        [MethodImpl(Inline), Op]
        public static Assembly corlib()
            => typeof(uint).Assembly;

        [MethodImpl(Inline), Op]
        public static AssemblyName[] refnames(Assembly src)
            => src.GetReferencedAssemblies();

        [Op]
        public static MethodDisplaySig display(in ClrMethodArtifact src)
            => new MethodDisplaySig(ClrMethodArtifact.format(src));

        /// <summary>
        /// Returns a <see cref='SegRef'/> to the cli metadata segment of the source
        /// </summary>
        /// <param name="src">The source assembly</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemorySeg metadata(Assembly src)
            => ClrAssembly.metadata(src);

        [MethodImpl(Inline), Op]
        public static ClrMethodAdapter method(Delegate src)
            => src.Method;

        [MethodImpl(Inline), Op]
        public static string @string(Module module, EcmaToken token)
            => module.ResolveString((int)token);

        [MethodImpl(Inline), Op]
        public static MethodBase method(Module src, EcmaToken token)
            => src.ResolveMethod((int)token);

        [MethodImpl(Inline), Op]
        public static MethodInfo method(Type type, string name)
            => type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);           

        [MethodImpl(Inline), Op]
        public static unsafe TypeCode typecode(in SystemTypeCodes src, byte index)
            => (TypeCode)(*(sys.address(src) + index).Pointer<byte>());

        [MethodImpl(Inline), Op]
        public static SystemTypeCodes typecodes()
            => SystemTypeCodes.cached();

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrTypeAdapter> nested(Type src)
            => recover<Type,ClrTypeAdapter>(src.GetNestedTypes());

        [MethodImpl(Inline), Op]
        public static bool nested(TypeAttributes src)
            => (src & (NestedPublic | NestedAssembly | NestedFamANDAssem | NestedFamily | NestedFamORAssem | NestedPrivate)) != 0;

        [MethodImpl(Inline), Op]
        public static FieldInfo field(Type type, string name)
            => type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrMethodAdapter> methods(Type src)
            => adapt(methods(src, out var _));

        [MethodImpl(Inline), Op]
        public static MethodInfo[] methods(Type src, out MethodInfo[] dst)
            => dst = src.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        [Op]
        public static Assembly[] refs(Assembly src)
            => refnames(src).Select(Assembly.Load);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrModuleAdapter> modules(Assembly src)
            => adapt(src.Modules());

        [MethodImpl(Inline), Op]
        public static ClrModuleAdapter manifest(Assembly src)
            => adapt(src.ManifestModule);

        /// <summary>
        /// Determines whether a specified type is a system-defined primitive
        /// </summary>
        /// <param name="src">The type to test</param>
        [MethodImpl(Inline), Op]
        public static bool primitive(Type src)
            => PrimalBits.kind(src) != 0;

        [Op, Closures(Closure)]
        public static void values<T>(in T src, ReadOnlySpan<ClrFieldAdapter> fields, Span<ClrFieldValue> dst)
            where T : struct
        {
            ref var target = ref first(dst);
            var tRef = __makeref(edit(src));
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = new ClrFieldValue(f, f.GetValueDirect(tRef));
            }
        }

        /// <summary>
        /// Queries the host type for a <see cref='ClrImplMap'/>
        /// </summary>
        /// <param name="host">The reifying type</param>
        /// <param name="contract">The contract type</param>
        [MethodImpl(Inline), Op]
        public static ClrImplMap impl(Type host, Type contract)
        {
            var src = host.InterfaceMap(contract);
            var dst = new ClrImplMap();
            dst.Specs = src.InterfaceMethods;
            dst.SpecType = src.InterfaceType;
            dst.Impl = src.TargetMethods;
            dst.ImplType = src.TargetType;
            return dst;
        }

        public static ClrImplMap impl<H,C>()
            where C : class
                => impl(typeof(H), typeof(C));

        public static ReadOnlySeq<ClrImplMap> impls(Assembly defs, Assembly hosts)
        {
            var contrats = defs.Interfaces().ToHashSet();
            var maps = from host in hosts.Types().Concrete()
                       from i in host.Interfaces()
                       where contrats.Contains(i)
                      select impl(host,i);
            return maps.ToArray();
        }        
    }
}