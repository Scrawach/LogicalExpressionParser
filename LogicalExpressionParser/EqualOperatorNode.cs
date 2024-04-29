namespace LogicalExpressionParser;

public class EqualOperatorNode : BinaryBooleanOperator
{
    public EqualOperatorNode(INode left, INode right) 
        : base(left, right) { }

    protected override bool Evaluate(int left, int right) => 
        left == right;
}