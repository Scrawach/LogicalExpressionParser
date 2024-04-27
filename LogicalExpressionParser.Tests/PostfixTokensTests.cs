using System.Collections;
using FluentAssertions;

namespace LogicalExpressionParser.Tests;

public class PostfixTokensTests
{
    [TestCaseSource(nameof(PostfixTokensTestCases))]
    public void WhenEnumeratePostfixTokens_ThenShouldReturn_TokensInPostfixNotation(IEnumerable<Token> infix, IEnumerable<Token> expectedPostfix)
    {
        var postfixTokens = new PostfixTokens(infix);
        var tokens = postfixTokens.ToArray();
        tokens.Should().BeEquivalentTo(expectedPostfix, options => options.RespectingRuntimeTypes().WithStrictOrdering());
    }

    public static IEnumerable PostfixTokensTestCases()
    {
        // 1 + 2, expected: 1 2 +
        yield return new object[]
        {
            new Token[] { new VariableToken("1"), new OperatorToken(1), new VariableToken("2") },
            new Token[] { new VariableToken("1"), new VariableToken("2"), new OperatorToken(1) }
        };
        
        // 1 + 2 + 3, expected: 1 2 + 3 +
        yield return new object[]
        {
            new Token[] { new VariableToken("1"), new OperatorToken(1), new VariableToken("2"), new OperatorToken(1), new VariableToken("3") },
            new Token[] { new VariableToken("1"), new VariableToken("2"), new OperatorToken(1), new VariableToken("3"), new OperatorToken(1) }
        };
        
        // 1 > 0 + 1, expected: 1 0 1 + >
        yield return new object[]
        {
            new Token[] { new VariableToken("1"), new MoreToken(2), new VariableToken("0"), new OperatorToken(1), new VariableToken("1") },
            new Token[] {  new VariableToken("1"), new VariableToken("0"), new VariableToken("1"), new OperatorToken(1),  new MoreToken(2)  }
        };
    }
}