using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TempClass
{
    public int Id { get; init; }
    public string Name { get; init; }
}
public record Temp
{
    public int Id { get; init; }
    public string Name { get; init; }
}


public struct TempStruct
{
    public int Id { get; init; }
    public string Name { get; init; }
}
