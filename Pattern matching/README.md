# Patterns
## C#
### Property Pattern
  { } variable > pattern matching de n’importe quel objet instancié (ne rejette que null)<br>
  On peut lui donner un type {} ou des propriété internes {Length: 5, Name: "Johnny"}
  ```
string? texte = chargerUnTruc();

if(texte is { } data)
{
	Console.WriteLine(data);
}

if (texte is string { Length: > 5 } s)
{ }
if( livre1 is Livre {titre: “Harry Potter” } bouquin)
{ }
if( livre1 is Livre {titre: var titleBouquin } bouquin)
{
	// titleBouquin existe ici!
	Console.WriteLine(titleBouquin);
 }
  ```

  ```
public void EnchantLoot()
    {
        foreach(Item item in Items)
        {
            if(item is Item {IsBroken: false, Durability: > .5f, PowerLevel: > 80 and var power } selectedItem)
            {
                Console.WriteLine(selectedItem.Name+" "+power);

                if(selectedItem is {Name:"Excalibur"})
                {
                    Console.WriteLine(selectedItem.Name+" trouvée");
                }
            }
        }

    }
  ```
### List Pattern
  Pattern de liste ou array possibles<br>
  ```
if( monTableau is [1,2, .., _, 5, ..]) //verifie le format du tab en 1, 2, {0+}, {1}, 5, {0+}
{ }
  ```
### Pattern matching
  Switch expression par ex<br>
  ```
static int USToBEGrades(string grade) => grade switch
{
    "A+"    =>     20,
    "A"     =>     19,
    "A-"    =>     18,
    "B+"    =>     17,
    "B"     =>     16,
    "B-"    =>     15,
    "C+"    =>     14,
    "C"     =>     13,
    "C-"    =>     12,
    "D+"    =>     11,
    "D"     =>     10,
    "D-"    =>      9,
    "F"     =>      8,
    _       =>      throw new Exception("Unexpected arg found, expected A-F grades")
};
  ```




