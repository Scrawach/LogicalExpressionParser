using LogicalExpressionParser.Operations.Logical.Binary;

namespace LogicalExpressionParser.Operations.Arithmetic.Subtract;

public class SubtractOperationToken : OperatorToken, IBinaryOperationToken
{
    public SubtractOperationToken(int precedence) 
        : base(precedence) { }

    public INode Create(INode left, INode right) => 
        new SubtractOperatorNode(left, right);
}