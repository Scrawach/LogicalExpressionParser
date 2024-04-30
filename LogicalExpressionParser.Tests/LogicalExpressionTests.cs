using FluentAssertions;
using LogicalExpressionParser.Tokens;

namespace LogicalExpressionParser.Tests;

public class LogicalExpressionTests
{
    [TestCase("1 > 2", false)]
    [TestCase("3 > 2", true)]
    [TestCase("1 > 1", false)]
    [TestCase("1 < 2", true)]
    [TestCase("1 = 1", true)]
    public void WhenEvaluateLogicalExpression_ThenShouldReturnExpectedEvaluatedValue(string expression, bool expected)
    {
        var logicalExpression = new LogicalExpression
        (
            new PostfixTokens
            (
                new LineOfTokens
                (
                    new ParsedString(expression), 
                    new TokenFactory()
                )
            )
        );

        var result = logicalExpression.Evaluate();
        result.Should().Be(expected);
    }
}