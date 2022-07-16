using System;
using System.IO;
using Ejercicio2_2;
using SignaturesApp.Model;
using SignaturesApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturesList : ContentPage
    {
        public SignaturesList()
        {
            InitializeComponent();
            // Image = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Signatures.imageCode)));   
        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            LoadCollectionView();
        }
        private async void LoadCollectionView()
        {
            listSignatures.ItemsSource = await App.BaseDatos.GetListSignatures();
        }

        private async void listSignatures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Firmass) e.SelectedItem;

            var signatureObtained = await App.BaseDatos.GetSignatureByCode(itemSelected.code);

            var showSignatureInformationPage = new ShowSignatureInformation(signatureObtained);

            await Navigation.PushAsync(showSignatureInformationPage);
        }
    }
}