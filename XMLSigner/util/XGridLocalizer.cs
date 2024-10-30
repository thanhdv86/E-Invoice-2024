using cskh.domain;
using DevExpress.XtraGrid.Localization;

namespace XMLSigner.util
{
    public class XGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            // find panel
            if (id == GridStringId.FindControlFindButton)
                return Constants.FIND_PANEL_FIND;
            if (id == GridStringId.FindControlClearButton)
                return Constants.FIND_PANEL_CLEAR;
            if (id == GridStringId.FindNullPrompt)
                return Constants.FindNullPrompt;

            // edit form
            if (id == GridStringId.EditFormUpdateButton)
                return Constants.UPDATE_VN;
            if (id == GridStringId.EditFormCancelButton)
                return Constants.CANCEL_VN;


            if (id == GridStringId.GridGroupPanelText)
                return Constants.GridGroupPanelText;
            return base.GetLocalizedString(id);
        }
    }
}
