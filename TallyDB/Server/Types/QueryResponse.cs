﻿using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using TallyDB.Core;

namespace TallyDB.Server.Types
{
  public class QueryResponse
  {
    [JsonProperty("requestId")]
    public string RequestId { get; set; }
    [JsonProperty("sliceName")]
    public string? SliceName { get; set; }
    [JsonProperty("Slices")]
    public string[]? Slices { get; set; }
    [JsonProperty("databases")]
    public string[]? Databases { get; set; }
    [JsonProperty("records")]
    public SliceRecord[]? Records { get; set; }
    [JsonProperty("errors")]
    public DatabaseError[]? Errors { get; set; }

    public QueryResponse(string requestId)
    {
      RequestId = requestId;
    }
  }
}
