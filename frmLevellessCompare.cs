using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.RegularExpressions;

namespace JsonComparer
{
    public partial class frmLevellessCompare : Form
    {
        internal Dictionary<string, int> childrenLeft, childrenRight;
        internal JObject jLeft, jRight;

        public frmLevellessCompare()
        {
            InitializeComponent();
        }

        internal void PopulateList()
        {
            Dictionary<string, string> leftFlat = new Dictionary<string, string>(), rightFlat = new Dictionary<string, string>();
            List<string> versus = new List<string>();

            foreach (string key in childrenLeft.Keys)
            {
                if (OnlyZeroes(key))
                {
                    string szLast = key.Split('/').Last();
                    leftFlat[szLast] = key;
                }
            }

            foreach (string key in childrenRight.Keys)
            {
                if (OnlyZeroes(key))
                {
                    string szLast = key.Split('/').Last();
                    rightFlat[szLast] = key;
                }
            }

            foreach (string key in leftFlat.Keys)
            {
                if (rightFlat.ContainsKey(key) && leftFlat[key] != rightFlat[key])
                    versus.Add(key);
            }

            foreach (string match in versus)
            {
                ListViewItem lvi = new ListViewItem(match);
                string jPathNewtonleft = ConvertToNewtonQuery(leftFlat[match]);
                string jPathNewtonRight = ConvertToNewtonQuery(rightFlat[match]);

                lvi.Tag = new LevellessCompare(leftFlat[match], rightFlat[match], jLeft.SelectToken(jPathNewtonleft), jRight.SelectToken(jPathNewtonRight));
                this.lstCompares.Items.Add(lvi);
            }

            this.lstCompares.DisplayMember = "Text";
            this.lstCompares.ValueMember = "Tag";
        }

        //Adaptation of https://stackoverflow.com/questions/12108582/extracting-string-between-two-characters
        private bool OnlyZeroes(string key)
        {
            if (!key.Contains("["))
                return true;

            List<string> numbersFound = Regex.Matches(key, @"\[(.+?)\]")
                                    .Cast<Match>()
                                    .Select(m => m.Groups[1].Value).ToList();

            return numbersFound.Count > 0 && numbersFound.All(a => a == "0");
        }

        private string ConvertToNewtonQuery(string myPath)
        {
            return myPath.Replace("/", ".").Substring(1);
        }

        private void frmLevellessCompare_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void lstCompares_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCompares.SelectedItem != null)
            {
                ListViewItem lvi = lstCompares.SelectedItem as ListViewItem;
                LevellessCompare lc = (LevellessCompare)lvi.Tag;
                DisplayThisCompare(lc);
            }
        }

        private void DisplayThisCompare(LevellessCompare lc)
        {
            this.txtOrigPath.Text = lc.leftPath;
            this.txtModPath.Text = lc.rightPath;

            JObject left = new JObject(), right = new JObject();

            if (lc.left is JObject)
                left = (JObject)lc.left;
            else if (lc.left is JArray)
                left.Add("(root)", (JArray)lc.left);

            if (lc.right is JObject)
                right = (JObject)lc.right;
            else if (lc.right is JArray)
                right.Add("(root)", (JArray)lc.right);

            Dictionary<string, object> valuesLeft = new Dictionary<string, object>(), valuesRight = new Dictionary<string, object>();

            if (left != null)
                valuesLeft = left.ToObject<Dictionary<string, object>>();
            if (right != null)
                valuesRight = right.ToObject<Dictionary<string, object>>();

            Dictionary<string, int> childrenLeft = new Dictionary<string, int>();
            Dictionary<string, int> childrenRight = new Dictionary<string, int>();

            JsonComparer.BeautifyAndStudyJson(valuesLeft, 0, "", null, false, childrenLeft, "", null, null, false, true);
            JsonComparer.BeautifyAndStudyJson(valuesRight, 0, "", null, false, childrenRight, "", null, null, false, true);
            JObject differ = JsonComparer.CreateDiffJson(left, right, true);

            if (differ != null)
            {
                this.rtbRes.Text += JsonComparer.BeautifyAndStudyJson(differ.ToObject<Dictionary<string, object>>(), 0, "", null, false, childrenRight, "", childrenLeft, childrenRight, true, true);
                JsonComparer.DisplayTreeView(this.trvDiff, differ, "(root)", childrenLeft, childrenRight, true);
            }
        }
    }
}