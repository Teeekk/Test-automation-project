namespace AutomationProjectTest.TestsLayer.TestData;

public static class Credentials
{
    public const string Password = "secret_sauce";

    public static readonly string[] AcceptedUsernames = 
    {
        "standard_user",
        "locked_out_user",
        "problem_user",
        "performance_glitch_user",
        "error_user",
        "visual_user",
    };

    public static object[][] InvalidPasswords =
    {
        new object[] { "AnyPassword", "12345" },
        new object[] { "OneCharacterPassword", "a" },
        new object[] { "TwoCharactersPassword", "bc" },
        new object[] { "AboveMaxLengthPassword", "qwertyuiopasdfghjklzx" },
        new object[] { "TooLongPassword", "qwertyuiopasdfghjklzxcvbnm" },

        //Invalid characters set

        new object[] { "DigitsOnlyPassword", "12345678" },
        new object[] { "SymbolsOnlyPassword", "!@#$%" },
        new object[] { "LowercaseLettersOnlyPassword", "თეონა კაკაბაძე" },
        new object[] { "WithEmojiPassword", "user😀"},
        
        //white space
        
        new object[] { "LeadingSpacePassword"," user"},
        new object[] { "TrailingSpacePassword", "user "},

    };

    public static object[][] InvalidUsername =
    {
        new object[] { "AnyUsername", "etestuser" },
        new object[] { "OneCharacterUsername", "a" },
        new object[] { "TwoCharactersUsername", "bc" },
        new object[] { "AboveMaxLengthUsername", "qwertyuiopasdfghjklzx" },
        new object[] { "TooLongUsername", "qwertyuiopasdfghjklzxcvbnm" },

        //Invalid characters set

        new object[] { "DigitsOnlyUsername", "12345678" },
        new object[] { "SymbolsOnlyUsername", "!@#$%" },
        new object[] { "LowercaseLettersOnlyUsername", "თეონა კაკაბაძე" },
        new object[] { "WithEmojiUsername", "user😀" },

        //white space

        new object[] { "LeadingSpaceUsername", " user" },
        new object[] { "TrailingSpaceUsername", "user " },
    };
}