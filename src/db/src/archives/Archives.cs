// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------

// namespace Z0
// {
//     using System.IO.Compression;
//     using Commands;

//     using static sys;

//     public class Archives
//     {        
//         public static void copy(IWfChannel channel, CmdArgs args)
//             => copy(channel, FS.dir(args[0]), FS.dir(args[1]));
        
//         public static Task<ExecToken> copy(IWfChannel channel, FolderPath src, FolderPath dst)
//             => ProcessLauncher.launch(channel, FS.path("robocopy.exe"), Cmd.args(src, dst, "/e"));

//         public static IModuleArchive modules(FolderPath src, bool recurse = true)
//             => new ModuleArchive(src, recurse);

//         public record struct CopyFiles(FolderPath Source, FolderPath Target) 
//             : ICmdFlow<CopyFiles,FolderPath,FolderPath> {}

//         public record struct PackFolder(FolderPath Source, FileUri Target) 
//             : ICmdFlow<PackFolder,FolderPath,FileUri> {}

//         public static CopyFiles copy(FolderPath src, FolderPath dst)
//             => new (src,dst);        

//         public static PackFolder pack(FolderPath src, FileUri dst)
//             => new (src,dst);        

//         public static Outcome bind(CmdArgs src, out CreateFileCatalog dst)
//         {
//             dst = new();
//             dst.Target = Env.ShellData.Root;
//             var count = src.Count;
//             try
//             {
//                 if(count >= 1)
//                     dst.Source = FS.dir(src[0]);
                
//                 if(count >= 2)
//                     switch(src[1].Value)
//                     {
//                         case "--ext":
//                         dst.Match = sys.map(text.split(src[2].Value, Chars.Semicolon), x => FS.ext(x));
//                         break;
//                     }
//             }
//             catch(Exception e)
//             {
//                 return e;
//             }
        
//             return true;
//         }   

//         public static IDbArchive archive(Timestamp ts, DbArchive dst)
//             => dst.Scoped(ts.Format());

//         public static FolderPath folder(string src)
//             => FS.dir(src);

//         public static EnvPath folders(ReadOnlySpan<string> src)
//             => src.Map(FS.dir);

//         public static string identifier(FolderPath src)
//             => FS.identifier(src);

//         public static FileName timestamped(string name, FileExt ext)
//             => FS.file(string.Format("{0}.{1}", name, (sys.timestamp()).Format()),ext);

//         [Op]
//         public static FilePath timestamped(FilePath src)
//         {
//             var name = src.FileName.WithoutExtension;
//             var ext = src.Ext;
//             var stamped = FS.file(string.Format("{0}.{1}.{2}", name, sys.timestamp(), ext));
//             return src.FolderPath + stamped;
//         }

//         public static Outcome timestamp(FolderPath src, out Timestamp dst)
//         {
//             dst = Timestamp.Zero;
//             if(src.IsEmpty)
//                 return false;

//             var fmt = src.Format(PathSeparator.FS);
//             var idx = fmt.LastIndexOf(Chars.FSlash);
//             if(idx == NotFound)
//                 return false;

//             var outcome = Timing.parse(fmt.RightOfIndex(idx), out var ts);
//             if(outcome)
//             {
//                 dst = ts;
//                 return true;
//             }
//             else
//                 return(false,outcome.Message);
//         }
//     }
// }