
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtension
{
    public static readonly Color White255 = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    public static readonly Color White80 = new Color(255f / 255f, 255f / 255f, 255f / 255f, 80f / 255f);

    public static readonly List<Color> GradeColor = new List<Color>()
    {
        new Color(255f/255f,255f/255f,255f/255f,255f/255f),
        new Color(173f/255f,255f/255f,47f/255f,255f/255f),
        new Color(30f/255f,144f/255f,255f/255f,255f/255f),
        new Color(102f/255f,51f/255f,153f/255f,255f/255f),
        new Color(255f/255f,0f/255f,0f/255f,255f/255f)
    };
}
