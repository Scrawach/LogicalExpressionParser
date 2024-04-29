namespace LogicalExpressionParser;

public class TokenFactory
{
    public Token Parse(string content)
    {
        return content.ToLower() switch
        {
            "|" => new OperatorToken(1),
            "&" => new OperatorToken(1),
            ">" => new MoreToken(2),
            "<" => new OperatorToken(2),
            "=" => new OperatorToken(3),
            _ => new VariableToken(content)
        };
    }
}