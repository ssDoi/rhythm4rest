using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public enum Type
    {
        longNote,
        defaultNote,
        obstacle
    }

    public Type type;

    public int line;

    public float time;
}

