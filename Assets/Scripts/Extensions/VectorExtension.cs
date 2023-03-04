﻿using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.Extensions
{
    public static class VectorExtension
    {
        public static Vector3 AddY(this Vector3 vector, float add)
        {
            return new Vector3(vector.x, vector.y + add, vector.z);
        }
        
        public static Vector3 AddX(this Vector3 vector, float add)
        {
            return new Vector3(vector.x + add, vector.y, vector.z);
        }
        
        public static Vector3 AddZ(this Vector3 vector, float add)
        {
            return new Vector3(vector.x, vector.y, vector.z + add);
        }

        public static Vector3 ZeroY(this Vector3 vector)
        {
            return new Vector3(vector.x, 0f, vector.z);
        }
    }
}