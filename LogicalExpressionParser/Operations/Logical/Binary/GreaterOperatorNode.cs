namespace LogicalExpressionParser.Operations.Logical.Binary;

public class GreaterOperatorNode : BinaryBooleanOperator
{
    public GreaterOperatorNode(INode left, INode right) 
        : base(left, right) { }

    protected override bool Evaluate(int left, int right) => 
        left > right;
}