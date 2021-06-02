using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	//string variable name
    public string name;
    [TextArea(3, 10)]
	//string array sentences
    public string[] sentences;
}
