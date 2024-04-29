namespace LogicalExpressionParser;

public abstract class Token
{
}

public interface IUnaryOperationToken
{
    INode Create(INode argument);
}

public interface IBinaryOperationToken
{
    INode Create(INode left, INode right);
}

public interface IToken
{

}

public class VariableNode : INode
{
    private readonly VariableToken _token;

    public VariableNode(VariableToken token) => 
        _token = token;

    public int Evaluate(IVariables variables) => 
        variables[_token.Name];
}

public interface INode
{
    int Evaluate(IVariables variables);
}

public interface IVariables
{
    int this[string variableName] { get; }
}

public class NotOperatorNode : INode
{
    private readonly string _variableName;

    public NotOperatorNode(string variableName) => 
        _variableName = variableName;

    public int Evaluate(IVariables variables)
    {
        var value = variables[_variableName];
        return value > 0 ? 0 : 1;
    }
}

public class AddOperatorNode : INode
{
    private readonly INode _left;
    private readonly INode _right;

    public AddOperatorNode(INode left, INode right)
    {
        _left = left;
        _right = right;
    }

    public int Evaluate(IVariables variables) => 
        _left.Evaluate(variables) + _right.Evaluate(variables);
}

public class SubtractOperatorNode : INode
{
    private readonly INode _left;
    private readonly INode _right;

    public SubtractOperatorNode(INode left, INode right)
    {
        _left = left;
        _right = right;
    }
    public int Evaluate(IVariables variables) => 
        _left.Evaluate(variables) - _right.Evaluate(variables);
}


public abstract class BooleanOperator : INode
{
    private readonly INode _left;
    private readonly INode _right;

    protected BooleanOperator(INode left, INode right)
    {
        _left = left;
        _right = right;
    }

    public int Evaluate(IVariables variables) => 
        Evaluate(_left.Evaluate(variables), _right.Evaluate(variables)) ? 1 : 0;

    protected abstract bool Evaluate(int left, int right);
}

public class LessOperatorNode : BooleanOperator
{
    public LessOperatorNode(INode left, INode right) 
        : base(left, right) { }

    protected override bool Evaluate(int left, int right) => 
        left < right;
}

public class GreaterOperatorNode : BooleanOperator
{
    public GreaterOperatorNode(INode left, INode right) 
        : base(left, right) { }

    protected override bool Evaluate(int left, int right) => 
        left > right;
}

public class EqualOperatorNode : BooleanOperator
{
    public EqualOperatorNode(INode left, INode right) 
        : base(left, right) { }

    protected override bool Evaluate(int left, int right) => 
        left == right;
}
