
using AppCadSerie.Series;

namespace AppCadSerie.classes;

    public class Serie : Entidade
{
    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
        this.Id = id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Ano = ano;
        this.Descricao = descricao;
        this.Excluido = false;

    }
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }
    private bool Excluido {get; set ;}

    public override string ToString()
    {
        string retorno = "";
        retorno += "Gênero: " + this.Genero + Environment.NewLine;
        retorno += "Título: " + this.Titulo + Environment.NewLine;
        retorno += "Descrição: " + this.Descricao + Environment.NewLine;
        retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
        retorno += "Excluido: " + this.Excluido;
        return retorno;
    }

    public string retornaTitulo()
    {
        return this.Titulo;
    }

    public bool retornaExcluido()
    {
        return this.Excluido;
    }

    public int retornaId()
    {
        return this.Id;
    }

    public void Excluir()
    {
        this.Excluido = true;
    }
}
