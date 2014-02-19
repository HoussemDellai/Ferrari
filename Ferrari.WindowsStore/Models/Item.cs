using System;
using Newtonsoft.Json;
using SQLite;

namespace Ferrari.Models
{
    public class Item //: IItem
    {

        private string _description;
        private string _textNews;
        public string Title
        {
            get;
            set;
        }

        public String Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = GetAndRemoveHtmlSpecialCaracters(value);
            }
        }

        public String Link
        {
            get;
            set;
        }

        public String TextNews
        {
            get
            {
                return _textNews;
            }
            set
            {
                _textNews = GetAndRemoveHtmlSpecialCaracters(value);
            }
        }

        public string Category
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string ImageThumbnailUrl
        {
            get;
            set;
        }

        public DateTime PublishDate
        {
            get;
            set;
        }

        [JsonIgnore]
        public String PublishDateString
        {
            get
            {
                //if (PublishDate != null)
                //{
                //    return PublishDate.ToString();
                //}

                return "Mon, 05 Mar 2012 10:00:00 GMT";//new DateTime(2014, 2, 4, 8, 0, 0).ToString();
            }
        }

        [PrimaryKey, AutoIncrement]
        public int ItemId
        {
            get;
            set;
        }

        private String GetAndRemoveHtmlSpecialCaracters(String str)
        {
            if (string.IsNullOrEmpty(str))
                return String.Empty;

            while (str.Contains("&eacute;"))
            {
                str = str.Replace("&eacute;", "é");
            }
            while (str.Contains("&egrave;"))
            {
                str = str.Replace("&egrave;", "è");
            }
            while (str.Contains("&agrave;"))
            {
                str = str.Replace("&agrave;", "à");
            }
            while (str.Contains("&quot;"))
            {
                str = str.Replace("&quot;", "\"");
            }
            while (str.Contains("&rsquo;"))
            {
                str = str.Replace("&rsquo;", "’");
            }
            while (str.Contains("&lsquo;"))
            {
                str = str.Replace("&lsquo;", "‘");
            }
            while (str.Contains("&laquo;"))
            {
                str = str.Replace("&laquo;", "«");
            }
            while (str.Contains("&raquo;"))
            {
                str = str.Replace("&raquo;", "»");
            }
            while (str.Contains("&amp;"))
            {
                str = str.Replace("&amp;", "&");
            }
            while (str.Contains("&euro;"))
            {
                str = str.Replace("&euro;", "€");
            }
            while (str.Contains("&ugrave;"))
            {
                str = str.Replace("&ugrave;", "ù");
            }
            while (str.Contains("&ucirc;"))
            {
                str = str.Replace("&ucirc;", "û");
            }
            while (str.Contains("&ecirc;"))
            {
                str = str.Replace("&ecirc;", "ê");
            }
            while (str.Contains("&acirc;"))
            {
                str = str.Replace("&acirc;", "â");
            }
            while (str.Contains("<p>"))
            {
                str = str.Replace("<p>", "");
            }
            while (str.Contains("</p>"))
            {
                str = str.Replace("</p>", "");
            }
            while (str.Contains("<br/>"))
            {
                str = str.Replace("<br/>", "");
            }
            while (str.Contains("<br />"))
            {
                str = str.Replace("<br />", "");
            }
            while (str.Contains("<strong>"))
            {
                str = str.Replace("<strong>", "");
            }
            while (str.Contains("</strong>"))
            {
                str = str.Replace("</strong>", "");
            }
            while (str.Contains("<BR>"))
            {
                str = str.Replace("<BR>", "");
            }
            while (str.Contains("<STRONG>"))
            {
                str = str.Replace("<STRONG>", "");
            }
            while (str.Contains("</STRONG>"))
            {
                str = str.Replace("</STRONG>", "");
            }
            while (str.Contains("<P>"))
            {
                str = str.Replace("<P>", "");
            }
            while (str.Contains("</P>"))
            {
                str = str.Replace("</P>", "");
            }
            while (str.Contains("<EM>"))
            {
                str = str.Replace("<EM>", "");
            }
            while (str.Contains("</EM>"))
            {
                str = str.Replace("</EM>", "");
            }

            return str;
        }
    }
}
