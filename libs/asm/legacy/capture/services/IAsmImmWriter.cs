//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines service contract for persisting asm functions which are derived from .net member functions
    /// </summary>
    public interface IAsmImmWriter
    {
        /// <summary>
        /// The api host
        /// </summary>
        ApiHostUri Uri {get;}

        /// <summary>
        /// Saves an array of functions as formatted asm
        /// </summary>
        /// <param name="src">The source functions</param>
        /// <param name="append">Whether to append to an existing file or else overwrite</param>
        Option<FS.FilePath> SaveAsmImm(OpIdentity id, AsmRoutine[] src, bool append, bool refined);

        /// <summary>
        /// Saves the encoded data contained in an array of decded functions
        /// </summary>
        /// <param name="src">The source functions</param>
        /// <param name="append">Whether to append to an existing file or else overwrite</param>
        ApiCodeset SaveHexImm(OpIdentity id, AsmRoutine[] src, bool append, bool refined);
    }
}