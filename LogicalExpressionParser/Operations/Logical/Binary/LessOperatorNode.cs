namespace LogicalExpressionParser.Operations.Logical.Binary;

public class LessOperatorNode : BinaryBooleanOperator
{
    public LessOperatorNode(INode left, INode right) 
        : base(left, right) { }

    protected override bool Evaluate(int left, int right) => 
        left < right;
}