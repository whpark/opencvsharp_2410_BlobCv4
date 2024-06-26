﻿//=========================================
// 2024-06-07 PWH.
//  ported to OpenCvSharp 4
//  original - https://github.com/shimat/opencvsharp_2410
//=========================================

using System;

//#pragma warning disable 1591

using CvPoint = OpenCvSharp.Point;
using CvSize = OpenCvSharp.Size;
using CvRect = OpenCvSharp.Rect;
using CvScalar = OpenCvSharp.Scalar;

namespace OpenCvSharp.BlobCv4
{
    /// <summary>
    /// Functions of cvblob library
    /// </summary>
    static public class CvBlobLib
    {
        #region Constants
        /// <summary>
        /// Size of a label in bits.
        /// </summary>
        public const int DepthLabel = (sizeof(UInt32) * 8);
        #endregion

        #region Public Methods
        #region Angle
        /// <summary>
        /// Calculates angle orientation of a blob.
        /// This function uses central moments so cvCentralMoments should have been called before for this blob. (cvAngle)
        /// </summary>
        /// <param name="blob">Blob.</param>
        /// <returns>Angle orientation in radians.</returns>
        public static double CalcAngle(CvBlob blob)
        {
            if (blob == null)
                throw new ArgumentNullException(nameof(blob));
            return blob.Angle();
        }
        #endregion
        #region Centroid
        /// <summary>
        /// Calculates centroid.
        /// Centroid will be returned and stored in the blob structure. (cvCentroid)
        /// </summary>
        /// <param name="blob">Blob whose centroid will be calculated.</param>
        /// <returns>Centroid.</returns>
        public static Point2d CalcCentroid(CvBlob blob)
        {
            if (blob == null)
                throw new ArgumentNullException(nameof(blob));
            return blob.CalcCentroid();
        }
        #endregion
        #region ContourPolygonArea
        /// <summary>
        /// Calculates area of a polygonal contour. 
        /// </summary>
        /// <param name="polygon">Contour (polygon type).</param>
        /// <returns>Area of the contour.</returns>
        public static double ContourPolygonArea(CvContourPolygon polygon)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            return polygon.Area();
        }
        #endregion
        #region ContourPolygonCircularity
        /// <summary>
        /// Calculates the circularity of a polygon (compactness measure).
        /// </summary>
        /// <param name="polygon">Contour (polygon type).</param>
        /// <returns>Circularity: a non-negative value, where 0 correspond with a circumference.</returns>
        public static double ContourPolygonCircularity(CvContourPolygon polygon)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            return polygon.Circularity();
        }
        #endregion
        #region ContourPolygonPerimeter
        /// <summary>
        /// Calculates perimeter of a chain code contour.
        /// </summary>
        /// <param name="polygon">Contour (polygon type).</param>
        /// <returns>Perimeter of the contour.</returns>
        public static double ContourPolygonPerimeter(CvContourPolygon polygon)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            return polygon.Perimeter();
        }
        #endregion
        #region ContourChainCodePerimeter
        /// <summary>
        /// Calculates perimeter of a chain code contour.
        /// </summary>
        /// <param name="cc">Contour (chain code type).</param>
        /// <returns>Perimeter of the contour.</returns>
        public static double ContourChainCodePerimeter(CvContourChainCode cc)
        {
            if (cc == null)
                throw new ArgumentNullException(nameof(cc));
            return cc.Perimeter();
        }
        #endregion
        #region ConvertChainCodesToPolygon
        /// <summary>
        /// Convert a chain code contour to a polygon.
        /// </summary>
        /// <param name="cc">Chain code contour.</param>
        /// <returns>A polygon.</returns>
        public static CvContourPolygon ConvertChainCodesToPolygon(CvContourChainCode cc)
        {
            if (cc == null)
                throw new ArgumentNullException(nameof(cc));
            return cc.ConvertToPolygon();
        }
        #endregion
        #region FilterByArea
        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public static void FilterByArea(CvBlobs blobs, int minArea, int maxArea)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            blobs.FilterByArea(minArea, maxArea);
        }
        #endregion
        #region FilterByLabel
        /// <summary>
        /// Filter blobs by label.
        /// Delete all blobs except those with label l.
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="label">Label to leave.</param>
        public static void FilterByLabel(CvBlobs blobs, int label)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            blobs.FilterByLabel(label);
        }
        #endregion
        #region FilterLabels
        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="blobs">List of blobs to be drawn.</param>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public static void FilterLabels(CvBlobs blobs, Mat imgOut)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            blobs.FilterLabels(imgOut);
        }
        #endregion
        #region GetLabel
        /// <summary>
        /// Get the label value from a labeled image.
        /// </summary>
        /// <param name="blobs">Blob data.</param>
        /// <param name="x">X coordenate.</param>
        /// <param name="y">Y coordenate.</param>
        /// <returns>Label value.</returns>
        public static int GetLabel(CvBlobs blobs, int x, int y)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            return blobs.GetLabel(x, y);
        }
        #endregion
        #region GreaterBlob
        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <returns>The greater blob.</returns>
        public static CvBlob GreaterBlob(CvBlobs blobs)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            return blobs.GreaterBlob();
        }

        /// <summary>
        /// Find the largest blob. (cvLargestBlob)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <returns>The largest blob.</returns>
        public static CvBlob LargestBlob(CvBlobs blobs)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            return blobs.LargestBlob();
        }
        #endregion
        #region Label
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <param name="blobs">List of blobs.</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public static int Label(Mat img, CvBlobs blobs)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));

            return blobs.Label(img);
        }
        #endregion
        #region BlobMeanColor
        /// <summary>
        /// Calculates mean color of a blob in an image.
        /// </summary>
        /// <param name="blobs">Blob list</param>
        /// <param name="targetBlob">The target blob</param>
        /// <param name="originalImage">Original image.</param>
        /// <returns>Average color.</returns>
        public static CvScalar BlobMeanColor(CvBlobs blobs, CvBlob targetBlob, Mat originalImage)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            return blobs.BlobMeanColor(targetBlob, originalImage);
        }
        #endregion
        #region PolygonContourConvexHull
        /// <summary>
        /// Calculates convex hull of a contour.
        /// Uses the Melkman Algorithm. Code based on the version in http://w3.impa.br/~rdcastan/Cgeometry/.
        /// </summary>
        /// <param name="polygon">Contour (polygon type).</param>
        /// <returns>Convex hull.</returns>
        public static CvContourPolygon PolygonContourConvexHull(CvContourPolygon polygon)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            return polygon.ContourConvexHull();
        }
        #endregion
        #region RenderBlob
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public static void RenderBlob(LabelData labels, CvBlob blob, Mat imgSource, Mat imgDest)
        {
            RenderBlob(labels, blob, imgSource, imgDest, (RenderBlobsMode)0x000f, CvColor.White, 1.0);
        }
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public static void RenderBlob(LabelData labels, CvBlob blob, Mat imgSource, Mat imgDest, RenderBlobsMode mode)
        {
            RenderBlob(labels, blob, imgSource, imgDest, mode, CvColor.White, 1.0);
        }
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="color">Color to render (if CV_BLOB_RENDER_COLOR is used).</param>
        public static void RenderBlob(LabelData labels, CvBlob blob, Mat imgSource, Mat imgDest, RenderBlobsMode mode, CvScalar color)
        {
            RenderBlob(labels, blob, imgSource, imgDest, mode, color, 1.0);
        }
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="color">Color to render (if CV_BLOB_RENDER_COLOR is used).</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public static void RenderBlob(LabelData labels, CvBlob blob, Mat imgSource, Mat imgDest, RenderBlobsMode mode, CvScalar color, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (blob == null)
                throw new ArgumentNullException(nameof(blob));
            if (imgSource == null)
                throw new ArgumentNullException(nameof(imgSource));
            if (imgDest == null)
                throw new ArgumentNullException(nameof(imgDest));

            BlobRenderer.PerformOne(labels, blob, imgSource, imgDest, mode, color, alpha);
        }
        #endregion
        #region RenderBlobs
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public static void RenderBlobs(CvBlobs blobs, Mat imgSource, Mat imgDest)
        {
            RenderBlobs(blobs, imgSource, imgDest, (RenderBlobsMode)0x000f, 1.0);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public static void RenderBlobs(CvBlobs blobs, Mat imgSource, Mat imgDest, RenderBlobsMode mode)
        {
            RenderBlobs(blobs, imgSource, imgDest, mode, 1.0);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public static void RenderBlobs(CvBlobs blobs, Mat imgSource, Mat imgDest, RenderBlobsMode mode, double alpha)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            if (imgSource == null)
                throw new ArgumentNullException(nameof(imgSource));
            if (imgDest == null)
                throw new ArgumentNullException(nameof(imgDest));

            BlobRenderer.PerformMany(blobs, imgSource, imgDest, mode, alpha);
        }
        #endregion
        #region RenderContourChainCode
        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="contour"> Chain code contour.</param>
        /// <param name="img">Image to draw on.</param>
        public static void RenderContourChainCode(CvContourChainCode contour, Mat img)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.Render(img);
        }
        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="contour"> Chain code contour.</param>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public static void RenderContourChainCode(CvContourChainCode contour, Mat img, CvScalar color)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.Render(img, color);
        }
        #endregion
        #region RenderContourPolygon
        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="contour">Polygon contour.</param>
        /// <param name="img">Image to draw on.</param>
        public static void RenderContourPolygon(CvContourPolygon contour, Mat img)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.Render(img);
        }
        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="contour">Polygon contour.</param>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public static void RenderContourPolygon(CvContourPolygon contour, Mat img, CvScalar color)
        {
            if (contour == null)
                throw new ArgumentNullException(nameof(contour));
            contour.Render(img, color);
        }
        #endregion
        #region RenderTracks
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public static void RenderTracks(CvTracks tracks, Mat imgSource, Mat imgDest)
        {
            if (tracks == null)
                throw new ArgumentNullException(nameof(tracks));
            tracks.Render(imgSource, imgDest);
        }
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        public static void RenderTracks(CvTracks tracks, Mat imgSource, Mat imgDest, RenderTracksMode mode)
        {
            if (tracks == null)
                throw new ArgumentNullException(nameof(tracks));
            tracks.Render(imgSource, imgDest, mode);
        }
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        /// <param name="font">OpenCV font for print on the image.</param>
        public static void RenderTracks(CvTracks tracks, Mat imgSource, Mat imgDest, RenderTracksMode mode, HersheyFonts hersheyFont, double fontScale/* CvFont font*/)
        {
            if (tracks == null)
                throw new ArgumentNullException(nameof(tracks));
            tracks.Render(imgSource, imgDest, mode, hersheyFont, fontScale);
        }
        #endregion
        #region SaveImageBlob
        /// <summary>
        /// Save the image of a blob to a file.
        /// The function uses an image (that can be the original pre-processed image or a processed one, or even the result of cvRenderBlobs, for example) and a blob structure.
        /// Then the function saves a copy of the part of the image where the blob is.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="img">Image.</param>
        /// <param name="blob">Blob.</param>
        public static void SaveImageBlob(string fileName, Mat img, CvBlob blob)
        {
            if(String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if(blob == null)
                throw new ArgumentNullException(nameof(blob));
            blob.SaveImage(fileName, img);
        }
        #endregion
        //#region SetImageRoItoBlob
        ///// <summary>
        ///// Set the ROI of an image to the bounding box of a blob.
        ///// </summary>
        ///// <param name="img">Image.</param>
        ///// <param name="blob">Blob.</param>
        //public static void SetImageRoItoBlob(IplImage img, CvBlob blob)
        //{
        //    if (blob == null)
        //        throw new ArgumentNullException(nameof(blob));
        //    blob.SetImageRoiToBlob(img);
        //}
        //#endregion
        #region SimplifyPolygon
        /// <summary>
        /// Simplify a polygon reducing the number of vertex according the distance "delta". 
        /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm). 
        /// </summary>
        /// <param name="polygon">Contour (polygon type).</param>
        /// <returns>A simplify version of the original polygon.</returns>
        public static CvContourPolygon SimplifyPolygon(CvContourPolygon polygon)
        {
            return polygon.Simplify();
        }
        /// <summary>
        /// Simplify a polygon reducing the number of vertex according the distance "delta". 
        /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm). 
        /// </summary>
        /// <param name="polygon">Contour (polygon type).</param>
        /// <param name="delta">Minimun distance.</param>
        /// <returns>A simplify version of the original polygon.</returns>
        public static CvContourPolygon SimplifyPolygon(CvContourPolygon polygon, double delta)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            return polygon.Simplify(delta);
        }
        #endregion
        #region UpdateTracks
        /// <summary>
        /// Updates list of tracks based on current blobs. 
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="thDistance">Max distance to determine when a track and a blob match.</param>
        /// <param name="thInactive">Max number of frames a track can be inactive.</param>
        public static void UpdateTracks(CvBlobs blobs, CvTracks tracks, double thDistance, int thInactive)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            blobs.UpdateTracks(tracks, thDistance, thInactive);
        }
        /// <summary>
        /// Updates list of tracks based on current blobs. 
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="thDistance">Max distance to determine when a track and a blob match.</param>
        /// <param name="thInactive">Max number of frames a track can be inactive.</param>
        /// <param name="thActive">If a track becomes inactive but it has been active less than thActive frames, the track will be deleted.</param>
        /// <remarks>
        /// Tracking based on:
        /// A. Senior, A. Hampapur, Y-L Tian, L. Brown, S. Pankanti, R. Bolle. Appearance Models for
        /// Occlusion Handling. Second International workshop on Performance Evaluation of Tracking and
        /// Surveillance Systems &amp; CVPR'01. December, 2001.
        /// (http://www.research.ibm.com/peoplevision/PETS2001.pdf)
        /// </remarks>
        public static void UpdateTracks(CvBlobs blobs, CvTracks tracks, double thDistance, int thInactive, int thActive)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            blobs.UpdateTracks(tracks, thDistance, thInactive, thActive);
        }
        #endregion
        #region WriteContourPolygonCsv
        /// <summary>
        /// Write a contour to a CSV (Comma-separated values) file.
        /// </summary>
        /// <param name="polygon">Polygon contour.</param>
        /// <param name="filename">File name.</param>
        public static void WriteContourPolygonCsv(CvContourPolygon polygon, string filename)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            polygon.WriteAsCsv(filename);
        }
        #endregion
        #region WriteContourPolygonSvg
        /// <summary>
        /// Write a contour to a SVG file.
        /// </summary>
        /// <param name="polygon">Polygon contour.</param>
        /// <param name="fileName">File name.</param>
        public static void WriteContourPolygonSvg(CvContourPolygon polygon, string fileName)
        {
            polygon.WriteAsSvg(fileName);
        }
        /// <summary>
        /// Write a contour to a SVG file.
        /// </summary>
        /// <param name="polygon">Polygon contour.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="stroke">Stroke color (black by default).</param>
        /// <param name="fill">Fill color (white by default).</param>
        public static void WriteContourPolygonSvg(CvContourPolygon polygon, string fileName, CvScalar stroke, CvScalar fill)
        {
            if (polygon == null)
                throw new ArgumentNullException(nameof(polygon));
            polygon.WriteAsSvg(fileName, stroke, fill);
        }
        #endregion
        #endregion
    }
}
