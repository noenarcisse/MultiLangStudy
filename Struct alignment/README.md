# Struct memory alignment
## C#
### Struct alignment et padding
 int est un in32 par defaut<br>
 Ca compte surtout sur les record struct et struct. Les classes sont réorganisées plus intelligement.
  ```
public struct GoodStruct(){
    byte b1 = 0;
    byte b2 = 0;
    int i = 0;
}
public struct BadStruct(){
    byte b1 = 0;
    int i = 0;
    byte b2 = 0;
}
public class StructAligementTest{
    public static void PrintStructSizes(){
        Console.WriteLine("Good = "+Unsafe.SizeOf<GoodStruct>()); // 8
        Console.WriteLine("Bad = "+ Unsafe.SizeOf<BadStruct>()); // 12
    }
}
  ```
## Go
### Struct alignment et padding
  Les struct en go font la meme chose qu'en C : elles s'alignent en mémoire et font du padding pour occuper des blocs complets dont la taille depend de la l'archi<br>
  Pour diminuer la taille occupée, il faut grouper correctement les elements les plus petits pour qu'ils evitent de creer des padding a vide enormes.<br>
  Go deduit le int sur base de l'archi du pc tout seul si non précisé
  ```
// x64, int32 non explicité -> int64 par defaut
  type memAlignTest struct {
	a byte //1 |
	b byte //1 | = 1 + 1 + 6 padding
	i int  //8 = 8 dans un bloc complet
}
type memAlignTestBad struct {
	a byte //8 = 1 + 7 padding
	i int  //8 = 8 complet (int 64)
	b byte //8 = 1 + 7 padding
}

func checkStructSize() {
	memGood := memAlignTest{}
	memBad := memAlignTestBad{}
	fmt.Println("Good struct = ", unsafe.Sizeof(memGood)) // 16
	fmt.Println("Bad struct = ", unsafe.Sizeof(memBad)) // 24
}
  ```
