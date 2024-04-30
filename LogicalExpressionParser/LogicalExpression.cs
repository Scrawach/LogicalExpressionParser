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

    public bool Evaluate(IVariables variables)
    {
        var operations = new Stack<INode>();

        foreach (var token in _tokens)
        {
            var operation = CreateOperationFrom(token, operations);
            operations.Push(operation);
        }

        if (operations.Count > 1)
            throw new Exception("Invalid operation count");

        var root = operations.Pop();
        return root.Evaluate(variables) > 0;
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