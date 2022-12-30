//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    partial class Json
    {
        [Op, Closures(Closure)]
        public static JsonDocument document(ReadOnlySeq<byte> src)
            => JsonDocument.Parse(src.Storage);
            
        [Op, Closures(Closure)]
        public static JsonDocument document<T>(T src, bool indented = true)
            => JsonSerializer.SerializeToDocument(src, new JsonSerializerOptions{WriteIndented = indented, AllowTrailingCommas = true});
    }
}
