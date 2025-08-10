using JetBrains.Annotations;
using System;

public struct girdpostion:IEquatable<girdpostion>
{
    public int x;
    public int y;
    

    public girdpostion(int x,int y) {



        this.x = x;
        this.y = y;
  
    
    }

    public override bool Equals(object obj)
    {
        return obj is girdpostion girdpostion &&
               x == girdpostion.x &&
               y == girdpostion.y;
    }

    public bool Equals(girdpostion other)
    {
     return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public override string ToString() {



        return ($"{x},{y}");
    
    
    }

    public static girdpostion operator +(girdpostion a,girdpostion b) { 
    
    
    return new girdpostion (a.x+b.x,a.y+b.y);
    
    }
    public static girdpostion operator -(girdpostion a, girdpostion b)
    {


        return new girdpostion(a.x - b.x, a.y - b.y);

    }
    public static bool operator ==(girdpostion a, girdpostion b) { 
    
    return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(girdpostion a ,girdpostion b) { 
    
        return !(a.x == b.x)||!(a.y == b.y);
    }
}
