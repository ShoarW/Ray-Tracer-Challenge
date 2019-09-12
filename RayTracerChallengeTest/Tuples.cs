using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuple = RayTracerChallenge.Types.Tuple;


namespace RayTracerChallengeTest
{
	[TestClass]
	public class Tuples
	{
		[TestMethod]
		public void Tuple_Is_Point()
		{
			// Arrange
			var tuple = Tuple.Point(4.3f, -4.2f, 3.1f);
			// Act

			// Assert
			Assert.IsFalse(tuple.IsVector);
			Assert.IsTrue(tuple.IsPoint);
		}

		[TestMethod]
		public void Tuple_Is_Vector()
		{
			// Arrange
			var tuple = Tuple.Vector(4.3f, -4.2f, 3.1f);
			// Act

			// Assert
			Assert.IsTrue(tuple.IsVector);
			Assert.IsFalse(tuple.IsPoint);
		}

		[TestMethod]
		public void Point_Has_W1()
		{
			// Arrange
			var point = Tuple.Point(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreEqual(1.0f, point.W);
		}

		[TestMethod]
		public void Vector_Has_W0()
		{
			// Arrange
			var vector = Tuple.Vector(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreEqual(0.0f, vector.W);
		}

		[TestMethod]
		public void Two_Vectors_Are_Equal()
		{
			// Arrange
			var vectorOne = Tuple.Vector(4.0f, -4.0f, 3.0f);
			var vectorTwo = Tuple.Vector(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreEqual(vectorOne,vectorTwo);
		}

		[TestMethod]
		public void Two_Points_Are_Equal()
		{
			// Arrange
			var pointOne = Tuple.Point(4.0f, -4.0f, 3.0f);
			var pointTwo = Tuple.Point(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreEqual(pointOne, pointTwo);
		}

		[TestMethod]
		public void Two_Points_Are_Not_Equal()
		{
			// Arrange
			var pointOne = Tuple.Point(3.0f, 1.0f, 16.0f);
			var pointTwo = Tuple.Point(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreNotEqual(pointOne, pointTwo);
		}

		[TestMethod]
		public void Two_Vectors_Are_Not_Equal()
		{
			// Arrange
			var vectorOne = Tuple.Vector(3.0f, -1.0f, 16.0f);
			var vectorTwo = Tuple.Vector(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreNotEqual(vectorOne, vectorTwo);
		}


		[TestMethod]
		public void Point_And_Vector_Are_Not_Equal_Given_Same_Values()
		{
			// Arrange
			var vector = Tuple.Vector(4.0f, -4.0f, 3.0f);
			var point = Tuple.Point(4.0f, -4.0f, 3.0f);
			// Act

			// Assert
			Assert.AreNotEqual(vector, point);
		}

		[TestMethod]
		public void Add_Two_Tuples()
		{
			// Arrange
			var vector = Tuple.Vector(3.0f, -2.0f, 5.0f);
			var point = Tuple.Point(-2.0f, 3.0f, 1.0f);
			var expectedTuple = new Tuple(1.0f, 1.0f, 6.0f, 1.0f);
			// Act
			var newTuple = vector + point;
			// Assert
			Assert.AreEqual(expectedTuple, newTuple);
		}

		[TestMethod]
		public void Subtract_Two_Points_Gives_Vector()
		{
			// Arrange
			var pointOne = Tuple.Point(3.0f, 2.0f, 1.0f);
			var pointTwo = Tuple.Point(5.0f, 6.0f, 7.0f);

			var expectedVector = Tuple.Vector(-2.0f, -4.0f, -6.0f);
			// Act
			var vector = pointOne - pointTwo;
			// Assert
			Assert.AreEqual(expectedVector, vector);
			Assert.IsTrue(vector.IsVector);
		}

		[TestMethod]
		public void Subtract_Vector_From_Point_Gives_Point()
		{
			// Arrange
			var point = Tuple.Point(3.0f, 2.0f, 1.0f);
			var vector = Tuple.Vector(5.0f, 6.0f, 7.0f);

			var expectedPoint = Tuple.Point(-2.0f, -4.0f, -6.0f);
			// Act
			var calculatedPoint = point - vector;
			// Assert
			Assert.AreEqual(expectedPoint, calculatedPoint);
			Assert.IsTrue(calculatedPoint.IsPoint);
		}

		[TestMethod]
		public void Subtract_Two_Vector_Gives_Vector()
		{
			// Arrange
			var vectorOne = Tuple.Vector(3.0f, 2.0f, 1.0f);
			var vectorTwo = Tuple.Vector(5.0f, 6.0f, 7.0f);

			var expectedVector = Tuple.Vector(-2.0f, -4.0f, -6.0f);
			// Act
			var vector = vectorOne - vectorTwo;
			// Assert
			Assert.AreEqual(expectedVector, vector);
			Assert.IsTrue(vector.IsVector);
		}

		[TestMethod]
		public void Subtract_Vector_From_Zero_Negates_Vector()
		{
			// Arrange
			var zero = Tuple.Zero();
			var vector = Tuple.Vector(1.0f, -2.0f, 3.0f);

			var expectedVector = Tuple.Vector(-1.0f, 2.0f, -3.0f);
			// Act
			var calculatedVector = zero - vector;
			// Assert
			Assert.AreEqual(expectedVector, calculatedVector);
			Assert.IsTrue(calculatedVector.IsVector);
		}

		[TestMethod]
		public void Negate_Tuple()
		{
			// Arrange
			var tuple = new Tuple(1.0f, -2.0f, 3.0f, 4.0f);

			var expectedTuple = new Tuple(-1.0f, 2.0f, -3.0f, -4.0f);
			// Act
			// Assert
			Assert.AreEqual(expectedTuple, !tuple);
		}

		[TestMethod]
		public void Multiply_Tuple_By_Scalar()
		{
			var tuple = new Tuple(1f, -2f, 3f, -4f);
			var expectedTuple = new Tuple(3.5f, -7f, 10.5f, -14.0f);

			var calculatedTuple = tuple * 3.5f;

			Assert.AreEqual(expectedTuple, calculatedTuple);
		}

		[TestMethod]
		public void Multiply_Tuple_By_Scalar_Fraction()
		{
			var tuple = new Tuple(1f, -2f, 3f, -4f);
			var expectedTuple = new Tuple(0.5f, -1f, 1.5f, -2.0f);

			var calculatedTuple = tuple * 0.5f;

			Assert.AreEqual(expectedTuple, calculatedTuple);
		}

		[TestMethod]
		public void Divide_Tuple_By_Scalar()
		{
			var tuple = new Tuple(1f, -2f, 3f, -4f);
			var expectedTuple = new Tuple(0.5f, -1f, 1.5f, -2.0f);

			var calculatedTuple = tuple / 2.0f;

			Assert.AreEqual(expectedTuple, calculatedTuple);
		}

		[TestMethod]
		public void Magnitude_X_Gives_One()
		{
			var vector = Tuple.Vector(1.0f, 0.0f, 0.0f);
			Assert.AreEqual(1.0f, vector.Magnitude());
		}

		[TestMethod]
		public void Magnitude_Y_Gives_One()
		{
			var vector = Tuple.Vector(0.0f, 1.0f, 0.0f);
			Assert.AreEqual(1.0f, vector.Magnitude());
		}

		[TestMethod]
		public void Magnitude_Z_Gives_One()
		{
			var vector = Tuple.Vector(0.0f, 0.0f, 1.0f);
			Assert.AreEqual(1.0f, vector.Magnitude());
		}

		[TestMethod]
		public void Magnitude_Positive_XYZ_Gives_Square_14()
		{
			var vector = Tuple.Vector(1.0f, 2.0f, 3.0f);
			Assert.AreEqual((float)Math.Sqrt(14), vector.Magnitude());
		}

		[TestMethod]
		public void Magnitude_Negative_XYZ_Gives_Square_14()
		{
			var vector = Tuple.Vector(-1.0f, -2.0f, -3.0f);
			Assert.AreEqual((float)Math.Sqrt(14), vector.Magnitude());
		}

		[TestMethod]
		public void Normalize_Vector_4_0_0_Gives_1_0_0()
		{
			var vector = Tuple.Vector(4.0f, 0.0f, 0.0f);

			var expectedVectorUnit = Tuple.Vector(1.0f, 0.0f, 0.0f);

			Assert.AreEqual(expectedVectorUnit, vector.Normalize());
		}

		[TestMethod]
		public void Normalize_Vector_1_2_3()
		{
			var vector = Tuple.Vector(1.0f, 2.0f, 3.0f);
			// ​												0.26726						 0.53452					 0.80178
			var expectedVectorUnit = Tuple.Vector((float)(1/Math.Sqrt(14)), (float)(2 / Math.Sqrt(14)), (float)(3 / Math.Sqrt(14)));

			Assert.AreEqual(expectedVectorUnit, vector.Normalize());
		}

		[TestMethod]
		public void Mangnitude_Normalized()
		{
			var vector = Tuple.Vector(1.0f, 2.0f, 3.0f);
			var normalizedVector = vector.Normalize();
			Assert.IsTrue(normalizedVector.IsUnitVector);
		}

		[TestMethod]
		public void Dot_Vectors()
		{
			var vectorOne = Tuple.Vector(1.0f, 2.0f, 3.0f);
			var vectorTwo = Tuple.Vector(2.0f, 3.0f, 4.0f);

			Assert.AreEqual(20.0f, Tuple.Dot(vectorOne, vectorTwo));
		}

		[TestMethod]
		public void Cross_Vectors()
		{
			var vectorOne = Tuple.Vector(1.0f, 2.0f, 3.0f);
			var vectorTwo = Tuple.Vector(2.0f, 3.0f, 4.0f);

			var expectedVectorOne = Tuple.Vector(-1.0f, 2.0f, -1.0f);
			var crossedVectorOne = Tuple.Cross(vectorOne, vectorTwo);
			var expectedVectorTwo = Tuple.Vector(1.0f, -2.0f, 1.0f);
			var crossedVectorTwo = Tuple.Cross(vectorTwo, vectorOne);

			Assert.AreEqual(expectedVectorOne, crossedVectorOne);
			Assert.AreEqual(expectedVectorTwo, crossedVectorTwo);
		}
	}
}
