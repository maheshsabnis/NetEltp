using System.Text.Json;

namespace MVC_Apps.CustomSessionExtensions
{
    public static class AppSessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value)); 
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            // Get Data from Session based on key
            var value = session.GetString(key);

            if (value == null)
                return default(T); // return a default aka empty instance

            // otherwise return value
            return JsonSerializer.Deserialize<T>(value);
        }

    }
}
