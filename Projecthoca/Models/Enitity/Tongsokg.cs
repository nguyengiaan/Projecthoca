﻿namespace Projecthoca.Models.Enitity
{
    public class Tongsokg
    {
        public int Ma_tongsokg { get; set; }
        public float sokg { get; set; }
        public List<Chitietlancau> Chitietlancaus { get; set; }
        public Thuehoca Thuehoca { get; set; }
        public string Ma_thuehoca { get; set; }
        public Tongsokg()
        {
           
            Chitietlancaus = new List<Chitietlancau>();
        }
    }
}
