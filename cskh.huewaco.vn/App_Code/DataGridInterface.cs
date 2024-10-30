using System;
using System.Drawing;

namespace cskh.huewaco.vn
{
    public class DataGridInterface
    {
        public DataGridInterface()
        {
        }
        public string NumToHex(int num)
        {
            string[] sign = { "A", "B", "C", "D", "E", "F" };
            return ((num > 9) ? sign[num - 10] : num.ToString());
        }
        public string DecToHex(int num)
        {
            return ((num < 16) ? NumToHex(num) : DecToHex(num / 16) + NumToHex(num % 16));
        }
        public string GetColorString(Color c)
        {
            int _r, _g, _b;
            _r = int.Parse(c.R.ToString());
            _g = int.Parse(c.G.ToString());
            _b = int.Parse(c.B.ToString());
            string _color = "#";
            _color += ((_r == 0) ? "00" : DecToHex(_r));
            _color += ((_g == 0) ? "00" : DecToHex(_g));
            _color += ((_b == 0) ? "00" : DecToHex(_b));
            return _color;
        }
        public void GetOutOverColor(System.Web.UI.WebControls.DataGrid dg, System.Web.UI.Page p, string c)
        {
            //if (!p.IsClientScriptBlockRegistered("ME"))
            //{
            //    string script = "\n <script>";
            //    script += "\n function ChangeColor(oRow, myCol){oRow.style.backgroundColor=myCol;}";
            //    script += "\n </script>";
            //    p.RegisterClientScriptBlock("ME", script);
            //}
            for (int i = 0; i < dg.Items.Count; i++)
            {
                string s;
                if (i % 2 != 0)
                {
                    s = GetColorString(dg.AlternatingItemStyle.BackColor);
                    if (s == "#000000" || s == "#FFFFFF") s = GetColorString(dg.ItemStyle.BackColor);
                }
                else
                    s = GetColorString(dg.ItemStyle.BackColor);
                if (s == "#000000" || s == "#FFFFFF") s = dg.Style["background-color"];
                //Da lay xong mau nen ban dau cua giao dien DataGrid
                dg.Items[i].Attributes.Add("onmouseover", "ChangeColor(this, '#" + c.ToString() + "')");
                dg.Items[i].Attributes.Add("onmouseout", "ChangeColor(this, '" + s + "')");
            }
        }
        //public void SelectRows(System.Web.UI.WebControls.DataGridItem dgitem, string sUrl, string sStyle, string SetOfColumn, System.Web.UI.Page p)
        //{
        //    if (!p.IsClientScriptBlockRegistered("My"))
        //    {
        //        string script = "\n <script>";
        //        script += "\n function openWin(aURL, sOptions){";
        //        script += " \n   if (typeof(sOptions)=='undefined')";
        //        script += " var sOptions =	'Left=150,Top=70,Width=550,height=400';";
        //        script += " open(aURL, '', sOptions); }";
        //        script += "\n </script>";
        //        p.RegisterClientScriptBlock("My", script);
        //    }
        //    string[] Colum = SetOfColumn.Split(',');
        //    for (int i = 0; i < Colum.Length; i++)
        //    {
        //        if (Convert.ToInt32(Colum[i]) < dgitem.Cells.Count)
        //        {
        //            dgitem.Cells[Convert.ToInt32(Colum[i])].Attributes.Add("onclick", "openWin('" + sUrl + "', '" + sStyle + "');");
        //            dgitem.Cells[Convert.ToInt32(Colum[i])].Style.Add("cursor", "hand");
        //        }
        //    }
        //}
        //public void SelectRows2(System.Web.UI.WebControls.DataGridItem dgitem, string sUrl, string sStyle, System.Web.UI.Page p)
        //{
        //    if (!p.IsClientScriptBlockRegistered("My"))
        //    {
        //        string script = "\n <script>";
        //        script += "\n function openWin(aURL, sOptions){";
        //        script += " \n   if (typeof(sOptions)=='undefined')";
        //        script += " var sOptions =	'Left=150,Top=70,Width=550,height=400';";
        //        script += " open(aURL, '', sOptions); }";
        //        script += "\n </script>";
        //        p.RegisterClientScriptBlock("My", script);
        //    }
        //    for (int j = 1; j < 4; j++)
        //    {
        //        dgitem.Cells[j].Attributes.Add("onclick", "openWin('" + sUrl + "', '" + sStyle + "');");
        //        dgitem.Cells[j].Style.Add("cursor", "hand");
        //    }
        //}
    }
}