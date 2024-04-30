namespace LogicalExpressionParser.Operations.Common.Variable;

public class VariableNode : INode
{
    private readonly string _variableName;

    public VariableNode(string variableName) => 
        _variableName = variableName;

    public int Evaluate(IVariables variables) => 
        variables[_variableName];
}