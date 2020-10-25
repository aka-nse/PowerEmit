using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit.Emit
{
    public class OpCodeCompletenessTest
    {
        public static string[] ExcludeOpCodes = new string[]
        {
            // optimized opcodes
            "Prefix1",
            "Prefix2",
            "Prefix3",
            "Prefix4",
            "Prefix5",
            "Prefix6",
            "Prefix7",
            "Prefixref",
        };

        [Fact]
        public void Test()
        {
            var opcodes = typeof(OpCodes)
                .GetFields()
                .Where(fInfo => fInfo.FieldType == typeof(OpCode))
                .Where(fInfo => !ExcludeOpCodes.Contains(fInfo.Name))
                .ToList();
            var operations = typeof(ICilOperation)
                .Assembly
                .GetTypes()
                .Where(t => typeof(ICilOperation).IsAssignableFrom(t))
                .ToList();
            foreach(var operation in operations)
            {
                opcodes.Remove(opcodes.FirstOrDefault(fInfo => fInfo.Name == operation.Name));
            }

            if(opcodes.Count > 0)
            {
                var errortext = $"There are {opcodes.Count} not implemented opcodes:\n"
                    + string.Join("\n", opcodes.Select(fInfo => "  " + fInfo.Name));
                Assert.True(false, errortext);
            }
        }
    }
}
