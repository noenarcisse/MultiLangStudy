# ASP.NET

## Verbes
  ### GET [HttpGet]
  ```
200 : Ok(data)
204 : NoContent()
401 : Unauthorized()
403 : Forbid()
404 : NotFound()

500 : Interal server error
  ```
  ### POST [HttpPost]
  ```
201 : CreatedAtAction()
400 : BadRequest()
  ```
  ### PUT [HttpPut("{id}")]
  ```
204 : NoContent()
400 : BadRequest()
404 : NotFound()
  ```
  ### DELETE [HttpDelete("{id}")]
  ```
204 : NoContent()
404 : NotFound()
  ```

## Middlewares
Fonction qui se passe un HttpContext et un RequestDelegate. Ca exéc du code, lance le next pour la fonction qui suit puis en sortie on exec la suite du code et on ressors en cascade. Très similaire à des recuring / callback mais sous une version hyper standardisée ASP.NET. <br>
Ca permet de suivre une logique de Request > Exec > Response avec imbrication.

L'ordre est important : <br>
Exception → HTTPS → Static → Routing → Auth → Endpoints

  ### UseExceptionHandler
  Doit passer en tout premier, pour attraper TOUTES les exceptions possibles le plus tot <br>
  Gere les erreurs pour afficher une page plutot qu'un code d'erreur<br>
  ### UseLogging()
  Logs cleans, doit capturer le plus d'infos possibles le plus tot dans la chaine à suivre<br>
  ### UseHsts
  Obligation de respecter le https et de ne jamais permettre le http.<br>
  ### UseHttpsRedirection()
  Redirection de http vers https si possible<br>
  ### UseStaticFiles()
  Sert les fichiers static. Par défaut c'est public donc lors de sa résolution pour un fichier, le pipeline saute le reste des fonctions.<br>
  Il n'y a pas d'auth par exemple d'appliquer ici. Si une image privée doit être gérée, il faut la servir par un endpoint special qui lui est couvert par [Authentication]
  ### UseCookiesPolicy()
  Pur RGPD, permet de gerer les droits de cookie entre les essentiels et le reste.<br>
  Les cookies peuvent être volontairement taggé isEssential=true. 
```
Response.Cookies.Append("maCle", "maValeur", new CookieOptions
{
    Expires = DateTimeOffset.UtcNow.AddDays(7),
    HttpOnly = true,   // Inaccessible au JS
    Secure = true,     // HTTPS uniquement
    SameSite = SameSiteMode.Strict
});
var valeur = Request.Cookies["maCle"];
Response.Cookies.Delete("maCle");
```
  ### UseRouting()
  Gere le routing local, apres le domain. Il ne voit que [domain]/page/id <br>
  ### UseAuthentication()
  Identity, permet de marquer un utilisateur pour le reconnaitre.<br>
  La méthode utilisée dépend du service configuré avant de App.Build()
  ```
// Cookie (classique web, comme $_SESSION mais géré par ASP.NET)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

// JWT (pour API, mobile, SPA)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

// Google, Facebook, etc.
builder.Services.AddAuthentication()
    .AddGoogle(...)
    .AddFacebook(...);
```
  ### UseAuthorization()
  Auth, permet d'identifier les permissions pour les differentes pages qu'on visite et les droits de l'utilisateur<br>
  ### UseAntiforgery()
  Protection POST contre des Cross-Site Request<br>
  Ca permet d'identifier qu'un POST viennent bien d'un formulaire de notre popre site.
  ### UseSession()
  Uniquement dans le cas d'utilisation de Session. Equivalent de $_SESSION de php en soi<br>


  ### app.MapStaticAssets();
  ### app.MapControllerRoute(...); // For MVC controllers
  ### app.MapRazorPages(); // For Razor Pages pages
  ### app.MapControllers(); // With authentication in a Razor Pages app

  ### UseStatusCodePagesWithReExecute
  Intercepte les 404 pour afficher une page specifique. A résoudre apres les endpoints.

  
## Blazor 

### Services
  #### AddRazorComponents()
  Ajoute les services pour rendre des .razor
  #### AddInteractiveServerComponents()
  Ajoute le support pour le mode Interactive Server. C'est ce qui permet à Blazor d'utiliser SignalR (WebSockets) pour mettre à jour la page en temps réel sans     rechargement.

### Middlewares
  #### UseExceptionHandler
  text)<br>
  #### UseHsts
  Obligation de respecter le https et de ne jamais permettre le http<br>
  #### UseHttpsRedirection()
  Redirection de http vers https si possible<br>

  #### UseAntiforgery()
  protège contre les attaques CSRF (quelqu'un qui essaierait de soumettre un formulaire à ta place). Blazor en a besoin pour valider les interactions entre le navigateur et le serveur.
