# Decorator
## Nim
### pragmas
  ```nim
template jsonAttr(name : string) {.pragma.}

#forcé de typedescr, le compile arrive pas a resoudre T sans
template customJson[T : object](node : JsonNode, t: typedesc[T]) : T =
    var res : T
    for keyName, field in res.fieldPairs :
        const key = 
            when field.hasCustomPragma(jsonAttr) : field.getCustomPragmaVal(jsonAttr)
            else : keyName
        
        if node.hasKey(key) :
            when field is string : field = node[key].getStr()
            elif field is bool : field = node[key].getBool()
            elif field is int : field = node[key].getInt()
            elif field is float : field = node[key].getFloat()
            elif field is object : field = customJson(node[key], typeof field)
    res
  ```
## C#
### [Attributes]
  Ca permet d'avoir des métadonnées accrochées à un élément<br>
  Courament vu chez ASP en MVC.
  ```cs
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  //blablabla
}
  ```
  ```cs
[Required] // evite de devoir string.EmptyOrNull()
[StringLength(100)] // evite le string.Length <= 100
[MinLength(5)] / [MaxLength(50)] //array, list etc
[Range(1, 100)] //range d'un int par ex
[RegularExpression(@"pattern")] // format a respecter de regex
[Compare("Password")] //comparaison de password et confirm password

[EmailAddress]
[Phone]
[Url]
[DataType(DataType.Password)]
[DataType(DataType.Date)]
[CreditCard]

[Display(Name = "Nom d'utilisateur")]
[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
[ScaffoldColumn(false)]

//entity
[Key] // prim key
[ForeignKey("NomPropriete")] // foreign key
[NotMapped] // ignoré, ne fait pas de column en DB

//razor MVC / blazor
[Authorize] // test si une session existe sous une forme quelconque avec au moins un JWT

[Authorize(Roles = "Admin")] // page razor uniquement pour un admin
public class ModelTruc

//blazor
@attribute [Authorize] //page blazor inaccessible sans identity

@attribute [Authorize(Roles = "Admin")] //page blazor uniquement pour un admin
<AuthorizeView Roles="Admin">
    <Authorized>
        //code admin
    </Authorized>
    <NotAuthorized>
       // les autres
    </NotAuthorized>
</AuthorizeView>
  ```
## Go
### reflect
 Dans le principe on peut intercepter n'importe quoi<br>
 On peut le faire principal avec relfect. Ca cree des codes peu goesque car les errs sortent de la compile pour se retrouver au runtime :/
  ```go
func (di *DI) Inject(f any, args ...any) {
	t := reflect.TypeOf(f)
	if t.Kind() != reflect.Func {
		panic("non")
	}

	values := []reflect.Value{}

	argsLen := t.NumIn()
	argsManuels := len(args)

	for i := 0; i < argsLen; i++ {

		if i < argsManuels {
			values = append(values, reflect.ValueOf(args[i]))
			continue
		}
		at := t.In(i)
		if at.Kind() != reflect.Interface {
			errMsg := fmt.Sprintf("Only interfaces are injectables, found %s", at.Kind())
			panic(errMsg)
		}
		fmt.Printf("%s - %s\n", at, at.Kind())
		if _, ok := di.register[at]; ok {
			values = append(values, reflect.ValueOf(di.register[at]))
		}
	}
	reflect.ValueOf(f).Call(values)
}
  ```
### closures
La manière Go plus respecteuse de la philo du language serait plutot une utilisation de closure
  ```go
type HandlerFunc func() int

func main() {
	res := LogMaFunc("Je fais des maths très compliquées", FaireDesMath)
	addition := res()
	fmt.Println(addition)
}

func LogMaFunc(msg string, f HandlerFunc) HandlerFunc {
	return func() int {
		fmt.Printf("LOG: %s\n", msg)
		return f()
	}
}

func FaireDesMath() int {
	return 2 + 2
}
  ```

## TS
 @maFonction qui vient décorer une class, une methode ou un champs.
### class decorator
  permet d'intercepter une class<br>
  ```ts
function Singleton<T extends {new(...args: any[]): {}}>(target : T)
{
    let instance : T;
    constructor(...args : any[])
    {
        if(instance)
            return instance;
        super(...args);
        instance = this as any;
    }
}
  ```
### field decorator
  Peut permettre la modification d'un champs d'une class<br>
  ```ts
funtion Readlony(target : any, context:ClassFieldDecoratorContext)
{
  return function(this, initialValue : any)
    {
        return intialValue;
    }
}

class MaClass
{
    @Readonly
    unField : string = "Hey!";
}
  ```
### method decorator
  permet d'intercepter une methode<br>
  ```ts
function LogSpeed(originalMethod : any, context:ClassMethodDecoratorContext)
{
    return function (this : any, ...args: any[])
    {
        console.time("speedtest");
        const result = orginalMethod.apply(this, args);
        console.timeEnd("speedtest");
    }
}
  ```
