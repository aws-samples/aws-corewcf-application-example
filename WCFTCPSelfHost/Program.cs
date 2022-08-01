
using CoreWCF.Configuration;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace WCFTCPSelfHost
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Starting WCF service");
			
			IWebHost host = CreateWebHostBuilder(args).Build();
			
      host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		  WebHost.CreateDefaultBuilder(args)
					 .UseKestrel(options =>
					 {
					 options.ListenAnyIP(8443);
					 }).UseStartup<Startup>();
		
	}
}


      