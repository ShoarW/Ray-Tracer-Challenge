using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerChallenge;
using Environment = System.Environment;

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

		[TestMethod]
		public void Export_PPM_Correct()
		{
			var canvas = new Canvas(5, 3);
			var exporter = new PPMExporter();
			var exported = exporter.Export(canvas).Split(Environment.NewLine);

			Assert.IsTrue(exported.Length >= 3);
			Assert.AreEqual("P3", exported[0]);
			Assert.AreEqual("5 3", exported[1]);
			Assert.AreEqual("255", exported[2]);
		}

		[TestMethod]
		public void Export_PPM_Data()
		{
			var canvas = new Canvas(5, 3);
			canvas.WritePixel(0, 0, new Color(1.5f, 0.0f, 0.0f));
			canvas.WritePixel(2, 1, new Color(0.0f, 0.5f, 0.0f));
			canvas.WritePixel(4, 2, new Color(-0.5f, 0.0f, 1.0f));
			var exporter = new PPMExporter();
			var exported = exporter.Export(canvas).Split(Environment.NewLine);

			Assert.IsTrue(exported.Length >= 6);
			Assert.AreEqual("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", exported[3]);
			Assert.AreEqual("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", exported[4]);
			Assert.AreEqual("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", exported[5]);
		}

		[TestMethod]
		public void Export_PPM_Does_not_Exceed_70_Chars()
		{
			var canvas = new Canvas(10, 2);

			for (var x = 0; x < canvas.Width; x++)
				for (var y = 0; y < canvas.Height; y++)
					canvas.Pixels[x, y] = new Color(1.0f, 0.8f, 0.6f);

			//canvas.WritePixel(0, 0, new Color(1.5f, 0.0f, 0.0f));
			var exporter = new PPMExporter();
			var exported = exporter.Export(canvas).Split(Environment.NewLine);

			foreach (var line in exported)
			{
				Assert.IsTrue(line.Length < 70);
			}

			//Assert.IsTrue(exported.Length >= 6);
		}

		[TestMethod]
		public void Export_PPM_End_Has_Newline()
		{
			var canvas = new Canvas(5, 3);

			var exporter = new PPMExporter();
			var exported = exporter.Export(canvas).Split(Environment.NewLine);

			Assert.AreEqual("", exported[exported.Length - 1]);
		}
	}
}
