using series.Enum;
using System;

namespace series.Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, Genero genero, string descricao, string titulo, int ano)
        {
            Id = id;
            Genero = genero;
            Descricao = descricao;
            Titulo = titulo;
            Ano = ano;
        }

        private Genero Genero { get; set; }
        private string Descricao { get; set; }
        private string Titulo { get; set; }
        private int Ano { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Gênero: {this.Genero}{Environment.NewLine}";
            retorno += $"Titulo: {this.Titulo}{Environment.NewLine}";
            retorno += $"Descrição: {this.Descricao}{Environment.NewLine}";
            retorno += $"Ano Inicio: {this.Ano}{Environment.NewLine}";
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }
    }
}
