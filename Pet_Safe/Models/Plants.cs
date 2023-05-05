public class Plants
{

    public int Id { get; set; }
    private static int nextId = 1;
    public string? Name { get; set; }
    public string? Type { get; set; }
    public bool? Toxic { get; set; }

    public Plants(string name)
    {
        Name = name;
    }
}