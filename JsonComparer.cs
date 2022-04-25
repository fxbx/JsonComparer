using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonComparer
{
    internal static class JsonComparer
    {
        static readonly string JSON_TABS = "  ";

        //https://stackoverflow.com/questions/24876082/find-and-return-json-differences-using-newtonsoft-in-c
        //with modifications
        internal static JObject CreateDiffJson(JToken Current, JToken Model, bool includeMatches)
        {
            var diff = new JObject();
            if (JToken.DeepEquals(Current, Model)) return diff;

            switch (Current.Type)
            {
                case JTokenType.Object:
                    {
                        var current = Current as JObject;
                        var model = Model as JObject;
                        var addedKeys = current.Properties().Select(c => c.Name).Except(model.Properties().Select(c => c.Name));
                        var removedKeys = model.Properties().Select(c => c.Name).Except(current.Properties().Select(c => c.Name));
                        var unchangedKeys = current.Properties().Where(c => JToken.DeepEquals(c.Value, Model[c.Name])).Select(c => c.Name);
                        foreach (var k in addedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["+"] = Current[k]
                            };
                        }
                        foreach (var k in removedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["-"] = Model[k]
                            };
                        }

                        if (includeMatches)
                        {
                            foreach (var k in unchangedKeys)
                            {
                                diff[k] = new JObject
                                {
                                    ["="] = Current[k]
                                };
                            }
                        }

                        var potentiallyModifiedKeys = current.Properties().Select(c => c.Name).Except(addedKeys).Except(unchangedKeys);
                        foreach (var k in potentiallyModifiedKeys)
                        {
                            var foundDiff = CreateDiffJson(current[k], model[k], includeMatches);
                            if (foundDiff.HasValues) diff[k] = foundDiff;
                        }
                    }
                    break;
                case JTokenType.Array:
                    {
                        var current = Current as JArray;
                        var model = Model as JArray;
                        var plus = new JArray(current.Except(model, new JTokenEqualityComparer()));
                        var minus = new JArray(model.Except(current, new JTokenEqualityComparer()));
                        if (plus.HasValues) diff["+"] = plus;
                        if (minus.HasValues) diff["-"] = minus;

                        if (includeMatches)
                        {
                            var same = new JArray(model.SequenceEqual(current, new JTokenEqualityComparer()));
                            if (same.HasValues) diff["="] = same;
                        }

                    }
                    break;
                default:
                    diff["+"] = Current;
                    diff["-"] = Model;
                    break;
            }

            return diff;
        }

        //https://stackoverflow.com/questions/39673815/how-to-recursively-populate-a-treeview-with-json-data
        //with modifications
        internal static void DisplayTreeView(TreeView trvDiff, JToken root, string rootName, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, bool displayChildrenDiffsInResults)
        {
            trvDiff.BeginUpdate();
            try
            {
                trvDiff.Nodes.Clear();
                var tNode = trvDiff.Nodes[trvDiff.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;

                AddNode(root, tNode, "", childrenLeft, childrenRight, "", displayChildrenDiffsInResults);

                trvDiff.ExpandAll();
            }
            finally
            {
                trvDiff.EndUpdate();
            }
        }

        private static void AddNode(JToken token, TreeNode inTreeNode, string parentKey, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, string jPath, bool displayChildrenDiffsInResults)
        {
            if (token == null)
                return;

            if (token is JValue)
            {
                var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                childNode.Tag = token;
            }
            else if (token is JObject)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    string caption = property.Name;
                    string curJPath = jPath;

                    if (!IsSpecialDiffKey(caption))
                        curJPath += "/" + caption;

                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
                    childNode.Tag = property;

                    if (!IsSpecialDiffKey(caption) && displayChildrenDiffsInResults)
                        childNode.Text += " " + ChildCountVersus(childrenLeft, childrenRight, curJPath, true);

                    AddNode(property.Value, childNode, property.Name, childrenLeft, childrenRight, curJPath, displayChildrenDiffsInResults);
                }
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    string caption = i.ToString();
                    string curJPath = jPath + "[" + i + "]";

//                    if (!IsSpecialDiffKey(caption))
//                        curJPath += "/" + caption;

                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(i.ToString()))];
                    childNode.Tag = array[i];
                    if (!IsSpecialDiffKey(caption) && displayChildrenDiffsInResults)
                        childNode.Text += " " + ChildCountVersus(childrenLeft, childrenRight, curJPath, true);

                    AddNode(array[i], childNode, caption, childrenLeft, childrenRight, curJPath, displayChildrenDiffsInResults);
                }
            }
            /*
            else
            {
                Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
            }
            */
        }
    

    private static string OutputArray(JArray a, int level, string key, Dictionary<string, int> childCounter, string curJPath, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, bool isOutputtingDiffResults, bool displayChildrenDiffsInResults)
        {
            string retVal = "";

            int parseTry;

            for (int i = 0; i < a.Count; i++)
            //foreach (var value in a)
            {
                var value = a[i];

                string nuJPath = curJPath + "[" + i + "]";

                if (value is JObject)
                {
                    retVal += OutputLevelTabs(level) + "\"" + key + "\": ";
                    retVal += WriteThisObject(value, level, key, i + 1 != a.Count, childCounter, nuJPath, childrenLeft, childrenRight, isOutputtingDiffResults, displayChildrenDiffsInResults);
                    //retVal += WriteThisObject(value, level, key, i + 1 != a.Count, childCount, jPath, childrenLeft, childrenRight, outputDiff, displayChildrenDiffsInResults);
                }
                else if (value is JArray)
                {
                    retVal += HandleThisJArray((JArray)value, key, isOutputtingDiffResults, displayChildrenDiffsInResults, level, nuJPath, childCounter, childrenLeft, childrenRight);
                }
                else
                {
                    retVal += HandleThisString(value.ToString(), key, i, a.Count(), level);

                    //string szValue = value.ToString();

                    //if (!Int32.TryParse(szValue, out parseTry))
                    //    szValue = "\"" + szValue + "\"";

                    //retVal += LevelTabs(level) + szValue;
                    //if (i + 1 != a.Count)
                    //    retVal += ",";
                    //retVal += "\n";
                }
            }

            return retVal;
        }

        private static string HandleThisString(string szValue, string key, int i, int valuesCount, int level)
        {
            int parseTry;
            string retVal = "";

            if (!Int32.TryParse(szValue, out parseTry))
                szValue = "\"" + szValue + "\"";

            retVal += OutputLevelTabs(level) + "\"" + key + "\": " + szValue;
            if (i + 1 != valuesCount)
                retVal += ",";
            retVal += "\n";

            return retVal;
        }

        private static string HandleThisJArray(JArray a, string key, bool isOutputtingDiffResults, bool displayChildrenDiffsInResults, int presLvl, string curJPath, Dictionary<string, int> childCounter, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight)
        {
            string retVal = "";

            retVal += OutputLevelTabs(presLvl) + "\"" + key + "\": [";

            if (!isOutputtingDiffResults)
            {
                if (displayChildrenDiffsInResults)
                    retVal += " ~" + a.Count + "~";
                childCounter[curJPath] = a.Count;
            }
            else if (!IsSpecialDiffKey(key) && displayChildrenDiffsInResults)
                retVal += " " + ChildCountVersus(childrenLeft, childrenRight, curJPath, false);
            retVal += "\n";
            retVal += OutputArray(a, presLvl, key, childCounter, curJPath, childrenLeft, childrenRight, isOutputtingDiffResults, displayChildrenDiffsInResults);
            retVal += OutputLevelTabs(presLvl) + "]\r\n";

            return retVal;
        }

        private static bool IsSpecialDiffKey(string key)
        {
            return key == "=" || key == "+" || key == "-";
        }

        private static string WriteKidCount(object value, Dictionary<string, int> childCount, string jPath, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, bool outputDiff, bool displayChildrenDiffsInResults)
        {
            if (!displayChildrenDiffsInResults)
                return "";

            JObject o = (JObject)value;
            if (o != null)
            {
                if (!outputDiff)
                {
                    childCount[jPath] = o.Count;
                    return "~" + o.Count + "~";
                }
                else if (displayChildrenDiffsInResults)
                    return ChildCountVersus(childrenLeft, childrenRight, jPath, false);
            }
            return "";
        }

        internal static string ChildCountVersus(Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, string jPath, bool forTreeView)
        {
            if (!childrenLeft.ContainsKey(jPath) && !childrenRight.ContainsKey(jPath))
                return "";

            string left = childrenLeft.ContainsKey(jPath) ? childrenLeft[jPath].ToString() : "";
            string right = childrenRight.ContainsKey(jPath) ? childrenRight[jPath].ToString() : "";

            if (forTreeView)
                return "[" + left + " vs " + right + "]";
            return "~" + left + " vs " + right + "~";
        }

        private static string WriteThisObject(object value, int level, string key, bool isNotLast, Dictionary<string, int> childCount, string jPath, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, bool outputDiff, bool displayChildrenDiffsInResults)
        {
            JObject o = (JObject)value;
            if (o != null)
                return JsonComparer.BeautifyAndStudyJson(o.ToObject<Dictionary<string, object>>(), level + 1, key, o, isNotLast, childCount, jPath, childrenLeft, childrenRight, outputDiff, displayChildrenDiffsInResults);
            return "";
        }

        private static string OutputLevelTabs(int level)
        {
            string retVal = "";

            for (int i = 0; i < level; i++)
                retVal += JSON_TABS;

            return retVal;
        }

        internal static string BeautifyAndStudyJson(Dictionary<string, object> values, int level, string priorKey, object parent, bool notLast, Dictionary<string, int> childCounter, string jPath, Dictionary<string, int> childrenLeft, Dictionary<string, int> childrenRight, bool isOutputtingDiffResults, bool displayChildrenDiffsInResults)
        {
            //this method will always be studying the children of a JObject

            int parseTry;
            string retVal = "";

            retVal += OutputLevelTabs(level) + "{ ";
            if (level != 0 && !IsSpecialDiffKey(priorKey))
                retVal += WriteKidCount(parent, childCounter, jPath, childrenLeft, childrenRight, isOutputtingDiffResults, displayChildrenDiffsInResults);
            retVal += "\n";

            int presLvl = level + 1;

            string[] dictKeys = values.Keys.ToArray();

            for (int i = 0; i < values.Count; i++)
            {
                //foreach (string key in values.Keys)
                //{
                string key = dictKeys[i];
                var value = values[key];

                string curJPath = jPath;

                if (!IsSpecialDiffKey(key))
                    curJPath += "/" + key;

                if (value is JObject)
                {
                    retVal += OutputLevelTabs(presLvl) + "\"" + key + "\": ";
                    retVal += WriteThisObject(value, level, key, i + 1 != values.Count, childCounter, curJPath, childrenLeft, childrenRight, isOutputtingDiffResults, displayChildrenDiffsInResults);
                }
                else if (value is JArray)
                {
                    retVal += HandleThisJArray((JArray)value, key, isOutputtingDiffResults, displayChildrenDiffsInResults, presLvl, curJPath, childCounter, childrenLeft, childrenRight);
                }
                else
                {
                    retVal += HandleThisString(value.ToString(), key, i, values.Count(), presLvl);
                }
            }

            retVal += OutputLevelTabs(level) + "}";
            if (notLast)
                retVal += ",";
            retVal += "\n";

            return retVal;
        }


    }
}
