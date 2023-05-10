﻿namespace TallyDB.Core
{
  public class SliceRecordData
  {
    /// <summary>
    /// DataType of the slice record data
    /// </summary>
    public DataType Type { get; set; }

    /// <summary>
    /// String value of the underlying value
    /// </summary>
    public string StringValue { get; set; }

    /// <summary>
    /// Integer value that is used to store runner value, usually used in calculating running average
    /// </summary>
    public int RunnerValue { get; set; }

    public SliceRecordData(DataType type, string stringValue)
    {
      Type = type;
      StringValue = stringValue;
    }
  }
}
