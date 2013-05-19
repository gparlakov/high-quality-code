using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace FreeContent
{
    public class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> url;
        private readonly OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title]
                                                  select c;
            var listToReturn = contentToList.Take(numberOfContentElementsToList);
            return listToReturn;
        }

        public int UpdateContent(string old, string newUrl)
        {
            if (string.IsNullOrWhiteSpace(old) || string.IsNullOrWhiteSpace(newUrl))
            {
                throw new ArgumentException("URL can't be empty string or null");
            }

            int theElements = 0;

            List<IContent> contentToList = this.url[old].ToList();

            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++; //increase updatedElements
            }
            this.url.Remove(old);

            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            //again
            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }
}