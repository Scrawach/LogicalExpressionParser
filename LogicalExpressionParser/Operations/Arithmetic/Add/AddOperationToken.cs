using LogicalExpressionParser.Operations.Logical.Binary;

namespace LogicalExpressionParser.Operations.Arithmetic.Add;

public class AddOperationToken : OperatorToken, IBinaryOperationToken
{
    public AddOperationToken(int precedence) 
        : base(precedence) { }
    
    public INode Create(INode left, INode right) => 
        new AddOperatorNode(left, right);
}