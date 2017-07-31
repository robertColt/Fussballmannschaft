using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPSP_Fussballmanschaft
{ 
    class KaderViewModel : INotifyPropertyChanged
    {
        
        private Spieler currentSpieler;

        //Zusammensetzen der Properties eines Spielers : Spiele in Bundesliga und Tore in Bundesliga
        //Dient zur Darstellung im View
        public string SpieleToreBundesliga
        {
            get
            {
                return currentSpieler.SpieleInBundesliga + "/" + currentSpieler.ToreInBundesliga;
            }
        }

        //Spielerliste des Kaders, dient zur Vereinfachung in dem View
        public List<Spieler> SpielerListe {get;set;}

        //der Kader
        public Kader TheKader { get; set; }

        //Property fuer den current Spieler
        //wenn der Spieler sich andert, dann wird die View auch benachrichtigt
        public Spieler CurrentSpieler
        {
            get
            {
                return currentSpieler;
            }
            set
            {
                currentSpieler = value;
                //informiere die View das sich der Spieler verandert hat
                OnPropertyChanged("CurrentSpieler");

                //wenn der currentSpieler verandert wird dann soll sich auch die Image im View verandert werden
                OnPropertyChanged("ImageSource");

                //auch SpieleToreBundesliga in der View verandern
                OnPropertyChanged("SpieleToreBundesliga");
            }
        }
        
        public string ImageSource
        {
            get
            {
                //Pfad des Bildes das entsprechend des Namens des Spielers ausgewaehlt wird
                return String.Format("pack://application:,,,/VfB Stuttgart/{0} {1}.jpg" ,currentSpieler.Name,currentSpieler.Vorname);
            }
        }

        //liefert den index des current Spielers zuruck
        public int IndexCurrentSpieler {
            get
            {
                return SpielerListe.IndexOf(currentSpieler);
            }
        }

        public KaderViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
