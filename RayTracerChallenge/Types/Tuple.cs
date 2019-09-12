using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RayTracerChallenge.Types
{
	public class Tuple : IEquatable<Tuple>
	{
		private static float Epsilon = 0.00001f;
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
		
		/// <summary>
		/// W Indicates whenever a Tuple is a point or a vector
		/// If W is 1, then this tuple is a POINT
		/// If W is 0, then this tuple is a VECTOR
		/// </summary>
		public float W { get; private set; }

		public bool IsPoint => Math.Abs(W - 1.0f) < Epsilon;
		public bool IsVector => Math.Abs(W) < Epsilon;

		public bool IsUnitVector => Math.Abs(Magnitude() - 1.0f) < Epsilon;



		public Tuple(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public static Tuple Zero()
		{
			return new Tuple(0.0f, 0.0f, 0.0f, 0.0f);
		}
		public static Tuple Point(float x, float y, float z)
		{
			return new Tuple(x, y, z, 1.0f);
		}


		public static Tuple Vector(float x, float y, float z)
		{
			return new Tuple(x, y, z, 0.0f);
		}

		public static float Dot(Tuple left, Tuple right)
		{
			return (
				left.X * right.X +
				left.Y * right.Y +
				left.Z * right.Z +
				left.W * right.W);
		}

		
		public static Tuple Cross(Tuple left, Tuple right)
		{
			return Vector(
					left.Y * right.Z - left.Z * right.Y,
					left.Z * right.X - left.X * right.Z,
					left.X * right.Y - left.Y * right.X
				);
		}
		

		public static Tuple operator +(Tuple left, Tuple right)
		{
			return new Tuple(
				left.X + right.X,
				left.Y + right.Y,
				left.Z + right.Z,
				left.W + right.W); //Math.Clamp(left.W + right.W, 0.0f, 1.0f));
		}

		public static Tuple operator -(Tuple left, Tuple right)
		{
			return new Tuple(
				left.X - right.X,
				left.Y - right.Y,
				left.Z - right.Z,
				left.W - right.W); //Math.Clamp(left.W - right.W, 0.0f, 1.0f));
		}

		// TASK: Should we be doing this, does it make sense to?
		public static Tuple operator *(float scalar, Tuple tuple)
		{
			return tuple * scalar;
		}
		public static Tuple operator *(Tuple tuple, float scalar)
		{
			return new Tuple(
				tuple.X * scalar,
				tuple.Y * scalar,
				tuple.Z * scalar,
				tuple.W * scalar);
		}


		public static Tuple operator /(Tuple tuple, float scalar)
		{
			return new Tuple(
				tuple.X / scalar,
				tuple.Y / scalar,
				tuple.Z / scalar,
				tuple.W / scalar);
		}

		public static bool operator ==(Tuple left, Tuple right)
		{
			return (Math.Abs(left.X - right.X) < Epsilon) &&
			       (Math.Abs(left.Y - right.Y) < Epsilon) &&
			       (Math.Abs(left.Z - right.Z) < Epsilon) &&
			       (Math.Abs(left.W - right.W) < Epsilon);
		}

		public static Tuple operator !(Tuple tuple)
		{
			return Zero() - tuple;
		}
		public static bool operator !=(Tuple left, Tuple right)
		{
			return !(left == right);
		}

		public bool Equals(Tuple other)
		{
			return (Math.Abs(X - other.X) < Epsilon) &&
			       (Math.Abs(Y - other.Y) < Epsilon) &&
			       (Math.Abs(Z - other.Z) < Epsilon) &&
			       (Math.Abs(W - other.W) < Epsilon);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Tuple) obj);
		}

		public float Magnitude()//Tuple tuple)
		{
			return (float) Math.Sqrt(
				Math.Pow(X, 2) +
				Math.Pow(Y, 2) +
				Math.Pow(Z, 2) +
				Math.Pow(W, 2));
		}

		public Tuple Normalize()
		{
			var magnitude = Magnitude();

			return new Tuple(
				X / magnitude,
				Y / magnitude,
				Z / magnitude,
				W / magnitude);
		}

	}
}