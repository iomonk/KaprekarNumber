using Microsoft.AspNetCore.Mvc;
using KaprekarNumber.Models;

namespace KaprekarNumber.Controllers;

[ApiController]
[Route("[controller]")]
public class KaprekarNumberController : ControllerBase
{
    private const string SingleDigitSquareMsg = "Numbers that square to a single digit do not qualify as Kaprekar Numbers.";
    private const string IsValidMsg = "is a valid Kaprekar Number.";
    private const string IsNotValidMsg = "is NOT a valid Kaprekar Number.";

    [HttpPost(Name = "IsKaprekarNumber")]
    public KaprekarNum ReturnResult(int userInput)
    {
        var kn = new KaprekarNum
        {
            Number = userInput,
            Square = userInput * userInput
        };

        try
        {
            kn.SplitFirst = int.Parse((userInput * userInput).ToString()
                .Substring(0, (userInput * userInput).ToString().Length / 2));
            kn.SplitSecond = int.Parse((userInput * userInput).ToString()
                .Substring((userInput * userInput).ToString().Length / 2));
        }
        catch (Exception e)
        {
            kn.ErrorMessage = $"{e.Message} {SingleDigitSquareMsg}";
        }

        if (kn.SplitFirst + kn.SplitSecond != kn.Number)
        {
            kn.IsKaprekarNumber = false;
            kn.Message = $"{userInput} {IsNotValidMsg}";
            return kn;
        }

        kn.IsKaprekarNumber = true;
        kn.Message = $"{userInput} {IsValidMsg}";
        return kn;
    }
}