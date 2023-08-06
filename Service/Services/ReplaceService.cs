using Service.Model;
using System.Text.RegularExpressions;

namespace Service.Services
{
    public class ReplaceService : IReplace
    {
        public async Task<string> GetResponseFromUrl(string url)
        {
            string res;

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    res = apiResponse;
                }
            }
            return res;
        }

        public string[] SplitArray(string input)
        {
            string myString = Regex.Replace(input, @"\s+", " ");

            string[] arrStr = myString.Split(' ');

            return arrStr;
        }

        public Tuple<int, int> GetBodyIndexes(string[] arrStr)
        {
            int startIndex = default;
            int endIndex = default;

            for (int i = 0; i < arrStr.Length; i++)
            {
                if (arrStr[i] == "<body>")
                {
                    startIndex = i;
                }

                if (arrStr[i] == "</body>")
                {
                    endIndex = i;
                }
            }

            return new Tuple<int, int>(startIndex, endIndex);
        }

        public string Replace(string[] arrInput, Tuple<int, int> bordersBody)
        {
            for (int i = 0; i < arrInput.Length; i++)
            {
                if (RegexModel.SixCharLenght.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] += "™";
                }

                if (RegexModel.EndComma.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] = arrInput[i].Replace(",", "™,");
                }

                if (RegexModel.EndPeriod.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] = arrInput[i].Replace(".", "™.");
                }

                if (RegexModel.EndQuerryMark.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] = arrInput[i].Replace("?", "™?");
                }

                if (RegexModel.EndExlemationMark.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] = arrInput[i].Replace("!", "™!");
                }

                if (RegexModel.EndColon.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] = arrInput[i].Replace(":", "™:");
                }

                if (RegexModel.EndSemiColon.IsMatch(arrInput[i]) && i > bordersBody.Item1 && i < bordersBody.Item2)
                {
                    arrInput[i] = arrInput[i].Replace(";", "™;");
                }
            }

            string result = string.Join(" ", arrInput);

            return result;
        }
    }
}