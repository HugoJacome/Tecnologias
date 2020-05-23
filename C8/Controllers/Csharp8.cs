using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C8.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class Csharp8Controller : ControllerBase
    {
        private readonly ILogger<Csharp8Controller> _logger;
        public Csharp8Controller(ILogger<Csharp8Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet("users")]
        public static async Task ExecuteAsyncStream()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine($"The square of number {number.Number} is: {number.Square}");
            }
        }
        public static async IAsyncEnumerable<SquareNumber> GenerateSequence()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(200);
                yield
                return new SquareNumber
                {
                    Number = i,
                    Square = i * i
                };
            }
        }
        public class SquareNumber
        {
            public int Number
            {
                get;
                set;
            }
            public int Square
            {
                get;
                set;
            }
        }

        public static void ExecutePositionalPattern()
        {
            Point point = new Point(5, 10);
            Console.WriteLine($"Quadrant of point {point.X} and {point.Y} is: {FindQuadrant(point)}");
        }

        private static Quadrant FindQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
        public class Point
        {
            public int X { get; }
            public int Y { get; }
            public Point(int x, int y) => (X, Y) = (x, y); public void Deconstruct(out int x, out int y)
            {
                (x, y) = (X, Y);
            }
        }
        public enum Quadrant
        {
            One,
            Two,
            Three,
            Four,
            Origin,
            OnBorder,
            Unknown
        }
    }
}
