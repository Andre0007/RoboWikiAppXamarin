using Algorithmia;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace RoboWikiAppXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           InitializeComponent();
        }

        private void btExecutar_Clicked(object sender, EventArgs e)
        {
            try { 
                var input = "{"
                            + "  \"articleName\": \"" + eValor.Text + "\","
                            + "  \"lang\": \"pt\""
                            + "}";

                var client = new Client("sim2JF6Ncdn7FkDG+7QomvK2j+V1");
                var algorithm = client.algo("web/WikipediaParser/0.1.2");
                algorithm.setOptions(timeout: 300); // optional
                var response = algorithm.pipeJson<DadosWikipedia>(input);

                DadosWikipedia dados = (DadosWikipedia)response.result;
                this.Navigation.PushAsync(new PagePesquisa(dados));
            }
            catch (Exception ex) {
                DisplayAlert("Error", "Tente refinar os parâmetros de busca, erro: " + ex.Message, "OK");
            }
        }
    }
}