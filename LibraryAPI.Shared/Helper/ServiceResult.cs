using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Shared.Helper
{
  public class ServiceResult
  {
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public Exception Exception { get; set; }

    public static ServiceResult Success { get; } = new ServiceResult { Succeeded = true };

    public static ServiceResult Error(string message)
    {
      return new ServiceResult { Succeeded = false, Message = message };
    }
  }
}
