namespace LogicalExpressionParser.Tokens;

public class VariableToken : Token
{
    public VariableToken(string name) => 
        Name = name;

    public string Name { get; }
}