using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public static class ColorUtilities 
    {
        public static Color HexToRGB(string hex,float alpha=1f)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);
            if (hex.Length != 6)
                throw new System.Exception("Hex color must be 6 characters in length.");
            
            var r = hex.Substring(0, 2);
            var g = hex.Substring(2, 2);
            var b = hex.Substring(4, 2);
            return new Color(
                (float)System.Convert.ToInt32(r, 16) / 255f,
                (float)System.Convert.ToInt32(g, 16) / 255f,
                (float)System.Convert.ToInt32(b, 16) / 255f,
                alpha
            );
        }
    }
}

