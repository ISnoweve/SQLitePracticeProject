using SQLite4Unity3d;

public class CharacterInformation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Username { get; set; }
    public int Lv { get; set; }
    public int Exp { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
}
