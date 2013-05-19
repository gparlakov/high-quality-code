using System;

namespace FreeContent
{
    public class Content : IComparable, IContent
    {
        private string title;

        private string author;

        private long size;

        private string url;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ParamsIndex.Title];
            this.Author = commandParams[(int)ParamsIndex.Author];
            this.Size = Int64.Parse(commandParams[(int)ParamsIndex.Size]);
            this.URL = commandParams[(int)ParamsIndex.Url];
        }

        #region Properties

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 1000)
                {
                    throw new ArgumentException(
                        "Title of content must be 1 to 1000 chars long and can't be null");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 1000)
                {
                    throw new ArgumentException(
                        "Author of content must be 1 to 1000 chars long and can't be null");
                }
                this.author = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0 || value > 10000000000)
                {
                    throw new ArgumentException(
                        "Size of content can't be negative or larger than 10000000000");
                }
                
                this.size = value;
            }
        }

        public ContentType Type { get; set; }

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("URL of content can't be null or empty string.");
                }
                this.url = value;
            }
        }

        public string TextRepresentation 
        { 
            get
            {
                return this.ToString();   
            }
            set
            {
                this.TextRepresentation = value;
            }
        }

        #endregion

        #region Public Methods
        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }
              
            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
        #endregion
    }
}