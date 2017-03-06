using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var parameter = txtInput.Text;

            if (string.IsNullOrEmpty(parameter))
            {
                txtResult.Text = "Paramater has not a valid value!";
                return;
            }

            var c = GetFirstNonRepeatingCharacterIfAny(parameter);

            if (!c.HasValue)
            {
                txtResult.Text = "Unable to find any non repeating character!";
                return;
            }

            txtResult.Text = c.Value.ToString();
        }

        private static char? GetFirstNonRepeatingCharacterIfAny(string parameter)
        {
            var mappings = FindCharactersAndCount(parameter);
            var resultMaybe = mappings.Where(kvp => kvp.Value == 1).FirstOrDefault();
            return resultMaybe.Value == 1 ? resultMaybe.Key : default(char?);
        }

        private static Dictionary<char, int> FindCharactersAndCount(string parameter)
        {
            var result = new Dictionary<char, int>();
            foreach (var c in parameter)
            {
                if (result.ContainsKey(c))
                {
                    result[c] += result[c] + 1;
                }
                else
                {
                    result[c] = 1;
                }
            }

            return result;
        }
    }
}
