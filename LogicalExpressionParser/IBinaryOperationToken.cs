namespace LogicalExpressionParser;

public interface IBinaryOperationToken
{
    INode Create(INode left, INode right);
}