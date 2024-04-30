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
            switch (token)
            {
                case IUnaryOperationToken unary:
                    operations.Push(unary.Create(operations.Pop()));
                    break;
                case IBinaryOperationToken binary:
                    var right = operations.Pop();
                    var left = operations.Pop();
                    operations.Push(binary.Create(left, right));
                    break;
                case IEmptyOperationToken empty:
                    operations.Push(empty.Create());
                    break;
            }
        }

        return operations.Pop().Evaluate(variables) > 0;
    }
}