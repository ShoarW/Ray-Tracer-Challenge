﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
	public class Color : IEquatable<Color>
	{
		private const float Epsilon = 0.00001f;

		public float Red { get; set; }
		public float Green { get; set; }
		public float Blue { get; set; }

		public Color()
		{
			Red = 0.0f;
			Green = 0.0f;
			Blue = 0.0f;
		}

		public Color(float red, float green, float blue)
		{
			Red = red;
			Green = green;
			Blue = blue;
		}

		public static Color operator *(Color color, float scalar)
		{
			return new Color(
				color.Red * scalar,
				color.Green * scalar,
				color.Blue * scalar
				);
		}

		public static Color operator *(Color left, Color right)
		{
			return new Color(
				left.Red * right.Red,
				left.Green * right.Green,
				left.Blue * right.Blue
			);
		}

		public static Color operator +(Color left, Color right)
		{
			return new Color(
				left.Red + right.Red,
				left.Green + right.Green,
				left.Blue + right.Blue
			);
		}

		public static Color operator -(Color left, Color right)
		{
			return new Color(
				left.Red - right.Red,
				left.Green - right.Green,
				left.Blue - right.Blue
			);
		}

		public static bool operator ==(Color left, Color right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Color left, Color right)
		{
			return !(left == right);
		}


		public bool Equals(Color other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return (Math.Abs(Red - other.Red) < Epsilon) &&
			       (Math.Abs(Green - other.Green) < Epsilon) &&
			       (Math.Abs(Blue - other.Blue) < Epsilon);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Color) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Red.GetHashCode();
				hashCode = (hashCode * 397) ^ Green.GetHashCode();
				hashCode = (hashCode * 397) ^ Blue.GetHashCode();
				return hashCode;
			}
		}
	}
}
