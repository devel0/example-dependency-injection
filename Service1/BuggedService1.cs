namespace example_di;

public class BuggedService1 : IService1
{

    public double Sum(double a, double b) => a + 2 * b;

}