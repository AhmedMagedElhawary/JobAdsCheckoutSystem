using System;

namespace JobAdsCheckoutSystemWeb.Areas.HelpPage
{
    /// <summary>
    /// This represents an invalId sample on the help page. There's a display template named InvalIdSample associated with this class.
    /// </summary>
    public class InvalIdSample
    {
        public InvalIdSample(string errorMessage)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }

        public overrIde bool Equals(object obj)
        {
            InvalIdSample other = obj as InvalIdSample;
            return other != null && ErrorMessage == other.ErrorMessage;
        }

        public overrIde int GetHashId()
        {
            return ErrorMessage.GetHashId();
        }

        public overrIde string ToString()
        {
            return ErrorMessage;
        }
    }
}