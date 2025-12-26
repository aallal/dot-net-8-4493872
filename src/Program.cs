using System.Text.RegularExpressions;

void Afficher(string[] liste, Range range)
{
    foreach (var c in liste[range])
    {
        Console.WriteLine(c);
    }

}

var bic = "ATCICIAB";

Console.Write($"Le BIC '{bic}' est ");
if (Regex.IsMatch(bic, @"^[A-Z]{6}[A-Z0-9]{2,5}$")) // TODO : [A-Z]{6}[A-Z0-9]{2,5}
{
    Console.WriteLine("valide.");
}
else
{
    Console.WriteLine("non valide.");
}

var twitGeorgeSand = "Tu fuyais la #solitude et la trouvait #partout.";

var hashtags = Regex.Matches(twitGeorgeSand, @"#\w+"); // TODO : Extraire #\w+

foreach (var tag in hashtags)
{
    Console.WriteLine(tag);
}


var html = Regex.Replace(
        twitGeorgeSand, @"#\w+",
        m => $"<a href='?tag={m.Value.Substring(1)}'>{m.Value}</a>"
);
Console.WriteLine(html);
