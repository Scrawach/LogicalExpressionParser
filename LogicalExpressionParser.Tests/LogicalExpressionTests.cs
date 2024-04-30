using System.Collections;
using FluentAssertions;
using LogicalExpressionParser.Operations;

namespace LogicalExpressionParser.Tests;

public class LogicalExpressionTests
{
    [TestCase("1 > 2", false)]
    [TestCase("3 > 2", true)]
    [TestCase("1 > 1", false)]
    [TestCase("1 < 2", true)]
    [TestCase("1 = 1", true)]
    [TestCase("2 > 1 > 1", false)]
    [TestCase("2 > 1 = 1", true)]
    [TestCase("2 + 1 > 2", true)]
    [TestCase("2 + 2 + 2 + 2 + 2 + 1 > 10", true)]
    public void WhenEvaluateLogicalExpression_ThenShouldReturnExpectedEvaluatedValue(string expression, bool expected)
    {
        // assign
        var logicalExpression = CreateExpression(expression);
        
        // act
        var result = logicalExpression.Evaluate(null);
        
        // assert
        result.Should().Be(expected);
    }

    [TestCaseSource(nameof(EvaluateWithVariables))]
    public void WhenEvaluateLogicalExpression_WithVariables_ThenShouldReturnExpectedEvaluatedValue(IVariables variables, string expression, bool expected)
    {
        // assign
        var logicalExpression = CreateExpression(expression);
        
        // act
        var result = logicalExpression.Evaluate(variables);
        
        // assert
        result.Should().Be(expected);
    }

    private LogicalExpression CreateExpression(string input) =>
        new
        (
            new PostfixTokens
            (
                new LineOfTokens
                (
                    new ParsedString(input), 
                    new TokenFactory()
                )
            )
        );

    private static IEnumerable EvaluateWithVariables()
    {
        var variables = new MockedVariables(new Dictionary<string, int>()
        {
            ["x"] = 10,
            ["valueName"] = 5,
            ["y"] = 15,
            ["value_name"] = 11
        });

        object[] Expression(string line, bool expected) => 
            new object[] { variables, line, expected };

        yield return Expression("x > 9", true);
        yield return Expression("x - 1 > 9", false);
        yield return Expression("x > 9 + 1", false);
        yield return Expression("x > valueName", true);
        yield return Expression("x > value_name", false);
        yield return Expression("x + value_name > y", true);
        yield return Expression("x > y", false);
        yield return Expression("x + valueName > y - 1", true);
        yield return Expression("x < y", true);
        yield return Expression("x < y - 5", false);
        yield return Expression("3 > 2 | 1 < 0", true);
        yield return Expression("1 > 1 | 2 + 1", true);
    }
    
    public class MockedVariables : IVariables
    {
        private readonly Dictionary<string, int> _dictionary;

        public MockedVariables(Dictionary<string, int> dictionary) => 
            _dictionary = dictionary;

        public int this[string variableName] => 
            _dictionary[variableName];
    }
}