namespace LogicalExpressionParser;

public interface IVariables
{
    int this[string variableName] { get; }
}