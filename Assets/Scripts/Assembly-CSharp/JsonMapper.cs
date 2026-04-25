// Class:  LitJson.JsonMapper (facade)
// Source: gốc uses LitJson library by Leandro Ramos (https://litjson.sourceforge.net/).
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex varies by build)
//
// DEVIATION 2026-04-25:
// - thanmaorigin doesn't ship LitJson.dll. We provide a minimal LitJson namespace
//   facade backed by Newtonsoft.Json (already in project via manifest).
// - Method shapes match gốc 1-1: ToJson(object) → string ; ToObject<T>(string) → T.
// - Dictionary<string, X> + arrays + primitives are all supported by Newtonsoft.

using Newtonsoft.Json;

namespace LitJson
{
    public static class JsonMapper
    {
        // gốc: LitJson_JsonMapper__ToJson(obj, 0)
        public static string ToJson(object obj)
        {
            if (obj == null) return "null";
            return JsonConvert.SerializeObject(obj);
        }

        // gốc: LitJson_JsonMapper__ToObject<T>(content)
        public static T ToObject<T>(string json)
        {
            if (string.IsNullOrEmpty(json)) return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
