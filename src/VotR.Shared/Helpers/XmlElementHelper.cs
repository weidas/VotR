using System;
using System.Xml.Linq;

namespace VotR.Shared.Helpers
{
    public static class XmlElementHelper
    {
        public static T CheckIfElementIsNull<T>(this XElement element)
        {
            if (element == null)
                return default(T);

            else
                return (T)Convert.ChangeType(element.Value, typeof(T));
        }
    }
}
