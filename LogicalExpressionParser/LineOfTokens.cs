using System.Collections;
using System.Text.RegularExpressions;

namespace LogicalExpressionParser;

public class LineOfTokens : IEnumerable<Token>
{
    private readonly Regex _regex = new Regex(@"([\w]+|[><=&+!|]|=>)\s*");
    private readonly string _inputLine;

    public LineOfTokens(string inputLine) => 
        _inputLine = inputLine;

    public IEnumerator<Token> GetEnumerator()
    {
        var position = 0;
        
        while (position < _inputLine.Length)
        {
            var match = _regex.Match(_inputLine, position);

            if (!match.Success)
                throw new Exception($"Invalid token at position {position}");

            var token = match.Groups[1].Value;
            position += match.Length;

            yield return token.ToLower() switch
            {
                "|" => new OperatorToken(1),
                "&" => new OperatorToken(1),
                ">" => new MoreToken(2),
                "<" => new OperatorToken(2),
                "=" => new OperatorToken(3),
                _ => new VariableToken(token)
            };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}