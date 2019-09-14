using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerChallenge;

namespace RayTracerChallengeTest
{
	[TestClass]
	public class Colors
	{
		[TestMethod]
		public void Color_Ctor()
		{
			// Arrange
			var color = new Color(-0.5f, 0.4f, 1.7f);
			// Act

			// Assert
			Assert.IsTrue(-0.5f == color.Red);
			Assert.IsTrue(0.4f == color.Green);
			Assert.IsTrue(1.7f == color.Blue);
		}

		[TestMethod]
		public void Add_Two_Colors()
		{
			// Arrange
			var colorOne = new Color(0.9f, 0.6f, 0.75f);
			var colorTwo = new Color(0.7f, 0.1f, 0.25f);

			var expectedColor = new Color(1.6f, 0.7f, 1.0f);
			// Act
			var calculatedColor = colorOne + colorTwo;

			// Assert
			Assert.AreEqual(expectedColor, calculatedColor);
		}

		[TestMethod]
		public void Subtract_Two_Colors()
		{
			// Arrange
			var colorOne = new Color(0.9f, 0.6f, 0.75f);
			var colorTwo = new Color(0.7f, 0.1f, 0.25f);

			var expectedColor = new Color(0.2f, 0.5f, 0.5f);
			// Act
			var calculatedColor = colorOne - colorTwo;

			// Assert
			Assert.AreEqual(expectedColor, calculatedColor);
		}

		[TestMethod]
		public void Multiply_Two_Colors()
		{
			// Arrange
			var colorOne = new Color(1.0f, 0.2f, 0.4f);
			var colorTwo = new Color(0.9f, 1.0f, 0.1f);

			var expectedColor = new Color(0.9f, 0.2f, 0.04f);
			// Act
			var calculatedColor = colorOne * colorTwo;

			// Assert
			Assert.AreEqual(expectedColor, calculatedColor);
		}

		[TestMethod]
		public void Multiply_By_Scalar()
		{
			// Arrange
			var colorOne = new Color(0.2f, 0.3f, 0.4f);

			var expectedColor = new Color(0.4f, 0.6f, 0.8f);
			// Act
			var calculatedColor = colorOne * 2;

			// Assert
			Assert.AreEqual(expectedColor, calculatedColor);
		}
	}
}
