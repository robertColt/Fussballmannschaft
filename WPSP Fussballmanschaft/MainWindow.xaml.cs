using System;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPSP_Fussballmanschaft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ViewModel mit dem man arbeitet
        private KaderViewModel kaderViewModel;

        public MainWindow()
        {
            InitializeComponent();
            
            kaderViewModel = new KaderViewModel();

            XmlSerializer serializer = new XmlSerializer(typeof(Kader));
            StreamReader streamReader = null;
            string fileName = "SpielerData.xml";

            try
            {
                //filepath Festlegen
                
                string path = Directory.GetParent(Path.GetDirectoryName(Environment.CurrentDirectory)) + "/" + fileName ;
                streamReader = new StreamReader(path);
                
                //deserialisieren der Xml datei und den zuruckgelieferten Kader im kaderViewModel speichern
                kaderViewModel.TheKader = (Kader)serializer.Deserialize(streamReader);
                kaderViewModel.SpielerListe = kaderViewModel.TheKader.SpielerListe;

                //viewModel mit dem ersten Spieler der Liste initialisieren -> View wird durch Binding geupdatet
                kaderViewModel.CurrentSpieler = kaderViewModel.SpielerListe[0];

                this.DataContext = kaderViewModel;
            }
            catch (IOException)
            {
                MessageBox.Show("Die Datei \"" + fileName + "\" konnte nicht gefunden werden !", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                buttonLast.IsEnabled = false;
                buttonNext.IsEnabled = false;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Die Datei \"" + fileName + "\" konnte nicht geladen werden !", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                buttonLast.IsEnabled = false;
                buttonNext.IsEnabled = false;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                //Application.Current.Shutdown();
                //image.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/no-image-icon.png"));
                
            }
        }


        private void Next(object sender, RoutedEventArgs e)
        {
            //currentSpieler des ViewModel verandern -> View wird durch binding verandert

            kaderViewModel.CurrentSpieler = kaderViewModel.SpielerListe[kaderViewModel.IndexCurrentSpieler + 1];
            this.UpdateButtons();
        }

        private void Last(object sender, RoutedEventArgs e)
        {
            //currentSpieler des ViewModel verandern -> View wird durch binding verandert
            kaderViewModel.CurrentSpieler = kaderViewModel.SpielerListe.Last<Spieler>();
            this.UpdateButtons();
        }

        private void First(object sender, RoutedEventArgs e)
        {
            //currentSpieler des ViewModel verandern -> View wird durch binding verandert
            kaderViewModel.CurrentSpieler = kaderViewModel.SpielerListe.First<Spieler>();
            this.UpdateButtons();
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            //currentSpieler des ViewModel verandern -> View wird durch binding verandert
            kaderViewModel.CurrentSpieler = kaderViewModel.SpielerListe[kaderViewModel.IndexCurrentSpieler - 1];
            this.UpdateButtons();
        }
        
        private void UpdateButtons()
        {
            //Buttons in Bezug auf den Index des Current Spieler enabled oder disabled setzen 

            buttonFirst.IsEnabled = kaderViewModel.IndexCurrentSpieler == 0 ? false : true;
            buttonPrevious.IsEnabled = kaderViewModel.IndexCurrentSpieler == 0 ? false : true;
            buttonLast.IsEnabled = kaderViewModel.IndexCurrentSpieler == kaderViewModel.SpielerListe.Count() - 1 ? false : true;
            buttonNext.IsEnabled = kaderViewModel.IndexCurrentSpieler == kaderViewModel.SpielerListe.Count() - 1 ? false : true;
        }
        

        private void OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
                image.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/no-image-icon.png", UriKind.Relative));
        }

        private void SpielerSelected(object sender, SelectionChangedEventArgs e)
        {
            //wenn ein spieler aus der ComboBox ausgewaehlt wird -> Buttons updaten
            UpdateButtons();
        }
        
    }
}
