using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

public class IndexModel : PageModel
{
    [BindProperty]
    public double A { get; set; }

    [BindProperty]
    public double B { get; set; }

    [BindProperty]
    public double H { get; set; }

    [BindProperty]
    public double Twist { get; set; }

    public double Volume { get; set; }

    public void OnPost()
    {
        Volume = CalculateVolume(A, B, H, Twist);
    }

    private double CalculateVolume(double a, double b, double h, double twist)
    {
        int slices = 1000;
        double dz = h / slices;
        double volume = 0;

        for (int i = 0; i < slices; i++)
        {
            double z = i * dz;

            // Twist angle at height z
            double theta = twist * (z / h);

            // For this simplified model, twisting does NOT change area
            // ellipse area = πab
            double area = Math.PI * a * b;

            volume += area * dz;
        }

        return volume;
    }
}