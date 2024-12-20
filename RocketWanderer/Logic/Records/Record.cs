﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logic.Records
{
  /// <summary>
  /// Запись рекордов игрока
  /// </summary>
  public class Record
  {
    /// <summary>
    /// Имя игрока
    /// </summary>
    private string _name;

    /// <summary>
    /// Очки
    /// </summary>
    private long _score;

    /// <summary>
    /// Имя игрока
    /// </summary>
    [JsonPropertyName("Name")]
    public string Name 
    { 
      get { return _name; } 
      set { _name = value; }
    }

    /// <summary>
    /// Очки
    /// </summary>
    [JsonPropertyName("Score")]
    public long Score
    { 
      get { return _score; }
      set { _score = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    [JsonConstructor]
    public Record()
    {
    }

  }
}
