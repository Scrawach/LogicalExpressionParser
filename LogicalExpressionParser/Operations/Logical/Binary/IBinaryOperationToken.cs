namespace LogicalExpressionParser.Operations.Logical.Binary;

public interface IBinaryOperationToken
{
    INode Create(INode left, INode right);
}