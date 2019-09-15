using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
	public class PPMExporter
	{
		private StringBuilder builder;
		public PPMExporter()
		{
			builder = new StringBuilder();
		}

		public string Export(Canvas canvas)
		{
			CreateHeader(canvas);
			WriteCanvas(canvas);

			return builder.ToString();
		}

		private void CreateHeader(Canvas canvas)
		{
			builder.Append("P3");
			builder.AppendLine();
			builder.AppendFormat("{0} {1}", canvas.Width, canvas.Height);
			builder.AppendLine();
			builder.Append("255");
			builder.AppendLine();
		}

		private void WriteCanvas(Canvas canvas)
		{
			for (var y = 0; y < canvas.Height; y++)
			{
				var currentRowLength = 0;
				for (var x = 0; x < canvas.Width; x++)
				{
					var formattedPixel = WriteFormattedPixel(canvas.Pixels[x, y]);
					if (currentRowLength + formattedPixel.Length >= 70)
					{
						builder.AppendLine();
						currentRowLength = 0;
					}

					builder.Append(formattedPixel);
					currentRowLength += formattedPixel.Length;

					if (x == canvas.Width - 1) continue;

					builder.Append(" ");
					currentRowLength++;

				}

				builder.AppendLine();
			}
		}

		private string WriteFormattedPixel(Color color)
		{
			var red = (int)Math.Round(Math.Clamp(color.Red * 255, 0, 255));
			var green = (int)Math.Round(Math.Clamp(color.Green * 255, 0, 255));
			var blue = (int)Math.Round(Math.Clamp(color.Blue * 255, 0, 255));

			return $"{red} {green} {blue}";
			//builder.AppendFormat("{0} {1} {2}", red, green, blue);
		}
	}
}
