namespace LogicalExpressionParser.Tokens;

public class OperatorToken : IToken
{
    public OperatorToken(int precedence) => 
        Precedence = precedence;

    public int Precedence { get; }
}

public class MoreToken : OperatorToken
{
    public MoreToken(int precedence) : base(precedence)
    { }
}