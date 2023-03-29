using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Unique type that represents entries for that day
/// </summary>
///
[System.Serializable]
public class Entry
{
    Dictionary<string, List<Task>> entryInfo = new Dictionary<string, List<Task>>();
}
