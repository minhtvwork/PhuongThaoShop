
namespace PTS.Base.Application.Utilities
{
    public static class StringUtility
    {

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static string[] VietnameseSigns = new string[]
       {

       "aAeEoOuUiIdDyY",

       "áàạảãâấầậẩẫăắằặẳẵ",

       "ÁÀẠẢÃ ẤẦẬẨẪĂẮẰẶẲẴ",

       "éèẹẻẽêếềệểễ",

       "ÉÈẸẺẼÊẾỀỆỂỄ",

       "óòọỏõôốồộổỗơớờợởỡ",

       "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

       "úùụủũưứừựửữ",

       "ÚÙỤỦŨƯỨỪỰỬỮ",

       "íìịỉĩ",

       "ÍÌỊỈĨ",

       "đ",

       "Đ",

       "ýỳỵỷỹ",

       "ÝỲỴỶỸ"
       };
        public static string RemoveSign4VietnameseString(string str, bool toLower = false)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            if (toLower)
            {
                return str.ToLower();
            }
            else
            {
                return str;
            }

        }


    }
}
