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

  ### UseExceptionHandler
  Gere les erreurs pour afficher une page plutot qu'un code d'erreur<br>
  ### UseHsts
  Obligation de respecter le https et de ne jamais permettre le http<br>
  ### UseHttpsRedirection()
  Redirection de http vers https si possible<br>
  ### UseStatusCodePagesWithReExecute
  Intercepte les 404 pour afficher une page specifique

  
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
