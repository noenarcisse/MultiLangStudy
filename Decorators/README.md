# Decorator
## C#
### [decorator]
  text)<br>
  ```cs
  //code
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
