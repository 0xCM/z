//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    public class JsonEmitter : IJsonEmitter
    {
        readonly JsonOptions Options;

        readonly ITextEmitter Buffer;

        public static void render<T>(JsonArray<T> src, IJsonEmitter dst)
            where T : IJsonRender
        {
            dst.OpenArray();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                src[i].Render(dst);
                if(i != count - 1)
                    dst.Delimit();
            }
            dst.CloseArray();
        }

        public JsonEmitter(ITextEmitter dst)
        {
            Options = new ();
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

        public void Object<T>(T src)
        {
            Buffer.AppendLine(JsonSerializer.Serialize(src, Options.Serializer));
        }
        
        public void Serialize<T>(T src)
            where T : IJsonRender
        {
            Buffer.Append(JsonSerializer.Serialize(src, Options.Serializer));        
        }

        public void Serialize<T>(IEnumerable<T> src)
            where T : IJsonRender
        {
            Buffer.Append(JsonSerializer.Serialize(src.Array(), Options.Serializer));
        }

        public void Serialize<T>(T[] src) 
            where T : IJsonRender
                => render(Json.array(src), this);
    }
}