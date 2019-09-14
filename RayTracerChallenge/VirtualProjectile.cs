namespace RayTracerChallenge
{
	public class Projectile
	{
		// Point
		public Tuple Position { get; }
		// Vector
		public Tuple Velocity { get; }

		public Projectile(Tuple position, Tuple velocity)
		{
			Position = Tuple.Point(position.X, position.Y, position.Z);
			Velocity = Tuple.Vector(velocity.X, velocity.Y, velocity.Z);
		}
	}

	public class Environment
	{
		// Vector
		public Tuple Gravity { get; }
		// Vector
		public Tuple Wind { get; }

		public Environment(Tuple gravity, Tuple wind)
		{
			Gravity = Tuple.Vector(gravity.X, gravity.Y, gravity.Z);
			Wind = Tuple.Vector(wind.X, wind.Y, wind.Z);
		}
	}

}
