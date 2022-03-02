using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,string message,bool success):base(message,success) 
        {
            this.Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            this.Data = data;
        }
        public T Data { get; }
    }
}
