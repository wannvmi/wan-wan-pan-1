using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanWan.Pan.App.Contracts.Services
{
    public interface IApplicationInfoService
    {
        Version GetVersion();
    }
}
