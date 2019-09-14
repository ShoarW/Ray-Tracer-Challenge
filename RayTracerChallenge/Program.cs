using System;
using Tuple = RayTracerChallenge.Tuple;

namespace RayTracerChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var ticks = 0;

			var projectile = new Projectile(Tuple.Point(0.0f, 1.0f, 0.0f), Tuple.Vector(55.0f, 25.0f, 0.0f).Normalize());
			var environment = new Environment(Tuple.Vector(0.0f, -0.01f, 0.0f), Tuple.Vector(-0.01f, 0.0f, 0.0f));

			Console.WriteLine("Tick,X,Y");
			while (projectile.Position.Y >= 0.0f)
			{
				Console.WriteLine($"{ticks},{projectile.Position.X},{projectile.Position.Y}");
				projectile = Tick(environment, projectile);
				ticks++;
			}

			Console.WriteLine($"{ticks},{projectile.Position.X},{projectile.Position.Y}");
			Console.WriteLine(ticks);

		}

		private static Projectile Tick(Environment environment, Projectile projectile)
		{
			var position = projectile.Position + projectile.Velocity;
			var velocity = projectile.Velocity + environment.Gravity + environment.Wind;

			return new Projectile(position, velocity);
		}

	}
}
