using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RayTracerChallenge
{
	public class Canvas
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Color[,] Pixels { get; set; }

		public Canvas(int width, int height)
		{
			Width = width;
			Height = height;

			Pixels = new Color[width, height];

			// Initialise Array
			for (var x = 0; x < width; x++)
				for (var y = 0; y < height; y++)
					Pixels[x, y] = new Color();

		}

		public bool WritePixel( int x, int y, Color color)
		{
			if (x > Width || x < 0 || y > Height || y < 0 || color == null)
				return false;

			Pixels[x, y] = color;

			return true;
		}

	}
}
