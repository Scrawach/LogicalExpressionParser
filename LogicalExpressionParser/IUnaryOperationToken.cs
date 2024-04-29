namespace LogicalExpressionParser;

public interface IUnaryOperationToken
{
    INode Create(INode argument);
}