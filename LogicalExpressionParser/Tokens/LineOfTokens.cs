using System.Collections;

namespace LogicalExpressionParser.Tokens;

public class LineOfTokens : IEnumerable<IToken>
{
    private readonly ParsedString _parsedString;
    private readonly TokenFactory _tokenFactory;

    public LineOfTokens(ParsedString parsedString, TokenFactory tokenFactory)
    {
        _parsedString = parsedString;
        _tokenFactory = tokenFactory;
    }

    public IEnumerator<IToken> GetEnumerator() => 
        _parsedString
            .Select(parsedString => _tokenFactory.Parse(parsedString))
            .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
}