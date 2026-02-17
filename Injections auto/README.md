# Injections
## C#
### Option
Neste des objets dans un options. Ca permet de singleton par defaut et rendre injectable certains elements pour asp.net.
Snapshot prend une image a un moment t, avec une requete http
Monitor est un observer en temps reel qui reagit aux changement de valeurs.
Le T nesté est récupérable par un .Value
  ```cs
IOptions<T>, IOptionsSnapshot<T>, IOptionsMonitor<T>
  ```
### Entity
  text)<br>
  ```cs
  //code
  ```
## JS / TS (Angular)
### @Injectable()
Injecte et singletonify souvent aussi les class ciblée par le decorateur.
  ```ts
@Injectable({
  providedIn: 'root' // global singleton with DI
})
export class AnalyticsService {
//do stuff
}
  ```
  ```ts
//avec injection en constructor
export class MyComponent {

  constructor(private stats: AnalyticsService) {}

  doStuff() {
    this.stats.saveLog(); 
  }
}
  ```
  ```ts
//aussi possible sans le constructor en assignant le default de la prop et en gardant le constructeur par defaut
export class MyComponent {
  private stats = inject(AnalyticsService);
}
  ```
  ```ts
//sans
export class MyComponent {

//injection en live dans la methode
  doStuff() {
    const stats = inject(AnalyticsService); 
    stats.saveLog();
  }
}
  ```

