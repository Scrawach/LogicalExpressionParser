using LogicalExpressionParser.Operations;

namespace LogicalExpressionParser.Tokens;

public class VariableToken : IEmptyOperationToken
{
    public VariableToken(string name) => 
        Name = name;

    public string Name { get; }
    
    public INode Create() => 
        new VariableNode(Name);
}

public class ConstantToken : IEmptyOperationToken
{
    private readonly int _constant;

    public ConstantToken(int constant) => 
        _constant = constant;

    public INode Create() => 
        new ConstantNode(_constant);
}

public class ConstantNode : INode
{
    private readonly int _constant;

    public ConstantNode(int constant) => 
        _constant = constant;

    public int Evaluate(IVariables variables) => 
        _constant;
}

public interface IEmptyOperationToken : IToken
{
    INode Create();
}