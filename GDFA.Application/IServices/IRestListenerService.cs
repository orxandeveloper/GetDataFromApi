using GDFA.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDFA.Application.IServices
{
   public interface IRestListenerService
    {
        Task<Post> PostAsync();
    }
}
