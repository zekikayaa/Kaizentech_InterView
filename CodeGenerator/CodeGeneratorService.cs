namespace CodeGenerator;

public class CodeGeneratorService
{
    private string SelectRandomCharacters(string allowableCharacters)
    {
        var random = new Random();

        var randomCharacter = string.Empty;


        for (var i = 0; i < 8; i++)
        {
            var randomIndex = random.Next(0, 23);

            var randomChar = allowableCharacters[randomIndex];

            randomCharacter += randomChar;
        }

        return randomCharacter;
    }

    private string PrepareCode(List<char> orderedRandomCharacters)
    {
        var code = string.Empty;

        var loopCount = orderedRandomCharacters.Count;

        var digitCount = GetDigitCount(orderedRandomCharacters);


        for (var i = 0; i < loopCount / 2; i++)
        {
            var startMinValue = i % 2 == 0;

            var startMaxValue = i % 2 != 0;


            if (startMinValue)
            {
                if (digitCount > 2)
                {
                    var minValue = orderedRandomCharacters.Last();

                    code += minValue;

                    orderedRandomCharacters.Remove(minValue);

                    var maxValue = orderedRandomCharacters.First();

                    code += maxValue;

                    orderedRandomCharacters.Remove(maxValue);
                }
                else
                {
                    var maxValue = orderedRandomCharacters.First();

                    code += maxValue;

                    orderedRandomCharacters.Remove(maxValue);

                    var minValue = orderedRandomCharacters.Last();

                    code += minValue;

                    orderedRandomCharacters.Remove(minValue);
                }
            }

            if (startMaxValue)
            {
                var maxValue = orderedRandomCharacters.First();

                code += maxValue;

                orderedRandomCharacters.Remove(maxValue);

                var minValue = orderedRandomCharacters.Last();

                code += minValue;

                orderedRandomCharacters.Remove(minValue);
            }
        }

        return code;
    }

    public List<string> GenerateCode(int codeQuantity)
    {
        var allowableCharacters = "ACDEFGHKLMNPRTXYZ234579";


        var codeList = new List<string>();

        for (var i = 0; i < codeQuantity; i++)
        {
            var selectRandomCharacters = SelectRandomCharacters(allowableCharacters);

            var orderedRandomChars = selectRandomCharacters.OrderDescending().ToList();

            var code = PrepareCode(orderedRandomChars);

            var isUnique = !codeList.Contains(code);
            if (isUnique)
                codeList.Add(code);
            else
                i--;
        }


        return codeList;
    }

    public int GetDigitCount(List<char> orderedRandomCharacters)
    {
        var charCount = orderedRandomCharacters.Count(w => w >= 65);

        var digitCount = orderedRandomCharacters.Count - charCount;

        return digitCount;
    }

    public bool CheckCode(string code)
    {
        var allowableCharacters = "ACDEFGHKLMNPRTXYZ234579";

        var isSystemCode = false;

        if (code.Length != 8)
            return isSystemCode;


        foreach (var character in code)
        {
            var containInAllowChars = allowableCharacters.Contains(character);

            if (!containInAllowChars)
                return isSystemCode;
        }


        var digitCount = GetDigitCount(code.OrderDescending().ToList());

        if (digitCount > 2)
        {
            var firstCharacter = code[0];

            var isDigit = int.TryParse(firstCharacter.ToString(), out var digit);

            if (!isDigit)
                return isSystemCode;
        }

        var systemCode = PrepareCode(code.OrderDescending().ToList());

        if (systemCode == code)
            isSystemCode = true;

        return isSystemCode;
    }
}