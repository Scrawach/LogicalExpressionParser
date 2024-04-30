using LogicalExpressionParser.Operations.Arithmetic.Add;
using LogicalExpressionParser.Operations.Arithmetic.Subtract;
using LogicalExpressionParser.Operations.Common;
using LogicalExpressionParser.Operations.Common.Constant;
using LogicalExpressionParser.Operations.Common.Variable;
using LogicalExpressionParser.Operations.Logical.Binary.And;
using LogicalExpressionParser.Operations.Logical.Binary.Equal;
using LogicalExpressionParser.Operations.Logical.Binary.Greater;
using LogicalExpressionParser.Operations.Logical.Binary.Less;
using LogicalExpressionParser.Operations.Logical.Binary.Or;

namespace LogicalExpressionParser.Operations;

public class TokenFactory
{
    public IToken Parse(string content) =>
        content.ToLower() switch
        {
            "-" => new SubtractOperationToken(3),
            "+" => new AddOperationToken(3),
            ">" => new GreaterOperationToken(2),
            "<" => new LessOperationToken(2),
            "=" or "==" => new EqualOperationToken(2),
            "|" or "||" => new OrOperationToken(1),
            "&" or "&&" => new AndOperationToken(1),
            _ => ParseVariableOrConstant(content)
        };

    private static IToken ParseVariableOrConstant(string content) => 
        int.TryParse(content, out var value) 
            ? new ConstantToken(value) 
            : new VariableToken(content);
}