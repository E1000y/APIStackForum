using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InterfaceUWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PageDev : Page
    {
        public int catId = 1;

        private DataVM dataVM = new DataVM();
        public PageDev()
        {
           
            this.InitializeComponent();

            //liaison entre la View et le viewModel
            DataContext = dataVM ;

            getSubject();
        }

        private async void getSubject()
        {
            await dataVM.GetSubjects(catId);
        }


        private async void lstSubjects_ItemClick(object sender, ItemClickEventArgs e)
        {
            SubjectBO sbo = e.ClickedItem as SubjectBO;

            await dataVM.GetAnswers(sbo.id);
        }

        private void Dev_Click(object sender, RoutedEventArgs e)
        {
            dataVM.RefreshSubject();
            dataVM.RefreshAnswers();
            catId = 1;
            getSubject();
           
            
        }

        private void Emploi_Click(object sender, RoutedEventArgs e)
        {
            dataVM.RefreshSubject();
            dataVM.RefreshAnswers();
            catId = 2;
            getSubject();

        }

        private void Formation_Click(object sender, RoutedEventArgs e)
        {
            dataVM.RefreshSubject();
            dataVM.RefreshAnswers();
            catId = 3;
            getSubject();

        }

        private void Fun_Click(object sender, RoutedEventArgs e)
        {
            dataVM.RefreshSubject();
            dataVM.RefreshAnswers();
            catId = 4;
            getSubject();
        }

        private void Etc_Click(object sender, RoutedEventArgs e)
        {
            dataVM.RefreshSubject();
            dataVM.RefreshAnswers();
            catId = 5;
            getSubject();

        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dev.IsSelected)
            {
                dataVM.RefreshSubject();
                dataVM.RefreshAnswers();
                catId = 1;
                getSubject();

            }
            else if (Emploi.IsSelected)
            {
                dataVM.RefreshSubject();
                dataVM.RefreshAnswers();
                catId = 2;
                getSubject();
            }
            else if (Formation.IsSelected)
            {
                dataVM.RefreshSubject();
                dataVM.RefreshAnswers();
                catId = 3;
                getSubject();

            }
            else if (Fun.IsSelected)
            {
                dataVM.RefreshSubject();
                dataVM.RefreshAnswers();
                catId = 4;
                getSubject();
            }
            else if (Etc.IsSelected)
            {
                dataVM.RefreshSubject();
                dataVM.RefreshAnswers();
                catId = 5;
                getSubject();

            }

        }
    }
}
