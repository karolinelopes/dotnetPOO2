using System;

namespace CRUDSeries
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }


        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string resposta = "";
            resposta += "Gênero: " + this.Genero + Environment.NewLine;
            resposta += "Título: " + this.Titulo + Environment.NewLine;
            resposta += "Descrição: " + this.Descricao + Environment.NewLine;
            resposta += "Ano: " + this.Ano + Environment.NewLine;
            resposta += "Excluido: " + this.Excluido + Environment.NewLine;
            return resposta;
        }

        public string getTitulo()
        {
            return this.Titulo;
        }

        public int getId()
        {
            return this.Id;
        }

        public bool getExcluido()
        {
            return this.Excluido;
        }

        public void Excluir() 
        {
            this.Excluido = true;
        }

    }
}