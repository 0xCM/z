//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(files)]
    public enum FileKind : uint
    {
        None = 0,

        [Symbol(asm,"Formatted x86 assembly")]
        Asm,

        [Symbol(db,"A Sqlite database file")]
        Db,

        [Symbol(disasm, "An assembly file produced via a disassembly process")]
        DisAsm,

        [Symbol(encasm, "An asm file that contains the encoding as comments")]
        EncAsm,

        [Symbol(synasm)]
        SynAsm,

        [Symbol(synasmlog)]
        SynAsmLog,

        [Symbol(nupkg, "A nuget archive")]
        Nuget,


        [Symbol(bat, "A windows batch file")]
        Bat,

        [Symbol(bc, "An llvm-ir binary file")]
        Bc,

        [Symbol(bin, "A flat binary file")]
        Bin,

        [Symbol("bits", "A bitfield specification")]
        Bits,

        [Symbol(i, "A file generated by a pre-processor for a c translation unit")]
        Ci,

        [Symbol(ii, "A file generated by a pre-processor for a cpp translation unit")]
        Cii,

        [Symbol(il, "Msil source text")]
        Il,

        [Symbol(ildat, "Msil bytes")]
        MsilDat,

        [Symbol(msi, "A miserable installer file")]
        Msi,

        [Symbol(cmd, "A windows batch file")]
        Cmd,

        [Symbol(c, "A c source file")]
        C,

        [Symbol(config, "A text file with colon-delimited key-value lines")]
        Config,

        [Symbol(cfg, "A text file where each line binds a name to a value")]
        Cfg,

        [Symbol(ps1, "A powershell script")]
        Ps1,

        [Symbol(coffheader, "A file containing a textual description of the headers in a COFF object file")]
        CoffHeader,

        [Symbol(coffreloc, "A file containing a textual description of coff relocations")]

        CoffReloc,

        [Symbol(coffexports)]
        CoffExports,

        [Symbol(loadconfig)]
        LoadConfig,

        [Symbol(cpp, "A cpp source file")]
        Cpp,

        [Symbol(csv,"Delimited data rows")]
        Csv,

        [Symbol(cs, "A csharp source file")]
        Cs,

        [Symbol(csproj, "A CSharp project file")]
        CsProj,

        [Symbol(dmp, "A windows dump file")]
        Dmp,

        [Symbol(def)]
        Def,

        [Symbol(dll, "A dynamic library module")]
        Dll,

        [Symbol(exe, "A portable executable file")]
        Exe,

        [Symbol(h, "A C/C++ header file")]
        H,

        [Symbol(hex, "Text-formatted hex data")]
        Hex,

        [Symbol(hexdat)]
        HexDat,

        [Symbol(toml, "A toml configuration file")]
        Toml,

        [Symbol(idx)]
        Idx,

        [Symbol(inc)]
        Inc,

        [Symbol(json, "Json data")]
        Json,

        [Symbol(deps_list, "Application dependency list")]
        DepsList,

        [Symbol(deps_json, "A .net json dependency file")]
        JsonDeps,

        [Symbol(lib, "A static library module")]
        Lib,

        [Symbol(list, "A simple eol-delimited text file")]
        List,

        [Symbol(llasm, "An asm file produced by llc")]
        LlAsm,

        [Symbol(llbc, "An llvm bitcode file produced by compilation of an *.ll file")]
        LlBc,

        [Symbol(ll, "An llvm-ir text file")]
        Llir,

        [Symbol(log,"Text-formatted log data")]
        Log,

        [Symbol(located_hex, "A text file containing lines of hex data, where each line begins with a 64-bit address")]
        LocatedHex,

        [Symbol(map,"A configuration file that correlates line-ranges and records/entities")]
        Map,

        [Symbol(impl_map)]
        ImplMap,

        [Symbol(mcasm, "An asm file produced by the llvm-mc tool")]
        McAsm,

        [Symbol(md, "A Mardown document")]
        Md,

        [Symbol(mlir, "An LLVM mlir document")]
        Mlir,

        [Symbol(mir)]
        Mir,

        [Symbol(o, "A coff object file")]
        O,

        [Symbol(obi, "A textual description of acoff object file as produced by llvm-readobj")]
        Obi,

        [Symbol(obj, "A coff object file")]
        Obj,

        [Symbol(objasm, "An assembly file derived from an object file")]
        ObjAsm,

        [Symbol(objyaml)]
        ObjYaml,

        [Symbol(pdb, "A program database file")]
        Pdb,

        [Symbol(pcsv,"Text-formatted x86-encoded/executable data")]
        PCsv,

        [Symbol(s, "A file with an ugly asm syntax, also known as ATT syntax")]
        S,

        [Symbol(sh, "A bash shell script")]
        Sh,

        [Symbol(sql, "A sql script")]
        Sql,

        [Symbol(sym,"A symbol table as emitted by llvm-nm")]
        Sym,

        [Symbol(td, "An llvm table definition file")]
        Td,

        [Symbol(txt,"Text data")]
        Txt,

        [Symbol(xcsv,"Unprocessed x86-encoded data")]
        XCsv,

        [Symbol(xpack, "Text-formatted hex with base addresses")]
        XPack,

        [Symbol(xml, "Xml data")]
        Xml,

        [Symbol(yamltok)]
        YamlTok,

        [Symbol(xeddisasm_raw, "Xed disassembly information as emitted from the xed tool")]
        XedRawDisasm,

        [Symbol(xeddisasm_summary, "Xed disassembly tabular summary")]
        XedSummaryDisasm,

        [Symbol(xeddisasm_semantic, "Xed disassembly details with semantic interpretation")]
        XedSemanticDisasm,

        [Symbol(xeddisasm_detail, "Xed disassembly details in columnar format")]
        XedDisasmDetail,

        [Symbol(zip, "A zip archive binary")]
        Zip,

        [Symbol(nuspec, "A nuget package specification")]
        Nuspec,

        [Symbol(env, "An environment configuration document")]
        Env,

        [Symbol(help, "A plaintext tool help document")]
        Help,

        [Symbol(dotfile, "A .dot graph document")]
        Dot,

        [Symbol(kvp, "A text file where each line defines a key-value pair")]
        Kvp,

        [Symbol(yaml, "A Yaml file")]
        Yaml,

        [Symbol(props, "A Microsoft Build property document")]
        Props,

        [Symbol(sln, "A Visual Studio Solution document")]
        Sln,

        [Symbol(bmp, "A bitmap file")]
        Bmp,

        [Symbol(ico, "An icon file")]
        Ico,

        [Symbol(svg, "An svg file")]
        Svg,

        [Symbol(cmdkvp, "A file with KVP semantics/syntax refined to specify a sequence of application commands")]
        CmdKvp,

        [Symbol(job, "A job specification")]
        Job,
    }
}