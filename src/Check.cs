using System;
using System.Collections.Generic;
using System.Diagnostics;

using JetBrains.Annotations;

using Wangkanai.Runtime.Extensions;

namespace Wangkanai.Runtime
{
    [DebuggerStepThrough]
    public static class Check
    {
        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>(T value, [InvokerParameterName] [NotNull] string parameterName)
            => value is null
                   ? throw new ArgumentNullException(parameterName)
                   : value;

        [ContractAnnotation("value:null => halt")]
        public static string NotNullOrEmpty(string value, [InvokerParameterName] [NotNull] string parameterName)
            => value.IsNullOrEmpty()
                   ? throw new ArgumentException($"{parameterName} can not be null or empty", parameterName)
                   : value;

        [ContractAnnotation("value:null => halt")]
        public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, [InvokerParameterName] [NotNull] string parameterName)
            => value.IsNullOrEmpty()
                   ? throw new ArgumentException($"{parameterName} can not be null or empty!", parameterName)
                   : value;
    }
}