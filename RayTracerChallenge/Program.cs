using System;
using Tuple = RayTracerChallenge.Types.Tuple;

namespace RayTracerChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var ticks = 0;

			var projectile = new Projectile(Tuple.Point(0.0f, 1.0f, 0.0f), Tuple.Vector(1.0f, 1.0f, 0.0f).Normalize());
			var environment = new Environment(Tuple.Vector(0.0f, -0.1f, 0.0f), Tuple.Vector(-0.01f, 0.0f, 0.0f));

			while (projectile.Position.Y >= 0.0f)
			{
				projectile = Tick(environment, projectile);
				Console.WriteLine($"Tick: {ticks} X: {projectile.Position.X}, Y: {projectile.Position.Y}, Z: {projectile.Position.Z}");
				ticks++;
			}

			Console.WriteLine(ticks);

		}

		public static Projectile Tick(Environment environment, Projectile projectile)
		{
			var position = projectile.Position + projectile.Velocity;
			var velocity = projectile.Velocity + environment.Gravity + environment.Wind;

			return new Projectile(position, velocity);
		}

	}
}
