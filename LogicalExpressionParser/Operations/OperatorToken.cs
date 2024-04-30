using LogicalExpressionParser.Operations.Common;

namespace LogicalExpressionParser.Operations;

public class OperatorToken : IToken
{
    public OperatorToken(int precedence) => 
        Precedence = precedence;

    public int Precedence { get; }
}