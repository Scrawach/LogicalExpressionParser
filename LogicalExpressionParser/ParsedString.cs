using System.Collections;
using System.Text.RegularExpressions;

namespace LogicalExpressionParser;

public class ParsedString : IEnumerable<string>
{
    private readonly Regex _regex = new Regex(@"([\w]+|[><=&-+-!|]+|=>)\s*");
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