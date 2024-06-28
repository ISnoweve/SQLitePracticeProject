using SQLite4Unity3d;
using System;

[Serializable]
public class HealthInformation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
}
