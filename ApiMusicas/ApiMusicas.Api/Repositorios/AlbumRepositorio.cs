using ApiMusicas.Api.Models;

namespace ApiMusicas.Api.Repositorios;

public class AlbumRepositorio
{
  private static int _indiceId = 1;
  private static List<Album> _albuns = new();

  public Album Criar(Album album)
  {
    album.Id = _indiceId;

    _indiceId++;

    _albuns.Add(album);

    return album;
  }

  public Album Atualizar(int id, Album album)
  {
    var albumExistente = _albuns
        .FirstOrDefault(AlbumLista => AlbumLista.Id == id);

    if (albumExistente == null) return null;

    albumExistente.Nome = album.Nome;
    albumExistente.AnoLancamento = album.AnoLancamento;
    albumExistente.CapaUrl = album.CapaUrl;
    albumExistente.Artista = album.Artista;

    return albumExistente;
  }

  public void Remover(int albumId)
  {
    var albumExistente = _albuns
        .FirstOrDefault(AlbumLista => AlbumLista.Id == albumId);

    _albuns.Remove(albumExistente);
  }

  public List<Album> ObterTodos()
  {
    return _albuns;
  }

  public Album ObterPorId(int albumId)
  {
    return _albuns.FirstOrDefault(a => a.Id == albumId);
  }
}