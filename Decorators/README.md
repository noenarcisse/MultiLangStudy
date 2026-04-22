# Decorator
## C#
### [Attributes]
  Différence de nom, meme principe, wrappe la classe pour lui donner des comportement bonus.<br>
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
