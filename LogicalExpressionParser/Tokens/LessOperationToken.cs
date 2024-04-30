using LogicalExpressionParser.Operations;
using LogicalExpressionParser.Operations.Logical.Binary;

namespace LogicalExpressionParser.Tokens;

public class LessOperationToken : OperatorToken, IBinaryOperationToken
{
    public LessOperationToken(int precedence) 
        : base(precedence) { }

    public INode Create(INode left, INode right) => 
        new LessOperatorNode(left, right);
}