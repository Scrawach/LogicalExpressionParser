using LogicalExpressionParser.Operations;
using LogicalExpressionParser.Operations.Common;
using LogicalExpressionParser.Operations.Logical.Binary;
using LogicalExpressionParser.Operations.Logical.Unary;

namespace LogicalExpressionParser;

public class LogicalExpression
{
    private readonly PostfixTokens _tokens;

    public LogicalExpression(PostfixTokens tokens) => 
        _tokens = tokens;

    public bool Evaluate(IVariables variables) => 
        CreateRootNodeFrom(_tokens).Evaluate(variables) > 0;

    private static INode CreateRootNodeFrom(IEnumerable<IToken> tokens)
    {
        var operations = new Stack<INode>();

        foreach (var token in tokens)
        {
            var operation = CreateOperationFrom(token, operations);
            operations.Push(operation);
        }

        if (operations.Count != 1)
            throw new Exception("Invalid operation count. It must be equal 1");

        return operations.Pop();
    }

    private static INode CreateOperationFrom(IToken token, Stack<INode> operations) =>
        token switch
        {
            IUnaryOperationToken unary => unary.Create(operations.Pop()),
            IBinaryOperationToken binary => CreateBinaryNode(operations, binary),
            IEmptyOperationToken empty => empty.Create(),
            _ => throw new ApplicationException($"{nameof(token)} has not valid type!")
        };

    private static INode CreateBinaryNode(Stack<INode> operations, IBinaryOperationToken binary)
    {
        var right = operations.Pop();
        var left = operations.Pop();
        return binary.Create(left, right);
    }
}