using LogicalExpressionParser.Operations.Common;

namespace LogicalExpressionParser.Operations.Logical.Binary;

public interface IBinaryOperationToken : IToken
{
    INode Create(INode left, INode right);
}