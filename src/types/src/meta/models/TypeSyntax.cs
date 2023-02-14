//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct TypeSyntax
    {
        public const string V = "v{0}<t:{1}>";

        public const string C = "c{0}";

        public const string I = "i{0}";

        public const string U = "u{0}";

        public const string F = "f{0}";

        public const string S = "string";

        public const string St = "s<t:{0}>";

        public const string Sn = "s<n:{0}>";

        public const string Snt = "s<n:{0},t:{1}>";

        public const string Bv = "bv{0}";

        public const string Seq = "seq<t:{0}>";

        public const string SeqN = "seq<n:{0},t:{1}>";

        public const string Bit = "bit";

        public const string Bits = "bits<{0}>";

        public const string BitsT = "bits<t:{0}>";

        public const string BitsNT = "bits<n:{0},t:{1}>";

        public const string Kind = "kind<k:{0}>";

        public const string Block = "block<n:{0},t:{1}>";

        public const string Address = "address";

        public const string Address8 = "address<w:8>";

        public const string Address16 = "address<w:16>";

        public const string Address32 = "address<w:32>";

        public const string Address64 = "address<w:64>";

        public const string AddressW = "address<w:{0}>";

        public const string Enum = "enum<{0}>";

        public const string Scalar = "{0}{1}";

        public const string Array = "array<t:{0}>";

        public const string Clr = "clr.{0}";

        public const string Literal = "literal<t:{0}>";

        public const string Constant = "const<t:{0}>";

        public const string Num = "num<t:{0}>";

        public const string Disp = "disp<w:{0}>";

        public const string Disp8 = "disp<w:8>";

        public const string Disp16 = "disp<w:16>";

        public const string Disp32 = "disp<w:32>";

        public const string Disp64 = "disp<w:64>";

        public const string Imm = "imm<w:{0}>";

        public const string ImmU = "immu<w:{0}>";

        public const string ImmI = "immi<w:{0}>";

        public const string Imm8 = "imm<w:8>";

        public const string Imm16 = "imm<w:16>";

        public const string Imm32 = "imm<w:32>";

        public const string Imm64 = "imm<w:64>";

        public const string Mem = "mem<w:{0}>";

        public const string Mem8 = "mem<w:8>";

        public const string Mem16 = "mem<w:16>";

        public const string Mem32 = "mem<w:32>";

        public const string Mem64 = "mem<w:64>";

        public const string Mem128 = "mem<w:128>";

        public const string Mem256 = "mem<w:256>";

        public const string Mem512 = "mem<w:512>";

        public const string Lookup = "lookup<k:{0},v:{1}>";

        public const string Reg = "reg<name:{0},w:{1}>";

        public const string RegW = "reg<w:{0}>";

        public const string RegKind = "regkind<k:{0}>";

        public const string Natural = "nat<n:{0}>";

        public const string Idx = "index<t:{0}>";

        public const string Span = "span<t:{0}>";

        public const string ConstSpan = "cspan<t:{0}>";

        public const string FileName = "FileName";

        public const string FileExt = "fs.ext";

        public const string Dir = "fs.dir";

        public const string FileUri = "fs.uri";

        public const string Folder = "fs.folder";

        public const string FilePath = "fs.path";

        public static TypeParam param(string name, string value) => new TypeParam(name,value);

        public static TypeParam param<T>(string name, T value) => new TypeParam<T>(name,value);

        public static TypeSpec native(NativeSize w, bool signed) => signed ? i(w.Width) : u(w.Width);

        [TypeSyntax(Natural)]
        public static TypeSpec nat(ulong n) => string.Format(Natural, n);

        [TypeSyntax(Reg)]
        public static TypeSpec reg(string name, BitWidth width) => string.Format(Reg, name, width);

        [TypeSyntax(RegW)]
        public static TypeSpec reg(BitWidth width) => string.Format(RegW, width);

        [TypeSyntax(RegKind)]
        public static TypeSpec regkind(string name) => string.Format(Reg, name);

        [TypeSyntax(Num)]
        public static TypeSpec num(TypeSpec type) => string.Format(Num, type);

        // [TypeSyntax(Clr)]
        // public static TypeSpec clr(PrimalKind kind) => string.Format(Clr, symbol(kind));

        /// <summary>
        /// Defines a type that represents a singed displacement of specified width
        /// </summary>
        /// <param name="w">The displacement width</param>
        [TypeSyntax(Disp)]
        public static TypeSpec disp(BitWidth w) => string.Format(Disp, w);

        /// <summary>
        /// Defines a type that represents an immediate value of specified width
        /// </summary>
        /// <param name="w">The immediate width</param>
        [TypeSyntax(Imm)]
        public static TypeSpec imm(NativeSize w) => string.Format(Imm, w);

        /// <summary>
        /// Defines a type that represents an unsigned immediate value of specified width
        /// </summary>
        /// <param name="w">The immediate width</param>
        [TypeSyntax(ImmU)]
        public static TypeSpec immu(BitWidth w) => string.Format(ImmU, w);

        /// <summary>
        /// Defines a type that represents a signed immediate value of specified width
        /// </summary>
        /// <param name="w">The immediate width</param>
        [TypeSyntax(ImmI)]
        public static TypeSpec immi(BitWidth w) => string.Format(ImmI, w);

        /// <summary>
        /// Defines a memory type of specified width
        /// </summary>
        /// <param name="w">The width</param>
        [TypeSyntax(Mem)]
        public static TypeSpec mem(BitWidth w) => string.Format(Mem, w);

        // /// <summary>
        // /// Defines a scalar type of specified class and width
        // /// </summary>
        // [TypeSyntax(Scalar)]
        // public static TypeSpec scalar(NativeClass @class, BitWidth w) => string.Format(Scalar, symbol(@class), w);

        /// <summary>
        /// Defines a scalar type predicated on a specified underlying type
        /// </summary>
        [TypeSyntax(Scalar)]
        public static TypeSpec scalar(TypeSpec type) => string.Format(Scalar, type.Format());

        /// <summary>
        /// Defines a refined literal sequence
        /// </summary>
        /// <param name="n">The sequence name</param>
        [TypeSyntax(Enum)]
        public static TypeSpec @enum(string name, TypeSpec @base = default) => string.Format(Enum, name);

        /// <summary>
        /// Defines an address type with default width
        /// </summary>
        [TypeSyntax(AddressW)]
        public static TypeSpec address() => Address;

        /// <summary>
        /// Defines an address type of specified width
        /// </summary>
        /// <param name="n">The bit-width</param>
        [TypeSyntax(AddressW)]
        public static TypeSpec address(uint w) => string.Format(I,w);

        /// <summary>
        /// Defines a signed integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeSyntax(I)]
        public static TypeSpec i(uint n) => string.Format(I,n);

        /// <summary>
        /// Defines an unsigned integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeSyntax(U)]
        public static TypeSpec u(uint n) => string.Format(U,n);

        /// <summary>
        /// Defines a u8 integer type
        /// </summary>
        [TypeSyntax(nameof(u8))]
        public static TypeSpec u8() => u(8);

        /// <summary>
        /// Defines a u16 integer type
        /// </summary>
        [TypeSyntax(nameof(u16))]
        public static TypeSpec u16() => u(16);

        /// <summary>
        /// Defines a u32 integer type
        /// </summary>
        [TypeSyntax(nameof(u32))]
        public static TypeSpec u32() => u(32);

        /// <summary>
        /// Defines a u64 integer type
        /// </summary>
        [TypeSyntax(nameof(u64))]
        public static TypeSpec u64() => u(64);

        /// <summary>
        /// Defines a u128 integer type
        /// </summary>
        [TypeSyntax(nameof(u128))]
        public static TypeSpec u128() => u(128);

        /// <summary>
        /// Defines a u256 integer type
        /// </summary>
        [TypeSyntax(nameof(u256))]
        public static TypeSpec u256() => u(256);

        /// <summary>
        /// Defines a u512 integer type
        /// </summary>
        [TypeSyntax(nameof(u512))]
        public static TypeSpec u512() => u(512);

        /// <summary>
        /// Defines an i8 integer type
        /// </summary>
        [TypeSyntax(nameof(i8))]
        public static TypeSpec i8() => i(8);

        /// <summary>
        /// Defines an i16 integer type
        /// </summary>
        [TypeSyntax(nameof(i16))]
        public static TypeSpec i16() => i(16);

        /// <summary>
        /// Defines an i32 integer type
        /// </summary>
        [TypeSyntax(nameof(i32))]
        public static TypeSpec i32() => i(32);

        /// <summary>
        /// Defines an i64 integer type
        /// </summary>
        [TypeSyntax(nameof(i64))]
        public static TypeSpec i64() => i(64);

        /// <summary>
        /// Defines an i128 integer type
        /// </summary>
        [TypeSyntax(nameof(i128))]
        public static TypeSpec i128() => i(128);

        /// <summary>
        /// Defines an i256 integer type
        /// </summary>
        [TypeSyntax(nameof(i256))]
        public static TypeSpec i256() => i(256);

        /// <summary>
        /// Defines an i512 integer type
        /// </summary>
        [TypeSyntax(nameof(i512))]
        public static TypeSpec i512() => i(512);

        /// <summary>
        /// Defines a sequence of arbitrary length over a parametric type
        /// </summary>
        /// <param name="type">The element type</param>
        /// <param name="parameters">The type parameter(s), if any</param>
        [TypeSyntax(Seq)]
        public static TypeSpec seq(TypeSpec type, params object[] parameters) => string.Format(Seq, type.Format(parameters));

        /// <summary>
        /// Defines a sequence of parametric length over a parametric type
        /// </summary>
        /// <param name="n">The sequence length</param>
        /// <param name="type">The element type</param>
        /// <param name="parameters">The type parameter(s), if any</param>
        [TypeSyntax(SeqN)]
        public static TypeSpec seq(uint n, TypeSpec type, params object[] parameters) => string.Format(SeqN, type.Format(parameters), n);

        /// <summary>
        /// Defines an index of parametric type
        /// </summary>
        /// <param name="type">The cell type</param>
        /// <param name="parameters">The type parameter(s), if any</param>
        [TypeSyntax(Idx)]
        public static TypeSpec index(TypeSpec type, params object[] parameters) => string.Format(Idx, type.Format(parameters));

        /// <summary>
        /// Defines a 1-dimensional array over a specified element type
        /// </summary>
        /// <param name="e">The array element type</param>
        /// <param name="parameters">The type parameter(s), if any</param>
        [TypeSyntax(Scalar)]
        public static TypeSpec array(TypeSpec e, params object[] parameters) => string.Format(Array, e.Format(parameters));

        /// <summary>
        /// Defines a character type of parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        [TypeSyntax(C)]
        public static TypeSpec c(byte n) => n <= 32 ? string.Format(C, n) : EmptyString;

        [TypeSyntax(nameof(c16))]
        public static TypeSpec c16() => c(16);

        [TypeSyntax(nameof(c8))]
        public static TypeSpec c8() => c(8);

        /// <summary>
        /// Defines a type that represents a readonly span over a specified element type
        /// </summary>
        /// <param name="element">The element type</param>
        [TypeSyntax(ConstSpan)]
        public static TypeSpec cspan(TypeSpec element) => string.Format(ConstSpan, element);

        /// <summary>
        /// Defines a type that represents a span over a specified element type
        /// </summary>
        /// <param name="element">The element type</param>
        [TypeSyntax(Span)]
        public static TypeSpec span(TypeSpec element) => string.Format(Span, element);

        /// <summary>
        /// Defines a type that represents a span or readonly span over a specified element type
        /// </summary>
        /// <param name="element">The element type</param>
        /// <param name="@const">Whether the type is readonly</param>
        public static TypeSpec span(TypeSpec element, bool @const) => @const ? cspan(element) : span(element);

        /// <summary>
        /// Defines a character type of parametric kind and parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        /// <param name="parameters">The type parameter(s), if any</param>
        [TypeSyntax(C)]
        public static TypeSpec ct(byte n, TypeSpec t, params object[] parameters) => n <= 32 ? string.Format(C, n, t.Format(parameters)) : EmptyString;

        /// <summary>
        /// Defines a type classifier
        /// </summary>
        /// <param name="name">The class name</param>
        [TypeSyntax(S)]
        public static string kind(string name) => string.Format(Kind,name);

        /// <summary>
        /// Defines a string of arbitrary length
        /// </summary>
        [TypeSyntax(S)]
        public static TypeSpec s() => S;

        /// <summary>
        /// Defines the bit type
        /// </summary>
        [TypeSyntax(Bit)]
        public static TypeSpec bit() => Bit;

        /// <summary>
        /// Defines a string of parametric length
        /// </summary>
        /// <param name="n">The string length</param>
        [TypeSyntax(Sn)]
        public static TypeSpec s(uint n) => string.Format(Sn, n);

        /// <summary>
        /// Defines a string of arbitrary length over a parametric character type
        /// </summary>
        /// <param name="c">The character type</param>
        [TypeSyntax(St)]
        public static TypeSpec s(TypeSpec c) => string.Format(St, c.Format());

        /// <summary>
        /// Defines a string of parametric length over a parametric character type
        /// </summary>
        /// <param name="t">The character type</param>
        [TypeSyntax(Snt)]
        public static TypeSpec s(uint n, TypeSpec t) => string.Format(Snt, t.Format());

        /// <summary>
        /// Defines a character block specification
        /// </summary>
        /// <param name="n">The number of characters in the block</param>
        /// <param name="t">The character type</param>
        [TypeSyntax(Block)]
        public static TypeSpec block(uint n, TypeSpec t) => string.Format(Block, n, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by a parametric type
        /// </summary>
        /// <param name="t">The type</param>
        [TypeSyntax(BitsT)]
        public static TypeSpec bits(TypeSpec t) => string.Format(BitsT, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by both parametric type and length
        /// </summary>
        /// <param name="t">The type</param>
        /// <param name="t">The length</param>
        [TypeSyntax(BitsNT)]
        public static TypeSpec bits(uint n, TypeSpec t, params object[] parameters) => string.Format(BitsNT, t.Format(parameters));

        /// <summary>
        /// Defines a sequence of bits of parametric length
        /// </summary>
        /// <param name="n">The bit count</param>
        [TypeSyntax(Bits)]
        public static TypeSpec bits(uint n) => string.Format(Bits, n);

        /// <summary>
        /// Defines a bitvector type of content width n
        /// </summary>
        /// <param name="n">The bitvector width</param>
        [TypeSyntax(Bv)]
        public static TypeSpec bv(uint n) => string.Format(Bv, n);

        /// <summary>
        /// Defines an n-component vector over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        /// <param name="n">The number of vector components</param>
        [TypeSyntax(V)]
        public static TypeSpec v(uint n, TypeSpec cells, params object[] parameters) => string.Format(V, n, cells.Format(parameters));

        [TypeSyntax(FilePath)]
        public static TypeSpec path() => FilePath;

        [TypeSyntax(Dir)]
        public static TypeSpec dir() => Dir;

        [TypeSyntax(FileUri)]
        public static TypeSpec fileuri() => FileUri;

        [TypeSyntax(FileName)]
        public static TypeSpec filename() => FileName;

        [TypeSyntax(Folder)]
        public static TypeSpec folder() => Folder;

        public static TypeRef refer(TypeSpec type, TypeRefKind kind)
            => new TypeRef(type,kind);
    }
}