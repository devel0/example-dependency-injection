namespace example_di;

public class Service2 : IService2
{

    readonly IService1 svc1;

    public Service2(IService1 svc1) => this.svc1 = svc1;

    Random rnd = new Random();

    public void TestSum()
    {
        var a = rnd.NextDouble();
        var b = rnd.NextDouble();

        var sum1 = svc1.Sum(a, b);

        var sum2 = a + b;

        var info = sum1 == sum2 ? "matches" : "NOT matches";

        System.Console.WriteLine($"{a} + {b} = {sum2} ( {info} )");
    }

}