namespace BillConverter;

public class BillInfo
{
    public string locale { get; set; }
    public string description { get; set; }
    public BoundingPoly boundingPoly { get; set; }
}

public class BoundingPoly
{
    public List<Vertex> vertices { get; set; }
}

public class Vertex
{
    public int x { get; set; }
    public int y { get; set; }
}

// public class BoundingPoly
// {
//     public List<Vertex> vertices { get; set; }
// }
//
// public class Root
// {
//     public string locale { get; set; }
//     public string description { get; set; }
//     public BoundingPoly boundingPoly { get; set; }
// }
//
// public class Vertex
// {
//     public int x { get; set; }
//     public int y { get; set; }
// }