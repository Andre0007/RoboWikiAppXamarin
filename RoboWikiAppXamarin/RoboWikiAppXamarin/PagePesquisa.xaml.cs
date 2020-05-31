using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoboWikiAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePesquisa : ContentPage
    {
        public PagePesquisa()
        {
            InitializeComponent();
        }

        public PagePesquisa(DadosWikipedia dados)
        {
            InitializeComponent();
            lTitulo.Text = dados.title;
            GetImages(dados);
            //iImagem.Source = dados.images[0];
            eDados.Text = dados.content.Substring(0, dados.content.IndexOf("="));
        }

        public String GetImage(DadosWikipedia dados)
        {
            string imagem = "";
            int i = 0;
            while (i < dados.images.Length && imagem == "")
            {
                if (dados.images[i].IndexOf("jpg") > 0)
                {
                    imagem = dados.images[i];
                }
                i++;
            }
            return imagem;
        }

        public void GetImages(DadosWikipedia dados)
        {
            string imagem = "";
            int i = 0;
            while (i < dados.images.Length)
            {
                if (dados.images[i].IndexOf("jpg") > 0)
                {
                    imagem = dados.images[i];
                    Image image = new Image { Source = imagem, HeightRequest = 300 };
                    sImagens.Children.Add(image);
                }
                i++;
            }
        }

    }
}