namespace Indotalent
{
    using System;
    using System.Text;

    public static class StringExtensions
    {
        public static string ToInitial(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
            {
                return string.Empty;
            }
            else if (words.Length == 1)
            {
                return words[0].Substring(0, 1);
            }
            else
            {
                return $"{words[0][0]}{words[1][0]}";
            }
        }

        public static string ToSlug(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return input.ToLower().Replace(' ', '-');
        }

        public static string ToTitle(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            List<string> words = new List<string>();
            StringBuilder currentWord = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    if (currentWord.Length > 0)
                    {
                        words.Add(currentWord.ToString());
                        currentWord.Clear();
                    }
                }
                currentWord.Append(c);
            }

            if (currentWord.Length > 0)
            {
                words.Add(currentWord.ToString());
            }

            return string.Join(" ", words);
        }

        public static string ToCshtmlName(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }

            if (url.Contains("?"))
            {
                url = url.Substring(0, url.IndexOf("?"));
            }
            else if (url.Contains("/"))
            {
                string[] urlParts = url.Split('/');
                string lastPartUrl = urlParts[urlParts.Length - 1];

                if (Guid.TryParse(lastPartUrl, out _))
                {
                    url = url.Substring(0, url.LastIndexOf("/"));
                }
            }

            string[] parts = url.Split('/');
            string title = string.Empty;

            foreach (var item in parts)
            {
                if (item.Contains("List") || item.Contains("Form") || item.Contains("Scheduler") || item.Contains("Kanban"))
                {
                    title = item;
                }
            }

            if (string.IsNullOrEmpty(title))
            {
                title = parts[parts.Length - 1];
            }


            return title.Trim();
        }

        public static string ToPageFolderName(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }

            if (url.Contains("?"))
            {
                url = url.Substring(0, url.IndexOf("?"));
            }

            if (url.Contains("/"))
            {
                string[] urlParts = url.Split('/');
                if (urlParts.Length >= 4)
                {
                    return urlParts[3];
                }
            }

            return string.Empty;
        }

    }
}
