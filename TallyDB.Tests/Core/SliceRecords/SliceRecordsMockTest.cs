﻿
using TallyDB.Mock.Slice;

namespace TallyDB.Tests.Core.SliceRecords
{
  [TestClass]
  public class SliceRecordsMockTest
  {
    string sliceName = "mock1";
    string filename = Storage.Join("mock/mock1.tally");

    [TestInitialize]
    public void Prepare()
    {
      // Prepare the mock files
      if (File.Exists(filename))
      {
        File.Delete(filename);
      }
    }

    [TestCleanup]
    public void Cleanup()
    {
      Directory.Delete(Storage.Join("mock"), true);
    }

    [TestMethod("Should create slice")]
    public void ShouldCreateSlice()
    {
      // Create new mocked slice
      var mocker = new MockSliceCreator(25);
      SliceDefinition def;
      SliceRecord[] records;
      mocker.Create(sliceName, out def, out records);

      // Load slice
      var storage = new SliceStorage(filename);
      var outputDef = storage.LoadSliceDefinition();

      // Assert equality
      Assert.AreEqual(def, outputDef);

      Assert.AreEqual(storage.First(), records.First());
      Assert.AreEqual(storage.Last(), records.Last());

      storage.Dispose();
    }

    [TestMethod("Should query ranges in slice")]
    public void ShouldQueryRangesInSlice()
    {
      var mocker = new MockSliceCreator(26);
      SliceDefinition def;
      SliceRecord[] records;
      mocker.Create(sliceName, out def, out records);

      var storage = new SliceStorage(filename);
      storage.LoadSliceDefinition();

      Console.WriteLine("Def frequency: {0} hours", def.Frequency);

      var first = records.First().Time;
      var last = records.Last().Time;

      CollectionAssert.AreEqual(storage[first, last], records);

      storage.Dispose();
    }

    [TestMethod("Should have correct first and last record times")]
    public void ShouldHaveCorrectFirstLastTimes()
    {
      var mocker = new MockSliceCreator(28);
      SliceDefinition def;
      SliceRecord[] records;
      mocker.Create(sliceName, out def, out records);

      var storage = new SliceStorage(filename);
      storage.LoadSliceDefinition();

      var first = records.First().Time;
      var last = records.Last().Time;

      Assert.AreEqual(first, storage.First()?.Time);
      Assert.AreEqual(last, storage.Last()?.Time);

      storage.Dispose();
    }

    [TestMethod("Should have large datasets (10 thousand records)")]
    public void ShouldHandleLargeDatasets()
    {
      var mocker = new MockSliceCreator(28);
      SliceDefinition def;
      SliceRecord[] records;
      mocker.Create(sliceName, out def, out records, 10000);

      var storage = new SliceStorage(filename);
      storage.LoadSliceDefinition();

      var first = records.First().Time;
      var last = records.Last().Time;

      Assert.AreEqual(first, storage.First()?.Time);
      Assert.AreEqual(last, storage.Last()?.Time);

      storage.Dispose();
    }

    [TestMethod("Should have very large datasets (100 thousand records)")]
    public void ShouldHandleVeryLargeDatasets()
    {
      var mocker = new MockSliceCreator(28);
      SliceDefinition def;
      SliceRecord[] records;
      mocker.Create(sliceName, out def, out records, 100000);

      var storage = new SliceStorage(filename);
      storage.LoadSliceDefinition();

      var first = records.First().Time;
      var last = records.Last().Time;

      Assert.AreEqual(first, storage.First()?.Time);
      Assert.AreEqual(last, storage.Last()?.Time);

      storage.Dispose();
    }

    [TestMethod("Should have ultra large datasets (1 million records)")]
    public void ShouldHandleUltraLargeDatasets()
    {
      var mocker = new MockSliceCreator(28);
      SliceDefinition def;
      SliceRecord[] records;
      mocker.Create(sliceName, out def, out records, 1000000);

      var storage = new SliceStorage(filename);
      storage.LoadSliceDefinition();

      var first = records.First().Time;
      var last = records.Last().Time;

      Assert.AreEqual(first, storage.First()?.Time);
      Assert.AreEqual(last, storage.Last()?.Time);

      storage.Dispose();
    }
  }
}
