using ApiMusicas.Api.Models;

namespace ApiMusicas.Api.Repositorios;

public class ArtistaRepositorio
{
  private static int _indiceId = 1;
  private static List<Artista> _artistas = new();

  public Artista Criar(Artista artista)
  {

    artista.Id = _indiceId;

    _indiceId++;

    _artistas.Add(artista);

    return artista;
  }

  public Artista Atualizar(int id, Artista artista)
  {

    var artistaExistente = _artistas
        .FirstOrDefault(artistaLista => artistaLista.Id == id);

    if (artistaExistente == null) return null;

    artistaExistente.Nome = artista.Nome;
    artistaExistente.NomeArtistico = artista.NomeArtistico;
    artistaExistente.PaisOrigem = artista.PaisOrigem;
    artistaExistente.FotoUrl = artista.FotoUrl;

    return artista;
  }

  public void Remover(int artistaId)
  {

    var artistaExistente = _artistas
        .FirstOrDefault(artistaLista => artistaLista.Id == artistaId);

    _artistas.Remove(artistaExistente);
  }

  public List<Artista> ObterTodos(string filtro)
  {
    if (!string.IsNullOrEmpty(filtro))
    {
      return _artistas
          .Where(a => a.Nome.Contains(filtro) || a.NomeArtistico.Contains(filtro))
          .ToList();
    }

    return _artistas;
  }

  public Artista ObterPorId(int artistaId)
  {
    return _artistas.FirstOrDefault(a => a.Id == artistaId);
  }

  public Artista AtualizarFoto(int idArtista, string fotoUrl)
  {
    var artistaExistente = _artistas
        .FirstOrDefault(artistaLista => artistaLista.Id == idArtista);

    artistaExistente.FotoUrl = fotoUrl;

    return artistaExistente;
  }
}