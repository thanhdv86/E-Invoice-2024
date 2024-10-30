using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public class Survey
    {
        #region Operator
        private int intSurveyID;
        private DateTime datDateStart;
        private DateTime datDateEnd;

        #endregion
        #region Property
        public int SurveyID
        {
            get { return intSurveyID; }
            set { intSurveyID = value; }
        }

        public string SurveyName { get; set; }

        public string SurveyDescription { get; set; }

        public DateTime DateStart
        {
            get { return datDateStart; }
            set { datDateStart = value; }
        }
        public DateTime DateEnd
        {
            get { return datDateEnd; }
            set { datDateEnd = value; }
        }

        public bool Finish { get; set; }

        public bool Public { get; set; }

        public bool Lock { get; set; }

        public int ParentID { get; set; }

        #endregion
        public Survey(int _intSurveyID)
        {
            intSurveyID = _intSurveyID;
            using (var obj = new EiBusinessImpl())
            {
                IDataReader dr = obj.GetSurveyInfor(intSurveyID);
                if (dr.Read())
                {
                    SurveyName = dr["strSurveyName"].ToString();
                    SurveyDescription = dr["strSurveyDescription"].ToString();
                    datDateStart = Convert.ToDateTime(dr["datDateStart"]);
                    datDateEnd = Convert.ToDateTime(dr["datDateEnd"]);
                    Finish = Convert.ToBoolean(dr["bitFinish"]);
                    Public = Convert.ToBoolean(dr["bitPublic"]);
                    Lock = Convert.ToBoolean(dr["bitLock"]);
                    //intParentID = Convert.ToInt32(dr["intParentID"]);
                }
            }
        }
    }
}