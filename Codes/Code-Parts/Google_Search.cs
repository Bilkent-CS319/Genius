using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Search Google for this.
        SearchGoogle("bilkent cs319");
    }

    /// <summary>
    /// Search Google for this term.
    /// </summary>
    static void SearchGoogle(string t)
    {
        Process.Start("http://google.com/search?q=" + t);
    }
}