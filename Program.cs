// See https://aka.ms/new-console-template for more information

float[][] data = [[23, 651], [26, 762], [30, 856], [34, 1063], [43, 1190], [48, 1298], [52, 1421], [57, 1440], [58, 1518]];

var model = SimpleLinearRegression.Train(data);

Console.WriteLine($"y = {model.b0} + {model.b1}x");

float[] incog = [33, 65, 12, 90, 78];

foreach (var adv in incog)
{
    Console.WriteLine($"Para {adv}:");
    Console.WriteLine($"Sales = {model.GetFor(adv)}");
}

public class SimpleLinearRegression
{
    public readonly float b0;
    public readonly float b1;
    
    private SimpleLinearRegression(float b0, float b1)
    {
        this.b0 = b0;
        this.b1 = b1;
    }
    
    public static SimpleLinearRegression Train(float[][] data)
    {
        float xSum = data.Select(d => d[0]).Sum();
        float ySum = data.Select(d => d[1]).Sum();
        float x2Sum = data.Select(d => d[0] * d[0]).Sum();
        float xySum = data.Select(d => d[0] * d[1]).Sum();
        return new SimpleLinearRegression((x2Sum * ySum - xSum * xySum) / (data.Length * x2Sum - xSum * xSum), (data.Length * xySum - xSum * ySum) / (data.Length * x2Sum - xSum * xSum));
    }

    public float GetFor(float x) => b0 + b1 * x;
}