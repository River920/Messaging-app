var LISI = ("oops, looks like you have to log-in/sign-in");
Console.WriteLine("Press any key to start...");
Console.ReadKey();
Thread.Sleep(2000);
Console.WriteLine("Welcome to the Setro messaging service");
Thread.Sleep(2000);
Console.WriteLine(LISI);
Thread.Sleep(2000);
string[] LISIO = ["1-Sign-in", "2-Log-in"];
foreach(var ppl in LISIO)
{
    Console.WriteLine(ppl);
}
Console.WriteLine("Please enter the number equevelent to what you want to do");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
