namespace KaprekarNumber.Models;

public class KaprekarNum
{
    public int Number { get; set; }
    public int Square { get; set; }
    public int SplitFirst { get; set; }
    public int SplitSecond { get; set; }
    public bool IsKaprekarNumber { get; set; }
    public string? Message { get; set; }
    public string? ErrorMessage { get; set; }
}