namespace PowerEmit;

internal static class ExceptionHelper
{
    internal static InvalidCastException InvalidOperandType()
        => new("The operand type is not supported.");


    internal static InvalidOperationException AlreadyLabelMarked()
        => new("A label has already been marked to teh specified IL generator.");
}