namespace LogicalExpressionParser.Tokens;

public class TokenFactory
{
    public IToken Parse(string content) =>
        content.ToLower() switch
        {
            ">" => new GreaterOperationToken(2),
            "<" => new LessOperationToken(2),
            "=" => new EqualOperationToken(3),
            _ => ParseVariableOrConstant(content)
        };

    private static IToken ParseVariableOrConstant(string content) => 
        int.TryParse(content, out var value) 
            ? new ConstantToken(value) 
            : new VariableToken(content);
}