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
    public string date;
    public List<Task> tasks = new List<Task>();

}
