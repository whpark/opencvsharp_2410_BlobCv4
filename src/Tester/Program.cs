﻿using static System.Reflection.Metadata.BlobBuilder;
using OpenCvSharp;
using OpenCvSharp.BlobCv4;
using System.Drawing;

using CvPoint = OpenCvSharp.Point;
using CvSize = OpenCvSharp.Size;

namespace Tester {

	public static class FilePath {
		public static class Image {
			public const string Lenna = "Data/Image/lenna.png";
			public const string Lenna511 = "Data/Image/lenna511.png";
			public const string Goryokaku = "Data/Image/goryokaku.jpg";
			public const string Maltese = "Data/Image/maltese.jpg";
			public const string Cake = "Data/Image/cake.bmp";
			public const string Fruits = "Data/Image/fruits.jpg";
			public const string Penguin1 = "Data/Image/penguin1.png";
			public const string Penguin1b = "Data/Image/penguin1b.png";
			public const string Penguin2 = "Data/Image/penguin2.png";
			public const string Distortion = "Data/Image/Calibration/01.jpg";
			public const string Calibration = "Data/Image/Calibration/{0:D2}.jpg";
			public const string SurfBox = "Data/Image/box.png";
			public const string SurfBoxinscene = "Data/Image/box_in_scene.png";
			public const string TsukubaLeft = "Data/Image/tsukuba_left.png";
			public const string TsukubaRight = "Data/Image/tsukuba_right.png";
			public const string Square1 = "Data/Image/Squares/pic1.png";
			public const string Square2 = "Data/Image/Squares/pic2.png";
			public const string Square3 = "Data/Image/Squares/pic3.png";
			public const string Square4 = "Data/Image/Squares/pic4.png";
			public const string Square5 = "Data/Image/Squares/pic5.png";
			public const string Square6 = "Data/Image/Squares/pic6.png";
			public const string Shapes = "../../../../../Sample/SampleBase/Data/Image/shapes.png";
			public const string Yalta = "Data/Image/yalta.jpg";
			public const string Depth16Bit = "Data/Image/16bit.png";
			public const string Hand = "Data/Image/hand_p.jpg";
			public const string Asahiyama = "Data/Image/asahiyama.jpg";
			public const string Balloon = "Data/Image/Balloon.png";
			public const string Newspaper = "Data/Image/very_old_newspaper.png";
			public const string Binarization = "Data/Image/binarization_sample.bmp";
			public const string Walkman = "Data/Image/walkman.jpg";
			public const string Cat = "Data/Image/cat.jpg";
			public const string Match1 = "Data/Image/match1.png";
			public const string Match2 = "Data/Image/match2.png";
		}

		public static class Text {
			public const string Camera = "Data/Text/camera.xml";
			public const string HaarCascade = "Data/Text/haarcascade_frontalface_default.xml";
			public const string HaarCascadeAlt = "Data/Text/haarcascade_frontalface_alt.xml";
			public const string LatentSvmCat = "Data/Text/cat.xml";
			public const string Mushroom = "Data/Text/agaricus-lepiota.data";
			public const string LetterRecog = "Data/Text/letter-recognition.data";
			public const string LbpCascade = "Data/Text/lbpcascade_frontalface.xml";
		}

		public static class Movie {
			public const string Hara = "Data/Movie/hara.flv";
			public const string Bach = "Data/Movie/bach.mp4";
		}
	}
}

static class Program {

	internal class Blob {
		public Blob() {
			using (var imgSrc = Cv2.ImRead(Tester.FilePath.Image.Shapes, ImreadModes.Color))
			using (var imgBinary = new Mat(imgSrc.Size(), MatType.CV_8UC1))
			using (var imgRender = new Mat(imgSrc.Size(), MatType.CV_8UC3))
			using (var imgContour = new Mat(imgSrc.Size(), MatType.CV_8UC3))
			using (var imgPolygon = new Mat(imgSrc.Size(), MatType.CV_8UC3)) {
				Cv2.CvtColor(imgSrc, imgBinary, ColorConversionCodes.BGR2GRAY);
				Cv2.Threshold(imgBinary, imgBinary, 100, 255, ThresholdTypes.Binary);

				CvBlobs blobs = new CvBlobs();
				blobs.Label(imgBinary);

				foreach (KeyValuePair<int, CvBlob> item in blobs) {
					CvBlob b = item.Value;
					Console.WriteLine("{0} | Centroid:{1} Area:{2}", item.Key, b.Centroid, b.Area);

					CvContourChainCode cc = b.Contour;
					cc.Render(imgContour);

					CvContourPolygon polygon = cc.ConvertToPolygon();
					foreach (CvPoint p in polygon) {
						imgPolygon.Circle(p, 1, CvColor.Red, -1);
					}

					/*
					CvPoint2D32f circleCenter;
					float circleRadius;
					GetEnclosingCircle(polygon, out circleCenter, out circleRadius);
					imgPolygon.Circle(circleCenter, (int) circleRadius, CvColor.Green, 2);
					*/
				}

				blobs.RenderBlobs(imgSrc, imgRender);

				Cv2.ImShow("render", imgRender);
				Cv2.ImShow("contour", imgContour);
				Cv2.ImShow("polygon vertices", imgPolygon);
				Cv2.WaitKey(0);
			}
		}

		private void GetEnclosingCircle(
			IEnumerable<CvPoint> points, out Point2f center, out float radius) {
			var pointsArray = points.ToArray();
			using (var pointsMat = new Mat(pointsArray.Length, 1, MatType.CV_32SC2, pointsArray)) {
				Cv2.MinEnclosingCircle(pointsMat, out center, out radius);
			}
		}
	}

	public static void Main(string[] args) {
		// Get Current Folder :
		string currentFolder = System.IO.Directory.GetCurrentDirectory();

		Blob b = new Blob();
		Console.WriteLine("Hello, World!");
	}
}
