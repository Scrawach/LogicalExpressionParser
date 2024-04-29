using LogicalExpressionParser.Tokens;

namespace LogicalExpressionParser.Operations;

public class VariableNode : INode
{
    private readonly VariableToken _token;

    public VariableNode(VariableToken token) => 
        _token = token;

    public int Evaluate(IVariables variables) => 
        variables[_token.Name];
}