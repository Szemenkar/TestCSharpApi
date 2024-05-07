namespace WebApp;
public static class Utils
{
    public static int SumInts(int a, int b)
    {
        return a + b;
    }

    public static Arr CreateMockUsers()
    {
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr successFullyWrittenUsers = Arr();
        foreach (var user in mockUsers)
        {
            var result = SQLQueryOne(
                @"INSERT INTO users(firstName,lastName,email,password)
                VALUES($firstName, $lastName, $email, $password)
            ", user);
            // If we get an error from the DB then we haven't added the mock users
            // If not we have so add to the successful list
            if(!result.HasKey("error"))
            {
                // The specification says return the user list without password
                user.Delete("password");
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }

    public static bool IsPasswordGoodEnough(string password)
    {
        List<bool> bools = new List<bool>();

        bools.Add(password.Any(char.IsLower));
        bools.Add(password.Any(char.IsNumber));
        bools.Add(password.Any(char.IsUpper));
        bools.Add(password.Count() > 7);
        bools.Add(password.Any(ch => !char.IsLetterOrDigit(ch)));

        if (bools.Contains(false))
        {
            return false;
        }
        return true;
    }
}