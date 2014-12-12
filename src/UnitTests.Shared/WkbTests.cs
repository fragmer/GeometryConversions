﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esri.ArcGISRuntime.Geometry;
using GeometryConversions.Wkb;
using System.Reflection;
#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace UnitTests
{
    [TestClass]
    public class WkbTests
    {
		[TestMethod]
		public void WkbConvertMapPointToFromXY()
		{
			MapPoint mp = new MapPoint(12, 34);
			byte[] bytes = mp.ToWellKnownBinary();
			var geom = bytes.FromWellKnownBinary();
			Assert.IsNotNull(geom);
			Assert.IsInstanceOfType(geom, typeof(MapPoint));
			var mp2 = (MapPoint)geom;
			Assert.AreEqual(12, mp2.X);
			Assert.AreEqual(34, mp2.Y);
			Assert.IsTrue(double.IsNaN(mp2.Z));
			Assert.IsTrue(double.IsNaN(mp2.M));
		}
		[TestMethod]
		public void WkbConvertMapPointToFromXYZ()
		{
			MapPoint mp = new MapPoint(12, 34, 56);
			byte[] bytes = mp.ToWellKnownBinary();
			var geom = bytes.FromWellKnownBinary();
			Assert.IsNotNull(geom);
			Assert.IsInstanceOfType(geom, typeof(MapPoint));
			var mp2 = (MapPoint)geom;
			Assert.AreEqual(12, mp2.X);
			Assert.AreEqual(34, mp2.Y);
			Assert.AreEqual(56, mp2.Z);
			Assert.IsTrue(double.IsNaN(mp2.M));
		}
		[TestMethod]
		public void WkbConvertMapPointToFromXYM()
		{
			MapPoint mp = new MapPoint(12, 34, double.NaN, 56);
			byte[] bytes = mp.ToWellKnownBinary();
			var geom = bytes.FromWellKnownBinary();
			Assert.IsNotNull(geom);
			Assert.IsInstanceOfType(geom, typeof(MapPoint));
			var mp2 = (MapPoint)geom;
			Assert.AreEqual(12, mp2.X);
			Assert.AreEqual(34, mp2.Y);
			Assert.IsTrue(double.IsNaN(mp2.Z));
			Assert.AreEqual(56, mp2.M);
		}

        [TestMethod]
		public void WkbConvertMapPointToFromXYZM()
        {
			MapPoint mp = new MapPoint(12, 34, 56, 78);
			byte[] bytes = mp.ToWellKnownBinary();
			var geom = bytes.FromWellKnownBinary();
			Assert.IsNotNull(geom);
			Assert.IsInstanceOfType(geom, typeof(MapPoint));
			var mp2 = (MapPoint)geom;
			Assert.AreEqual(12, mp2.X);
			Assert.AreEqual(34, mp2.Y);
			Assert.AreEqual(56, mp2.Z);
			Assert.AreEqual(78, mp2.M);
        }
    }
}