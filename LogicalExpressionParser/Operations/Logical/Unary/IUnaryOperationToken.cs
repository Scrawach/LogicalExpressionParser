namespace LogicalExpressionParser.Operations.Logical.Unary;

public interface IUnaryOperationToken
{
    INode Create(INode argument);
}