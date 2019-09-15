using System;
using System.IO;
using Tuple = RayTracerChallenge.Tuple;

namespace RayTracerChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var canvas = new Canvas(900, 550);

			var ticks = 0;

			var projectile = new Projectile(Tuple.Point(0.0f, 1.0f, 0.0f), Tuple.Vector(1.0f, 1.8f, 0.0f).Normalize() * 11.25f);
			var environment = new Environment(Tuple.Vector(0.0f, -0.1f, 0.0f), Tuple.Vector(-0.01f, 0.0f, 0.0f));

			Console.WriteLine("Tick,X,Y");
			while (projectile.Position.Y >= 0.0f)
			{
				canvas.WritePixel((int) projectile.Position.X, 500 - (int) projectile.Position.Y, new Color(1.0f, 0.0f, 0.0f));
				Console.WriteLine($"{ticks},{projectile.Position.X},{projectile.Position.Y}");
				projectile = Tick(environment, projectile);
				ticks++;
			}

			Console.WriteLine($"{ticks},{projectile.Position.X},{projectile.Position.Y}");
			Console.WriteLine(ticks);

			var exporter = new PPMExporter();

			

			File.WriteAllText("projectile.ppm", exporter.Export(canvas));

		}

		private static Projectile Tick(Environment environment, Projectile projectile)
		{
			var position = projectile.Position + projectile.Velocity;
			var velocity = projectile.Velocity + environment.Gravity + environment.Wind;

			return new Projectile(position, velocity);
		}

	}
}
