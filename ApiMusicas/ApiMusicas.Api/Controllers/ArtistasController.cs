using ApiMusicas.Api.DTOs;
using ApiMusicas.Api.Models;
using ApiMusicas.Api.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ApiMusicas.Api.Controllers;

[ApiController]
[Route("api/artistas")]
public class ArtistasController : ControllerBase
{
  private readonly ArtistaRepositorio _artistaRepositorio;

  public ArtistasController(ArtistaRepositorio repositorio)
  {
    _artistaRepositorio = repositorio;
  }

  //GET api/artistas?filtro=vic
  [HttpGet]
  public List<Artista> Get(
      [FromQuery] string filtro
  )
  {
    return _artistaRepositorio.ObterTodos(filtro);
  }

  [HttpPost]
  public ActionResult<Artista> Post(
      [FromBody] Artista novoArtista
  )
  {
    var artista = _artistaRepositorio.Criar(novoArtista);

    return Ok(artista);
  }

  //PUT api/artistas/{id}   
  [HttpPut("{idArtista}")]
  public ActionResult<Artista> AtualizarArtista(
      [FromBody] Artista artista,
      [FromRoute] int idArtista
  )
  {
    var artistaEditado = _artistaRepositorio.Atualizar(idArtista, artista);

    return Ok(artistaEditado);
  }

  [HttpPatch("{idArtista}/foto")]
  public ActionResult AtualizarFoto(
      [FromBody] ArtistaFotoDTO artistaFoto,
      [FromRoute] int idArtista
  )
  {
    var artista = _artistaRepositorio.AtualizarFoto(
        idArtista,
        artistaFoto.FotoUrl
    );

    return Ok(artista);
  }

  //Delete api/artistas/{id}   
  [HttpDelete("{idArtista}")]
  public ActionResult RemoverArtista(
      [FromRoute] int idArtista
  )
  {
    _artistaRepositorio.Remover(idArtista);

    return NoContent();
  }
}