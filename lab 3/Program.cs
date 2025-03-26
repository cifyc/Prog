using System;
using System.Text.Json;
using System.IO;

class Polynomial
{
    private int degree;
    private double[] coefficients;
    public Polynomial(int degree, double[] coefficients)
    {
        this.degree = degree;
        this.coefficients = coefficients;
    }
    public double Evaluate(double x)
    {
        double result = 0;
        for (int i = 0; i <= degree; i++)
        {
            result += coefficients[i] * Math.Pow(x, i);
        }
        return result;
    }
    public Polynomial Add(Polynomial other)
    {
        int maxDegree = Math.Max(degree, other.degree);
        double[] resultCoefficients = new double[maxDegree + 1];
        for (int i = 0; i <= degree; i++)
        {
            resultCoefficients[i] += coefficients[i];
        }
        for (int i = 0; i <= other.degree; i++)
        {
            resultCoefficients[i] += other.coefficients[i];
        }
        return new Polynomial(maxDegree, resultCoefficients);
    }
    public Polynomial Subtract(Polynomial other)
    {
        int maxDegree = Math.Max(degree, other.degree);
        double[] resultCoefficients = new double[maxDegree + 1];
        for (int i = 0; i <= degree; i++)
        {
            resultCoefficients[i] += coefficients[i];
        }
        for (int i = 0; i <= other.degree; i++)
        {
            resultCoefficients[i] -= other.coefficients[i];
        }
        return new Polynomial(maxDegree, resultCoefficients);
    }
    public Polynomial Multiply(Polynomial other)
    {
        int resultDegree = degree + other.degree;
        double[] resultCoefficients = new double[resultDegree + 1];
        for (int i = 0; i <= degree; i++)
        {
            for (int j = 0; j <= other.degree; j++)
            {
                resultCoefficients[i + j] += coefficients[i] * other.coefficients[j];
            }
        }
        return new Polynomial(resultDegree, resultCoefficients);
    }
    public void Print()
    {
        Console.Write("Polynomial: ");
        for (int i = degree; i >= 0; i--)
        {
            Console.Write(coefficients[i] + "x^" + i + " ");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        Polynomial p1 = new Polynomial(3, new double[] { 1, 2, 3, 4 });
        Polynomial p2 = new Polynomial(2, new double[] { 5, 6, 7 });
        p1.Print();
        p2.Print();
        double x = 2;
        Console.WriteLine("p1({0}) = {1}", x, p1.Evaluate(x));
        Console.WriteLine("p2({0}) = {1}", x, p2.Evaluate(x));
        Polynomial p3 = p1.Add(p2);
        p3.Print();
        Polynomial p4 = p1.Subtract(p2);
        p4.Print();
        Polynomial p5 = p1.Multiply(p2);
        p5.Print();
    }
}















