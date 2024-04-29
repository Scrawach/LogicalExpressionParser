using System.Collections;
using System.Text.RegularExpressions;

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

public class Test
{
    public void Usage()
    {
         var expression = new LogicalExpression
         (
             new PostfixTokens
             (
                 new LineOfTokens
                 (
                     new ParsedString("1 + 2"), 
                     new TokenFactory()
                 )
             )
         ); 
         
         expression.Evaluate();
    }
}

public class LogicalExpression
{
    private readonly PostfixTokens _tokens;

    public LogicalExpression(PostfixTokens tokens) => 
        _tokens = tokens;

    public bool Evaluate()
    {
        var operands = new Stack<VariableToken>();
        
        foreach (var token in _tokens)
        {
            switch (token)
            {
                case VariableToken:
                    break;
                
                case OperatorToken:
                    break;
            }
        }
    }
}

public class ParsedString : IEnumerable<string>
{
    private readonly Regex _regex = new Regex(@"([\w]+|[><=&+!|]+|=>)\s*");
    private readonly string _input;

    public ParsedString(string input) => 
        _input = input;

    public IEnumerator<string> GetEnumerator()
    {
        var position = 0;
        
        while (position < _input.Length)
        {
            var match = _regex.Match(_input, position);

            if (!match.Success)
                throw new Exception($"Invalid token at position {position}");

            var token = match.Groups[1].Value;
            position += match.Length;

            yield return token;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}

public class LineOfTokens : IEnumerable<Token>
{
    private readonly ParsedString _parsedString;
    private readonly TokenFactory _tokenFactory;

    public LineOfTokens(ParsedString parsedString, TokenFactory tokenFactory)
    {
        _parsedString = parsedString;
        _tokenFactory = tokenFactory;
    }

    public IEnumerator<Token> GetEnumerator() => 
        _parsedString
            .Select(parsedString => _tokenFactory.Parse(parsedString))
            .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}