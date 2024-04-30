using System.Collections;
using FluentAssertions;
using LogicalExpressionParser.Tokens;

namespace LogicalExpressionParser.Tests;

public class LineOfTokensTests
{
    [TestCaseSource(nameof(LineOfTokensTestCases))]
    public void WhenEnumerateLineOfTokens_ThenShouldReturnCorrectTokens_ParsedFromStringLine(string expression, IEnumerable<IToken> expectedTokens)
    {
        // assign
        var linesOfTokens = new LineOfTokens(new ParsedString(expression), new TokenFactory());
        
        // act
        var tokens = linesOfTokens.ToArray();
        
        // assert
        tokens.Should().BeEquivalentTo(expectedTokens, options => options.RespectingRuntimeTypes());
    }

    private static IEnumerable LineOfTokensTestCases()
    {
        yield return SingleTestCase("1|2", new VariableToken("1"), new OperatorToken(1), new VariableToken("2"));
        yield return SingleTestCase("1&2", new VariableToken("1"), new OperatorToken(1), new VariableToken("2"));
        yield return SingleTestCase("1=2", new VariableToken("1"), new OperatorToken(1), new VariableToken("2"));
        yield return SingleTestCase("1>2", new VariableToken("1"), new OperatorToken(1), new VariableToken("2"));
        yield return SingleTestCase("1<2", new VariableToken("1"), new OperatorToken(1), new VariableToken("2"));
    }

    private static object[] SingleTestCase(string expression, params IToken[] expectedTokens) => 
        new object[] { expression, expectedTokens };
}