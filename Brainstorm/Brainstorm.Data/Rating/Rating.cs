namespace Brainstorm.Entities.Rating;

public class Rating : BaseEntity
{
    public int Ones { get; set; }
    public int Twos { get; set; }
    public int Threes { get; set; }
    public int Fours { get; set; }
    public int Fives { get; set; }
    public double Avg { get; set; }
}