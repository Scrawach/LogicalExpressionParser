namespace LogicalExpressionParser.Operations;

public interface INode
{
    int Evaluate(IVariables variables);
}