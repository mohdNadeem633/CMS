namespace CMS_CollegeManageSystem_.ViewModel
{
    public class SortingLogics
    {
        public bool IsAlphanumericClass(string className)
        {
            return className.Any(char.IsLetter);
        }
        public int ExtractNumericValue(string className)
        {

            string cleanedClassName = RemoveOrdinalSuffix(className);

            string numericPart = new string(cleanedClassName.Where(char.IsDigit).ToArray());

            return string.IsNullOrEmpty(numericPart) ? 0 : int.Parse(numericPart);
        }

        public string ExtractAlphabeticPart(string className)
        {
            return new string(className.Where(char.IsLetter).ToArray());
        }

        public string RemoveOrdinalSuffix(string className)
        {
            if (className.Length > 2)
            {
                string suffix = className.Substring(className.Length - 2);
                if (suffix == "st" || suffix == "nd" || suffix == "rd" || suffix == "th")
                {
                    return className.Substring(0, className.Length - 2);
                }
            }

            return className;
        }
    }
}
