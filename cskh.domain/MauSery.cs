using System;

namespace cskh.domain
{
    public class MauSery
    {
        #region properties
        public string MAKIHIEU { get; set; }
        public string MAU_SERY { get; set; }
        public string TENKIHIEU { get; set; }
        public bool SUDUNG { get; set; }
        public string SERY_DAU { get; set; }
        public string SERY_CUOI { get; set; }
        public string SERY_GANNHAT { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public string NGUOI_TAO { get; set; }
        public string NGAY_SUA { get; set; }
        public string NGUOI_SUA { get; set; }
        #endregion 

        #region constructor
        public MauSery(string mau, string kihieu, string tenkihieu, string serydau, string serycuoi, string nguoitao, DateTime ngaytao, bool sudung)
        {
            MAU_SERY = mau;
            MAKIHIEU = kihieu;
            TENKIHIEU = tenkihieu;
            SERY_DAU = serydau;
            SERY_CUOI = serycuoi;
            NGUOI_TAO = nguoitao;
            NGAY_TAO = ngaytao;
            SUDUNG = sudung;
        }
        #endregion constructor
    }
}
