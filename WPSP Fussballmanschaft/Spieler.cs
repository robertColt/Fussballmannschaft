
using System.Xml.Serialization;
using System.ComponentModel;

namespace WPSP_Fussballmanschaft
{
    
    public class Spieler : INotifyPropertyChanged
    {
        [XmlElement("Name")]
        public string Name { set; get; }

        [XmlElement("Vorname")]
        public string Vorname { set; get; }

        [XmlElement("Position")]
        public string Position { set; get; }

        [XmlElement("Rueckennummer")]
        public int Rueckennummer { set; get; }

        [XmlElement("Seit")]
        public string Seit { set; get; }

        [XmlElement("GeburtsDatum")]
        public string GeburtsDatum { set; get; }

        [XmlElement("GroesseInCm")]
        public int GroesseInCm { set; get; }

        [XmlElement("GewichtInKg")]
        public int GewichtInKg { set; get; }

        [XmlElement("SpieleInBundesliga")]
        public int SpieleInBundesliga { set; get; }

        [XmlElement("ToreInBundesliga")]
        public int ToreInBundesliga { set; get; }

        [XmlElement("Nation")]
        public string Nation { set; get; }

        [XmlElement("Laenderspiele")]
        public int Laenderspiele { set; get; }


        public Spieler()
        {
    
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
            }
        }

        
        public override string ToString()
        {
            return Name + " " + Vorname;
        }

    }
}
