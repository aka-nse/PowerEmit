// See https://aka.ms/new-console-template for more information

ISampleCase[] sampleCases = [
    new EmitIL_ConventionalStyle(),
    new EmitIL_SimpleStyle(),
    new EmitIL_ListedPowerEmitAction(),
    new EmitIL_MixedStyle(),
    new Disassemble(),
    new Deoptimize(),
];

foreach(var sampleCase in sampleCases)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"--- Running {sampleCase.GetType().Name} ---");
    Console.ResetColor();
    sampleCase.Run();
    Console.WriteLine();
}
