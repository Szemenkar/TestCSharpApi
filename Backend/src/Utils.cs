namespace WebApp;
public static class Utils
{
    private static readonly Arr mockUsers = JSON.Parse(
    File.ReadAllText(FilePath("json", "mock-users.json")));

    private static readonly Arr badWords = ((Arr)JSON.Parse(
    File.ReadAllText(FilePath("json", "badwords.json"))
    )).Sort((a, b) => ((string)b).Length - ((string)a).Length);

    public static bool IsPasswordGoodEnough(string password)
    {
        List<bool> bools = new List<bool>();

        bools.Add(password.Count() > 7);
        bools.Add(password.Any(char.IsDigit));
        bools.Add(password.Any(char.IsLower));
        bools.Add(password.Any(char.IsUpper));
        bools.Add(password.Any(x => !char.IsLetterOrDigit(x)));

        if (bools.Contains(false))
        {
            return false;
        }
        return true;
    }

    public static string RemoveBadWords(string comment, string replaceWith = "---")
    {
        comment = " " + comment;
        replaceWith = " " + replaceWith + "$1";
        badWords.ForEach(bad =>
        {
            var pattern = @$" {bad}([\,\.\!\?\:\; ])";
            comment = Regex.Replace(
                comment, pattern, replaceWith, RegexOptions.IgnoreCase);
        });
        return comment[1..];
    }

    public static Arr CreateMockUsers()
    {
        Arr successfullyWrittenUsers = Arr();
        foreach (var user in mockUsers)
        {
            var result = SQLQueryOne(
                @"INSERT INTO users(firstName,lastName,email,password)
                VALUES($firstName, $lastName, $email, $password)
            ", user);
            // If we get an error from the DB then we haven't added the mock users
            // If not we have to add to the successful list
            if(!result.HasKey("error"))
            {
                // The specification says return the user list without password
                user.Delete("password");
                successfullyWrittenUsers.Push(user);
            }
        }
        return successfullyWrittenUsers;
    }

    public static Obj CountDomainsFromUserEmails()
    {
        var emailDomain = Obj();

        var allEmailsInDb = SQLQuery("SELECT email FROM users");

        foreach (var domain in allEmailsInDb)
        {
            var domains = RetrieveDomainName(domain);
            if (domains.HasKey())
            {
                emailDomain[domains]++;
            }
            else
            {
                emailDomain[domains] = 1;
            }
        }
        return emailDomain;
    }

    public static string RetrieveDomainName(string email)
    {
        var domainLocation = email.IndexOf('@');
        return email.Substring(domainLocation + 1, email.Length - domainLocation - 1);
    }

    public static Arr RemoveMockUsers()
    {
        Arr successfullyRemovedUsers = Arr();

        Arr allUsersInDb = SQLQuery("SELECT email FROM users");
        Arr allEmailsInDb = allUsersInDb.Map(user => user.email);

        Arr mockUsersInDb = mockUsers.Filter(mockUser => allEmailsInDb.Contains(mockUser.email));
        
        foreach (var email in mockUsersInDb)
        {
            var result = SQLQueryOne(
            @"DELETE FROM users
            WHERE users.email = $email", email
        );

        if(!result.HasKey("error"))
        {
            successfullyRemovedUsers.Push(email);
        }
        }
        return successfullyRemovedUsers;
    }
}