using System;

namespace SearchAPI.DAL.Exceptions
{
    public class SearchFilterNotExistException : Exception
    {
        public SearchFilterNotExistException() : base()
        {
            
        }
        
        public SearchFilterNotExistException(string message) : base(message)
        {
            
        }
    }

}
