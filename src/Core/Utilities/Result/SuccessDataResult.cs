using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        /// <summary>
        /// Başarılı işlem mesajı
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
            
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
