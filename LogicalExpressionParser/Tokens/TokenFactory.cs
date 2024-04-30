using LogicalExpressionParser.Operations;
using LogicalExpressionParser.Operations.Arithmetic;
using LogicalExpressionParser.Operations.Logical.Binary;

namespace LogicalExpressionParser.Tokens;

public class TokenFactory
{
    public IToken Parse(string content) =>
        content.ToLower() switch
        {
            "-" => new SubtractOperationToken(3),
            "+" => new AddOperationToken(3),
            ">" => new GreaterOperationToken(2),
            "<" => new LessOperationToken(2),
            "=" => new EqualOperationToken(2),
            _ => ParseVariableOrConstant(content)
        };

    private static IToken ParseVariableOrConstant(string content) => 
        int.TryParse(content, out var value) 
            ? new ConstantToken(value) 
            : new VariableToken(content);
}

public class SubtractOperationToken : OperatorToken, IBinaryOperationToken
{
    public SubtractOperationToken(int precedence) 
        : base(precedence) { }

    public INode Create(INode left, INode right) => 
        new SubtractOperatorNode(left, right);
}