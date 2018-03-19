using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAram.Helpers
{
    public static class Utils
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static async void SetForegroundWindow(int delayMiliseconds)
        {
            await Task.Delay(delayMiliseconds);
            var process = Process.GetCurrentProcess();
            SetForegroundWindow(process.MainWindowHandle);
        }

        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }

        public static string WithMaxLength(this string value, int maxLength)
        {
            return value?.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static string Encrypt(string value, string salt)
        {
            var bytes = Encoding.Unicode.GetBytes(value);
            var saltBytes = Encoding.Unicode.GetBytes(salt);

            var cipherBytes = ProtectedData.Protect(bytes, saltBytes, DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(cipherBytes);
        }

        public static string Decrypt(string cipher, string salt)
        {
            var cipherBytes = Convert.FromBase64String(cipher);
            var saltBytes = Encoding.Unicode.GetBytes(salt);

            byte[] bytes = ProtectedData.Unprotect(cipherBytes, saltBytes, DataProtectionScope.CurrentUser);

            return Encoding.Unicode.GetString(bytes);
        }
    }
}