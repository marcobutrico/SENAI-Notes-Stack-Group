
namespace SENAI_Notes.ViewModels
{
    public class ListTagViewModel
    {

        public int IdTag { get; set; }
        public string NomeTag { get; set; }
        public object TituloNote { get; internal set; }
        public DateTime DataEdicao { get; internal set; }
        public int TitleNote { get; internal set; }
    }
}