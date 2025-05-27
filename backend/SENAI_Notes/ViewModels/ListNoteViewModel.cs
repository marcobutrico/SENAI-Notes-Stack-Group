namespace SENAI_Notes.ViewModels
{
    public class ListNote
    {
        public int IdAnotacao { get; set; }
        public string TituloAnotacao { get; set; }
        public string DescricaoAnotacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ImagemAnotacao { get; set; }
        public bool AnotacaoArquivada { get; set; }
        public  List<ListTagViewModel> Tags { get; set; }
    }
}
