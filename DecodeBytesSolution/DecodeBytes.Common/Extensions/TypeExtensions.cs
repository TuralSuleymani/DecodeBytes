using DecodeBytes.Provider;
using System.Reflection;

namespace DecodeBytes.Common.Extensions
{
    internal static class TypeExtensions
    {
        public static MethodInfo? GetMethod(this Type type, BankOperationType bankOperationType)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                     .FirstOrDefault(m => m.GetCustomAttribute<BankOperationAttribute>()?.BankOperationType == bankOperationType);
        }
    }
}
