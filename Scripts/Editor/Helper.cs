namespace DividerHierarchyExtension
{
    internal static class Helper
    {
        public static bool IsDivider(string name)
        {
            return name.StartsWith(HierarchyExtension.Prefix) && name.EndsWith(HierarchyExtension.Suffix);
        }

        public static string RemoveDecoration(string s)
        {
            s = s.Replace(HierarchyExtension.Prefix, string.Empty);
            s = s.Replace(HierarchyExtension.Suffix, string.Empty);

            return s;
        }

        public static string AddDecoration(string s)
        {
            return $"{HierarchyExtension.Prefix}{s}{HierarchyExtension.Suffix}";
        }
    }
}