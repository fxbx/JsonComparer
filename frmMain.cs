using Newtonsoft.Json.Linq;

namespace JsonComparer
{
    public partial class frmMain : Form
    {
        JObject jLeft, jRight;

        Dictionary<string, int> childrenLeft, childrenRight;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string inputLeft = this.rtbInputLeft.Text, inputRight = this.rtbInputRight.Text;
            this.btnLevelless.Enabled = false;

            try
            {
                this.jLeft = JObject.Parse(inputLeft);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid JSON input for original.");    
                return;
            }

            try
            {
                this.jRight = JObject.Parse(inputRight);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid JSON input for modified.");
                return;
            }

            this.rtbOutput.Text = "";
            this.rtbLeftMod.Text = "";
            this.rtbRightMod.Text = "";

            Dictionary<string, object> valuesLeft = this.jLeft.ToObject<Dictionary<string, object>>();
            Dictionary<string, object> valuesRight = this.jRight.ToObject<Dictionary<string, object>>();
            this.childrenLeft = new Dictionary<string, int>();
            this.childrenRight = new Dictionary<string, int>();

            string szJsonLeft = JsonComparer.BeautifyAndStudyJson(valuesLeft, 0, "", null, false, childrenLeft, "", null, null, false, this.chkChildrenCompare.Checked);
            this.rtbLeftMod.Text = szJsonLeft;

            string szJsonRight = JsonComparer.BeautifyAndStudyJson(valuesRight, 0, "", null, false, childrenRight, "", null, null, false, this.chkChildrenCompare.Checked);
            this.rtbRightMod.Text = szJsonRight;

            JObject differ = JsonComparer.CreateDiffJson(jLeft, jRight, this.chkIncludeMatches.Checked);

            if (differ != null) //CreateDiffJson never returns null but safety first
            {
                this.rtbOutput.Text += JsonComparer.BeautifyAndStudyJson(differ.ToObject<Dictionary<string, object>>(), 0, "", null, false, childrenRight, "", childrenLeft, childrenRight, true, this.chkChildrenCompare.Checked);
                JsonComparer.DisplayTreeView(this.trvDiff, differ, "(root)", childrenLeft, childrenRight, this.chkChildrenCompare.Checked);
                this.btnLevelless.Enabled = true;
            }
            else
            {
                MessageBox.Show("Failed to compute JSON difference.");
            }
        }

        private void btnLevelless_Click(object sender, EventArgs e)
        {
            //in the event a JArray is found, assumes the first element is the location of anything to be compared [0]
            //in the future, all combinations might be checked and offered if anything mismatches?
            frmLevellessCompare frmFreeCompare = new frmLevellessCompare();

            frmFreeCompare.childrenLeft = this.childrenLeft;
            frmFreeCompare.childrenRight = this.childrenRight;
            frmFreeCompare.jLeft = this.jLeft;
            frmFreeCompare.jRight = this.jRight;

            frmFreeCompare.ShowDialog();
        }
    }
}