namespace Service.Services
{
    public interface IReplace
    {
        public Task<string> GetResponseFromUrl(string url);
        public string[] SplitArray(string input);
        public Tuple<int, int> GetBodyIndexes(string[] arrStr);
        public string Replace(string[] arrInput, Tuple<int, int> bordersBody);
    }
}
