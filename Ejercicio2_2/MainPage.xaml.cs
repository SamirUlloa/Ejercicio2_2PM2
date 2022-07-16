using SignaturePad.Forms;
using SignaturesApp.Model;
using SignaturesApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_2
{
    public partial class MainPage : ContentPage
    {

        string valorDato;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnVerFirmas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignaturesList());
        }

        private async void btnGuardarFirmas_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valorDato = Convert.ToBase64String(data);


            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(description.Text))
            {
                await DisplayAlert("Atención", "Campos Vacios", "OK");
            }

            var signatureToSave = new Firmass
            {
                imageCode = valorDato,
                name = name.Text,
                description = description.Text
            };

            var result = await App.BaseDatos.saveSignature(signatureToSave);

            if (result != 1)
            {
                await DisplayAlert("Error", "Error desconocido", "OK");
            }

            await DisplayAlert("Atención", "Registro Guardado Correctamente", "OK");
        }
    }
}
