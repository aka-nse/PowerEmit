using Xunit;

namespace PowerEmit;

public class OpCodeConstTest
{
    [Fact]
    public void OpCodes()
    {
        foreach(var kv in OpCodeConst.OpCodes)
        {
            var opcode = kv.Key;
            Assert.Equal(opcode, kv.Value.Value);
        }
    }
}
