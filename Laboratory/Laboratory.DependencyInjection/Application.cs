using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DependencyInjection
{
    public class Application
    {
        private readonly IConfiguration _config;
        public Application(IConfiguration config)
        {
            _config = config;
        }

        public void Run()
        {
            
        }
    }
}
