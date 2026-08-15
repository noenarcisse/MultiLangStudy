# Jumps
## C#
### goto
  Pour la nostalgie de l'asm je suppose ?
  ```cs
    Boucle:
        var t = Console.ReadLine();
        if (t is null) goto Boucle;
        if (!int.TryParse(t, out int n)) goto Boucle;

        if (n % 2 == 0) goto elseLabel;
        Console.WriteLine("C'est impair");
        goto End;
    elseLabel:
        Console.WriteLine("C'est pair");
    End:;
  ```

## JS
Hors des jumps de base il y a une petite panoplie sauce spaghetti
### label
  On peut y acceder ou le break<br>
  ```js
jumpman :
{
  if(true)
    break jumpman;

    // je ne serais jamais affiché :<
}
//moi si :>
  ```

