using System.Collections;

namespace LogicalExpressionParser.Tokens;

public class PostfixTokens : IEnumerable<IToken>
{
    private readonly IEnumerable<IToken> _tokens;
    
    public PostfixTokens(IEnumerable<IToken> infixTokens) => 
        _tokens = infixTokens;
    
    public IEnumerator<IToken> GetEnumerator()
    {
        var stackOfOperators = new Stack<OperatorToken>();
        
        foreach (var token in _tokens)
        {
            switch (token)
            {
                case OperatorToken op:
                    if (stackOfOperators.Count > 0 && stackOfOperators.Peek().Precedence <= op.Precedence)
                        yield return stackOfOperators.Pop();
                    stackOfOperators.Push(op);
                    break;
                
                default:
                    yield return token;
                    break;
            }
        }

        foreach (var op in stackOfOperators)
            yield return op;
    }

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}