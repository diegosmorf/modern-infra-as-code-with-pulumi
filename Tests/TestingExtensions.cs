// Copyright 2016-2020, Pulumi Corporation

using System.Threading.Tasks;
using Pulumi;

namespace UnitTesting
{
    public static class TestingExtensions
    {
        /// <summary>
        /// Extract the value from an output.
        /// </summary>
        public static Task<T> GetValueAsync<T>(this Output<T> output)
        {
            var tcs = new TaskCompletionSource<T>();
            output.Apply(v =>
            {
                tcs.SetResult(v);
                return v;
            });
            return tcs.Task;
        }
    }
}