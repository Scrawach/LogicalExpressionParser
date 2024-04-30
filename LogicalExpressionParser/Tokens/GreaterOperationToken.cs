using LogicalExpressionParser.Operations;
using LogicalExpressionParser.Operations.Logical.Binary;

namespace LogicalExpressionParser.Tokens;

public class GreaterOperationToken : OperatorToken, IBinaryOperationToken
{
    public GreaterOperationToken(int precedence) 
        : base(precedence) { }
    
    public INode Create(INode left, INode right) => 
        new GreaterOperatorNode(left, right);
}