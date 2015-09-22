using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using System.IO;
using System.Diagnostics.Contracts;

[assembly: OwinStartup(typeof(HtmlSelfHostKatana.Startup1))]

namespace HtmlSelfHostKatana
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(GetRootDirectory()),
                EnableDirectoryBrowsing = true,
                RequestPath = new Microsoft.Owin.PathString("/html")
            });

            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(GetScriptsDirectory()),
                EnableDirectoryBrowsing = true,
                RequestPath = new Microsoft.Owin.PathString("/scripts")
            });
        }
        private static string GetRootDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = Directory.GetParent(currentDirectory).Parent;
            Contract.Assume(rootDirectory != null);
            return Path.Combine(rootDirectory.FullName, "Content");
        }
        private static string GetScriptsDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = Directory.GetParent(currentDirectory).Parent;
            Contract.Assume(rootDirectory != null);
            return Path.Combine(rootDirectory.FullName, "Scripts");
        }

    }
}
