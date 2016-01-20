using Newtonsoft.Json.Linq;

namespace ProPresenterRemote
{
    public static class JsonExtensions
    {
        public static string GetStringValue(this JToken jToken, string key, string defaultValue = null)
        {
            string str = defaultValue;
            try
            {
                str = (string)jToken.SelectToken(key);
            }
            catch
            {
            }
            return str;
        }

        public static int GetIntValue(this JToken jToken, string key, int defaultValue = 0, bool allowString = false)
        {
            int num = defaultValue;
            if (jToken != null)
            {
                try
                {
                    JToken jtoken = jToken.SelectToken(key);
                    if (jtoken != null)
                        num = !allowString || jtoken.Type != JTokenType.String ? (int)jtoken : int.Parse((string)jtoken);
                }
                catch
                {
                }
            }
            return num;
        }

        public static bool GetBoolValue(this JToken jToken, string key, bool defaultValue = false)
        {
            bool flag = defaultValue;
            if (jToken != null)
            {
                try
                {
                    JToken jtoken = jToken.SelectToken(key);
                    if (jtoken != null)
                    {
                        if (jtoken.Type == JTokenType.String)
                            flag = DeserializeBool((string)jtoken);
                        else if (jtoken.Type == JTokenType.Integer)
                            flag = (int)jtoken != 0;
                        else if (jtoken.Type == JTokenType.Boolean)
                            flag = (bool)jToken.SelectToken(key);
                    }
                }
                catch
                {
                }
            }
            return flag;
        }

        public static bool DeserializeBool(string boolStr)
        {
            if (string.IsNullOrWhiteSpace(boolStr))
                return false;
            string str = boolStr.ToLower();
            return str == "1" || str == "yes" || str == "true";
        }
    }
}
