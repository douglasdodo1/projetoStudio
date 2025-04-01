using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

public class ExceptionMiddleware  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger){
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context){
        try{
            await _next(context);
        }catch(ArgumentOutOfRangeException exception){
            _logger.LogError(exception, "Argumento inválido");
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { message = "Argumento inválido" });
        }catch(KeyNotFoundException exception){
            _logger.LogError(exception, "Recurso não encontrado");
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { message = "Recurso não encontrado" });
        }
        catch(DbUpdateException exception){
             _logger.LogError(exception, "Erro de concorrência no banco de dados");
            context.Response.StatusCode = 409;
            await context.Response.WriteAsJsonAsync(new { message = "Erro de concorrência no banco de dados" });
        }
        catch(ValidationException exception){
            _logger.LogError(exception, "Erro de validação de dados");
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new {message = "dados inválidos"});
        }
        catch(UnauthorizedAccessException exception){
            _logger.LogError(exception,"Acesso não autorizado");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(new {message = "Acesso não autorizado"});
        }
        catch(ArgumentNullException exception){
            _logger.LogError(exception, "Argumento não fornecido");
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new {message = "Argumento não fornecido"});
        }
        catch(TimeoutException exception){
            _logger.LogError(exception, "Tempo de resposta excedido");
            context.Response.StatusCode = 408;
            await context.Response.WriteAsJsonAsync(new {message = "Tempo de resposta excedido"});
        }
        catch(InvalidOperationException exception){
            _logger.LogError(exception,"Operação inválida");
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new {message = "Operação inválida"});
        }
        catch(Exception exception){
            _logger.LogError(exception, "Erro desconhecido");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new {message = "Erro desconhecido"});
        }
    }
}