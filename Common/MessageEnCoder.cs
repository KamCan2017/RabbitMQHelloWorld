using System.Text;

namespace Common
{
    /// <summary>
    /// MessageEncoder codes/decodes message for receiver and publisher
    /// </summary>
    public class MessageEnCoder
    {
        public static object CodeMessage(string message, string key)
        {
            if(key == RoutingKeys.HelloChannel)
               return Encoding.UTF8.GetBytes(message);

            return null;
        }

        public static object DecodeMessage(byte[] body, string key)
        {
            if (key == RoutingKeys.HelloChannel)
                return Encoding.UTF8.GetString(body);

            return null;
        }
    }
}
