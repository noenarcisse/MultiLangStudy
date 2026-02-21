# .NET & ASP.NET Core — Grands Principes

---

## 1. Structure d'un projet ASP.NET Core

Tout part de `Program.cs` — c'est le point d'entrée qui configure l'app.

```csharp
var builder = WebApplication.CreateBuilder(args);

// 1. Enregistrement des services (DI)
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// 2. Configuration du pipeline HTTP (Middleware)
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

Deux phases bien séparées : **enregistrement** des services, puis **configuration** du pipeline.

---

## 2. Dependency Injection (DI)

### Cycles de vie

```csharp
services.AddSingleton<IMonService, MonService>();   // une seule instance pour toute l'app
services.AddScoped<IMonService, MonService>();      // une instance par requête HTTP
services.AddTransient<IMonService, MonService>();   // nouvelle instance à chaque injection
```

**Règle d'or :** ne jamais injecter un `Transient` ou `Scoped` dans un `Singleton` — le Singleton vivra plus longtemps que ses dépendances (captive dependency).

### Injection dans un controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
}
```

### Options Pattern (config typée)

```csharp
// appsettings.json
// { "Mail": { "Host": "smtp.gmail.com", "Port": 587 } }

public class MailOptions
{
    public string Host { get; set; } = "";
    public int Port { get; set; }
}

builder.Services.Configure<MailOptions>(
    builder.Configuration.GetSection("Mail"));

// Dans le service :
public class MailService(IOptions<MailOptions> options)
{
    private readonly MailOptions _config = options.Value;
}
```

---

## 3. Controllers & Routing

```csharp
[ApiController]
[Route("api/[controller]")] // → api/users
public class UsersController : ControllerBase
{
    [HttpGet]                          // GET api/users
    public IActionResult GetAll() { }

    [HttpGet("{id}")]                  // GET api/users/42
    public IActionResult GetById(int id) { }

    [HttpPost]                         // POST api/users
    public IActionResult Create([FromBody] CreateUserDto dto) { }

    [HttpPut("{id}")]                  // PUT api/users/42
    public IActionResult Update(int id, [FromBody] UpdateUserDto dto) { }

    [HttpDelete("{id}")]               // DELETE api/users/42
    public IActionResult Delete(int id) { }
}
```

### Sources des paramètres

```csharp
[FromRoute]  int id        // /users/42
[FromQuery]  string name   // /users?name=alice
[FromBody]   CreateDto dto // body JSON
[FromHeader] string token  // header HTTP
```

### Retours standard

```csharp
return Ok(data);           // 200
return Created(uri, data); // 201
return NoContent();        // 204
return BadRequest("msg");  // 400
return NotFound();         // 404
return StatusCode(500);    // custom
```

---

## 4. Minimal APIs (alternative aux Controllers)

Plus léger, sans controller ni classe.

```csharp
app.MapGet("/api/users", async (AppDbContext db) =>
    await db.Users.ToListAsync());

app.MapPost("/api/users", async (CreateUserDto dto, AppDbContext db) =>
{
    var user = new User { Name = dto.Name };
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/api/users/{user.Id}", user);
});
```

Idéal pour des petites APIs ou des microservices. Les controllers restent préférables pour des projets plus structurés.

---

## 5. Middleware & Pipeline

Le pipeline HTTP c'est une chaîne de middlewares. Chaque middleware peut traiter la requête et passer au suivant via `next()`.

```csharp
app.Use(async (context, next) =>
{
    // Avant
    Console.WriteLine($"→ {context.Request.Method} {context.Request.Path}");
    
    await next(context); // passe au middleware suivant
    
    // Après (retour)
    Console.WriteLine($"← {context.Response.StatusCode}");
});
```

### Middleware custom en classe

```csharp
public class TimingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        await next(context);
        sw.Stop();
        Console.WriteLine($"Requête traitée en {sw.ElapsedMilliseconds}ms");
    }
}

// Enregistrement
app.UseMiddleware<TimingMiddleware>();
```

### Ordre du pipeline — critique

L'ordre dans `Program.cs` est important :

```csharp
app.UseExceptionHandler();   // 1. Gestion d'erreurs (en premier)
app.UseHttpsRedirection();   // 2. Redirection HTTPS
app.UseStaticFiles();        // 3. Fichiers statiques
app.UseRouting();            // 4. Routing
app.UseAuthentication();     // 5. Qui es-tu ?
app.UseAuthorization();      // 6. As-tu le droit ? (APRÈS auth)
app.MapControllers();        // 7. Endpoints
```

`UseAuthentication` doit toujours être avant `UseAuthorization`.

### Court-circuiter le pipeline

```csharp
app.Use(async (context, next) =>
{
    if (context.Request.Headers["X-Api-Key"] != "secret")
    {
        context.Response.StatusCode = 401;
        return; // stop — ne passe pas au suivant
    }
    await next(context);
});
```

---

## 6. Entity Framework Core

### DbContext

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);
    }
}
```

### Entités & Attributs

```csharp
[Table("users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    public ICollection<Post> Posts { get; set; } = [];
}
```

### Migrations

```bash
dotnet ef migrations add NomDeLaMigration
dotnet ef database update
dotnet ef migrations remove        # annuler la dernière
dotnet ef database update 0        # rollback complet
```

### Requêtes LINQ + EF

```csharp
// SELECT avec filtre
var users = await db.Users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .ToListAsync();

// JOIN (navigation property)
var posts = await db.Posts
    .Include(p => p.Author)
    .Where(p => p.Author.Name == "Alice")
    .ToListAsync();

// Projection → DTO
var dtos = await db.Users
    .Select(u => new UserDto { Id = u.Id, Name = u.Name })
    .ToListAsync();

// Single
var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

// Count / Any
bool exists = await db.Users.AnyAsync(u => u.Email == email);
int count = await db.Users.CountAsync();
```

### CRUD

```csharp
// Create
db.Users.Add(new User { Name = "Alice" });
await db.SaveChangesAsync();

// Update
var user = await db.Users.FindAsync(id);
user.Name = "Bob";
await db.SaveChangesAsync();

// Delete
db.Users.Remove(user);
await db.SaveChangesAsync();
```

---

## 7. LINQ

LINQ fonctionne sur n'importe quel `IEnumerable<T>` (en mémoire) ou `IQueryable<T>` (traduit en SQL via EF).

```csharp
var numbers = new[] { 1, 2, 3, 4, 5, 6 };

// Filtrage
numbers.Where(n => n > 3)                // [4, 5, 6]

// Transformation
numbers.Select(n => n * 2)              // [2, 4, 6, 8, 10, 12]

// Aplatissement
lists.SelectMany(l => l.Items)          // aplatit une liste de listes

// Agrégation
numbers.Sum()                           // 21
numbers.Average()                       // 3.5
numbers.Min() / numbers.Max()

// Recherche
numbers.First(n => n > 3)              // 4 (throw si vide)
numbers.FirstOrDefault(n => n > 10)    // 0 (default si vide)
numbers.Single(n => n == 3)            // 3 (throw si plusieurs)

// Vérification
numbers.Any(n => n > 5)                // true
numbers.All(n => n > 0)                // true

// Tri
numbers.OrderBy(n => n)
numbers.OrderByDescending(n => n)

// Groupement
numbers.GroupBy(n => n % 2 == 0 ? "pair" : "impair")

// Chaînage
var result = numbers
    .Where(n => n % 2 == 0)
    .Select(n => n * 10)
    .OrderByDescending(n => n)
    .ToList();                          // [60, 40, 20]
```

**IEnumerable vs IQueryable :**
- `IEnumerable` → exécution en mémoire, chargement complet d'abord
- `IQueryable` (EF) → traduit en SQL, filtre côté base de données

Toujours filtrer **avant** `.ToList()` avec EF pour ne pas charger toute la table.

---

## 8. Async / Await

```csharp
// Toujours async jusqu'au bout
public async Task<User?> GetUserAsync(int id)
{
    return await db.Users.FindAsync(id);
}

// Plusieurs appels en parallèle
var (users, posts) = await (
    db.Users.ToListAsync(),
    db.Posts.ToListAsync()
);

// Ou avec Task.WhenAll
var tasks = ids.Select(id => GetUserAsync(id));
var results = await Task.WhenAll(tasks);
```

**Règles :**
- Jamais de `.Result` ou `.Wait()` — risque de deadlock
- Toujours propager le `CancellationToken` dans les controllers et services
- Nommer les méthodes async avec le suffixe `Async`

```csharp
// CancellationToken dans controller → service → EF
[HttpGet]
public async Task<IActionResult> Get(CancellationToken ct)
{
    var users = await _service.GetAllAsync(ct);
    return Ok(users);
}
```

---

## 9. Gestion d'erreurs

### Exception Handler global

```csharp
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var error = context.Features.Get<IExceptionHandlerFeature>();
        await context.Response.WriteAsJsonAsync(new { error = error?.Error.Message });
    });
});
```

### Problem Details (standard RFC 7807)

```csharp
builder.Services.AddProblemDetails();

// Retour automatique en cas d'erreur :
// { "type": "...", "title": "Not Found", "status": 404, "detail": "..." }
```

### Result Pattern (alternative aux exceptions)

```csharp
public record Result<T>(T? Value, string? Error, bool IsSuccess);

public async Task<Result<User>> GetUserAsync(int id)
{
    var user = await db.Users.FindAsync(id);
    if (user is null) return new Result<User>(null, "User not found", false);
    return new Result<User>(user, null, true);
}
```

---

## 10. DTOs & Validation

Ne jamais exposer les entités EF directement dans l'API — utiliser des DTOs.

```csharp
public record CreateUserDto(
    [Required] string Name,
    [EmailAddress] string Email,
    [Range(18, 120)] int Age
);

public record UserResponseDto(int Id, string Name, string Email);
```

`[ApiController]` active la validation automatique — si le DTO est invalide, retourne un 400 sans que tu aies à vérifier manuellement.

---

## Cheat Sheet

| Concept | Clé |
|---|---|
| Singleton | 1 instance pour toute l'app |
| Scoped | 1 instance par requête |
| Transient | Nouvelle instance à chaque injection |
| `IQueryable` | SQL généré côté BDD |
| `IEnumerable` | Exécution en mémoire |
| Middleware | `Use` → passe au suivant, `Run` → terminal |
| `[FromBody]` | Paramètre depuis le JSON de la requête |
| `[FromRoute]` | Paramètre depuis l'URL |
| `SaveChangesAsync` | Commit toutes les modifs EF en attente |
| `CancellationToken` | Annulation propre des requêtes longues |
