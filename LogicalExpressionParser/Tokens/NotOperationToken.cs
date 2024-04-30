using LogicalExpressionParser.Operations;
using LogicalExpressionParser.Operations.Logical.Unary;

namespace LogicalExpressionParser.Tokens;

public class NotOperationToken : OperatorToken, IUnaryOperationToken
{
    public NotOperationToken(int precedence) 
        : base(precedence) { }

    public INode Create(INode argument) => 
        new NotOperatorNode(argument);
}