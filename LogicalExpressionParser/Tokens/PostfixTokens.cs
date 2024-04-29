using System.Collections;

namespace LogicalExpressionParser.Tokens;

public class PostfixTokens : IEnumerable<Token>
{
    private readonly IEnumerable<Token> _tokens;
    
    public PostfixTokens(IEnumerable<Token> infixTokens) => 
        _tokens = infixTokens;
    
    public IEnumerator<Token> GetEnumerator()
    {
        var stackOfOperators = new Stack<OperatorToken>();
        
        foreach (var token in _tokens)
        {
            switch (token)
            {
                case VariableToken:
                    yield return token;
                    break;
                
                case OperatorToken op:
                    if (stackOfOperators.Count > 0 && stackOfOperators.Peek().Precedence <= op.Precedence)
                        yield return stackOfOperators.Pop();
                    stackOfOperators.Push(op);
                    break;
            }
        }

        foreach (var op in stackOfOperators)
            yield return op;
    }

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}