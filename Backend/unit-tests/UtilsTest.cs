namespace WebApp;
public class UtilsTest(Xlog Console)
{
    private static readonly Arr mockUsers = JSON.Parse(
    File.ReadAllText(FilePath("json", "mock-users.json")));
    
    [Theory]
    [InlineData("afsW12???", true)]
    [InlineData("12345678", false)]
    [InlineData("awseQWE21q3", false)]
    [InlineData("12345qwe", false)]
    public void TestIsPasswordGoodEnough(string password, bool expected)
    {
        Assert.Equal(expected, Utils.IsPasswordGoodEnough(password));
    }

    [Theory]
    [InlineData(
        "---",
        "Hello, go fuck yourself. This is fucking real, no shells!",
        "Hello, go --- yourself. This is --- real, no shells!"
    )]
    public void TestRemoveBadWords(string replaceWith, string original, string expected)
    {
        Assert.Equal(expected, Utils.RemoveBadWords(original, replaceWith));
    }

    [Fact]
    public void TestCreateMockUsers()
    {
        // Get all users from the database
        Arr usersInDb = SQLQuery("SELECT email FROM users");
        Arr emailsInDb = usersInDb.Map(user => user.email);

        // Only keep the mock users not already in db
        Arr mockUsersNotInDb = mockUsers.Filter(mockUser => !emailsInDb.Contains(mockUser.email));

        // Assert that the CreateMockUsers only return newly created users in the db

        var result = Utils.CreateMockUsers();

        // Assert that the CreateMockUsers only return
        // newly created users in the db
        Console.WriteLine($"The test expected that {mockUsersNotInDb.Length} users should be added.");
        Console.WriteLine($"And {result.Length} users were added.");
        Assert.Equivalent(mockUsersNotInDb, result);
        Console.WriteLine("The test passed!");
    }

    [Fact]
    public void TestRemoveMockUsers()
    {
        Arr usersInDb = SQLQuery("SELECT email FROM users");
        Arr emailsInDb = usersInDb.Map(user => user.email);

        Arr mockUsersInDb = mockUsers.Filter(mockUser => emailsInDb.Contains(mockUser.email));

        var result = Utils.RemoveMockUsers();

        Console.WriteLine($"The test expected that {mockUsersInDb.Length} users should be removed.");
        Console.WriteLine($"And {result.Length} users were removed.");
        Assert.Equivalent(mockUsersInDb, result);
        Console.WriteLine("The test passed!");
    }

    [Fact]
    public void TestCountDomainsFromUserEmails()
    {

        var result = Utils.CountDomainsFromUserEmails();

        Assert.Equivalent(, result);
    }
}