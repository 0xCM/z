//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    public class JsonEmitter
    {
        readonly JsonSerializerOptions Options;

        readonly ITextEmitter Buffer;

        internal JsonEmitter(ITextEmitter dst, JsonSerializerOptions options)
        {
            Options = options;
            Buffer= dst;
        }

        public void CloseArray()
        {
            Buffer.AppendLine(Chars.RBracket);
        }

        public void Delimit()
        {
            Buffer.Append(Chars.Comma);
        }

        public string Emit()
            => Buffer.Emit();

        public void OpenArray()
        {
            Buffer.AppendLine(Chars.LBracket);
        }

        public void Prop<T>(string name, T value)
        {
            Buffer.Append(text.concat(text.quote(name), Chars.Colon, text.quote(value)));
        }
       
        public void Serialize<T>(T src)
        {
            Buffer.Append(JsonSerializer.Serialize(src, Options));        
        }
        
        public void Serialize<T>(T[] src) 
        {
            Buffer.Append(JsonSerializer.Serialize(src, Options));
        }

        public void Serialize<T>(ReadOnlySeq<T> src) 
        {
            Buffer.Append(JsonSerializer.Serialize(src.Storage, Options));
        }
    }
}