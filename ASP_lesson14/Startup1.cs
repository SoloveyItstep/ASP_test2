using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ASP_lesson14.Startup1))]

namespace ASP_lesson14
{
    public class Startup1
    {
        private const string htmlText = "<html>" +
                                            "<head>" +
                                                "<title>Hello OWIN</title>" +
                                            "</head>" +
                                            "<body>" +
                                                "<h1>Simple Owin Application<h1>" +
                                            "</body>" +
                                        "</html>";
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/Welcome");
            app.Run(context =>
            {
                context.Response.ContentType = "text/html";
                return context.Response.WriteAsync(htmlText);
            });
            
        }
    }
}
