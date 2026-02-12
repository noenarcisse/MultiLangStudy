# Input & Output
## C#
### Console. ReadLine(), Read(), ReadKey()
  classic stdin<br>
  ```C#
    while(true)
    {
        var interrupt = Console.ReadKey(true);
        if(interrupt is {}) break;
    }
  ```
### Process RedirectStandardOutput
Redirige la sortie d'une autre process en entrée du prog<br>
  ```
    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

    using(Process proc = new())
    {
        proc.StartInfo = new ProcessStartInfo 
        { 
            FileName="cmd.exe",
            Arguments="/c ipconfig",
            RedirectStandardOutput=true,
            UseShellExecute=false,
            StandardOutputEncoding= System.Text.Encoding.GetEncoding(850)
        }; 

        proc.Start();
        string result = proc.StandardOutput.ReadToEnd();
        Console.WriteLine(result);
    }
  ```

## Perl
### <STDIN>
  classico classics<br>
  ```
use strict;
use warnings;

# my $n1, my $n2; 

# say "Number 1";
# $n1 = <STDIN>;
# say "Number 2";
# $n2 = <STDIN>;

# say $n1 + $n2; 
  ```
