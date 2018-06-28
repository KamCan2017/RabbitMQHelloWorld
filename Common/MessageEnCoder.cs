using System.Text;

namespace Common
{
    /// <summary>
    /// MessageEncoder codes/decodes message for receiver and publisher
    /// </summary>
    public class MessageEnCoder
    {
        public static byte[] CodeMessage(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        public static string DecodeMessage(byte[] body)
        {
            return Encoding.UTF8.GetString(body);
        }
    }
}
