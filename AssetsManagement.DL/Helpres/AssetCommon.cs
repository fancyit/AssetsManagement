namespace AssetsManagement.DL.Helpres
{
    public static class AssetCommon
    {
        /// <summary>
        /// Merge two objects except Id prop
        /// </summary>
        /// <typeparam name="T"> Type </typeparam>
        /// <param name="s"> source obj </param>
        /// <param name="t"> obj to update</param>
        public static void MergeEntries<T>(ref T t, T s)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.GetValue(s) != null && prop.Name != "Id")
                {
                    prop.SetValue(t, prop.GetValue(s));

                }
            }
        }
    }
}
