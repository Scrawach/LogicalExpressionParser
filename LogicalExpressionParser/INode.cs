namespace LogicalExpressionParser;

public interface INode
{
    int Evaluate(IVariables variables);
}