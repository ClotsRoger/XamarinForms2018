using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_consultarCep.Servico;
using App01_consultarCep.Servico.Modelo;

namespace App01_consultarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            try
            {
                var cep = CEP.Text.Trim();
                if (IsValidCep(cep))
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    RESULTADO.Text = $"Endereco: {end.logradouro} de {end.bairro}, {end.localidade}, {end.uf}";
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ERRO", ex.Message, "OK");
            }
        }
        private bool IsValidCep(string cep)
        {
            bool valid = true;
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO ! O CEP deve conter 8 caracteres.", "OK");
                valid = false;
            }
            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO ! O CEP deve ser composto apenas por números.", "OK");
                valid = false;
            }

            return valid;
        }
    }
}
