using LogicalExpressionParser.Operations.Common;

namespace LogicalExpressionParser.Operations.Logical.Unary;

public interface IUnaryOperationToken : IToken
{
    INode Create(INode argument);
}