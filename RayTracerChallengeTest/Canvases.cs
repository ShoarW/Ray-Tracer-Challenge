using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerChallenge;

namespace RayTracerChallengeTest
{
	[TestClass]
	public class Canvases
	{
		[TestMethod]
		public void Create_Canvas_Is_Blank()
		{
			var canvas = new Canvas(10, 20);

			var expectedColor = new Color(0.0f, 0.0f, 0.0f);

			var isNotBlack = false;

			for (var x = 0; x < canvas.Width; x++)
				for (var y = 0; y < canvas.Height; y++)
					if (canvas.Pixels[x, y] != expectedColor)
						isNotBlack = true;

			Assert.AreEqual(canvas.Width, 10);
			Assert.AreEqual(canvas.Height, 20);
			Assert.IsFalse(isNotBlack);
		}

		[TestMethod]
		public void Can_Write_Pixel()
		{
			var canvas = new Canvas(10, 20);

			var expectedColor = new Color(1.0f, 0.0f, 0.0f);

			canvas.WritePixel(2, 3, new Color(1.0f, 0.0f, 0.0f));

			Assert.AreEqual(canvas.Pixels[2, 3], expectedColor);
		}
	}
}
