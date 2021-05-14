﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

using JetBrains.Annotations;

using Wangkanai.Extensions;

namespace Wangkanai
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

        public static bool NotLessThan(int value, int expected, [InvokerParameterName] [NotNull] string parameterName)
            => (value < expected)
                   ? throw new ArgumentException($"{parameterName} argument can not be bigger than given string's length!")
                   : value < expected;
        public static bool NotMoreThan(int value, int expected, [InvokerParameterName] [NotNull] string parameterName)
            => (value > expected)
                   ? throw new ArgumentException($"{parameterName} argument can not be smaller than given string's length!")
                   : value > expected;
    }
}