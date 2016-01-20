using Newtonsoft.Json.Linq;

namespace ProPresenterRemote
{
    public static class JsonExtensions
    {
        public static string GetStringValue(this JToken jToken, string key, string defaultValue = null)
        {
            try
            {
                return (string)jToken.SelectToken(key);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetIntValue(this JToken jToken, string key, int defaultValue = 0, bool allowString = false)
        {
            int num = defaultValue;

            try
            {
                JToken jtoken = jToken.SelectToken(key);
                if (jtoken != null)
                    num = !allowString || jtoken.Type != JTokenType.String ? (int)jtoken : int.Parse((string)jtoken);
            }
            catch
            {
            }

            return num;
        }
    }
}
