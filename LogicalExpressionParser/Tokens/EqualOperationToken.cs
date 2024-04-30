using LogicalExpressionParser.Operations;
using LogicalExpressionParser.Operations.Logical.Binary;

namespace LogicalExpressionParser.Tokens;

public class EqualOperationToken : OperatorToken, IBinaryOperationToken
{
    public EqualOperationToken(int precedence) 
        : base(precedence) { }

    public INode Create(INode left, INode right) => 
        new EqualOperatorNode(left, right);
}