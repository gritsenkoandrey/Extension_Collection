using UnityEngine;

public static class Utils
{
    public static float Remap(float iMin, float iMax, float oMin, float oMax, float value)
    {
        return Mathf.Lerp(oMin, oMax, Mathf.InverseLerp(iMin, iMax, value));
    }

    public static float Random(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
        
    public static int Random(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
    
    public static Vector3 QuadraticBezierCurves(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return (1 - t) * (1 - t) * p0 + 2 * (1 - t) * t * p1 + t * t * p2;
    }

    public static Vector3 GeneratePoint(float radius)
    {
        float angle = UnityEngine.Random.Range(0f, 1f) * (2f * Mathf.PI) - Mathf.PI;
                    
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        return new Vector3(x, 0f, z);
    }
        
    public static Vector3 CalculatePosition(int id, int count, float radius)
    {
        float radians = id * Mathf.PI * 2f / count;
            
        Vector2 angToDir = new Vector2(Mathf.Cos(radians) * radius, Mathf.Sin(radians) * radius);
            
        return new Vector3(angToDir.y, 0, angToDir.x);
    }
}