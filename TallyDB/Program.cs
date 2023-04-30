﻿using TallyDB.Core;

namespace TallyDB
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var db = new Database("test");
      db.Create();

      var creator = new SliceCreator(db);
      var slice = creator.Create(new SliceDefinition(
        "response", new Axis[] { new Axis("time", DataType.FLOAT, AggregateFunction.AVG) }, 1 / 60
      ));
    }
  }
}