using System.Collections;

namespace LogicalExpressionParser;

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