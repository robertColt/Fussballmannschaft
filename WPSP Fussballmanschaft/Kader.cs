
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WPSP_Fussballmanschaft
{
    [XmlRoot("Kader")]
    public class Kader
    {
        [XmlArray("SpielerListe")]
        [XmlArrayItem("Spieler")]
        public List<Spieler> SpielerListe { set; get; }

    }
}
