using Ganss.Xss;
using System.Text;

namespace AntiXSSDemo
{
    public class AntiXssMiddleWare
    {
        private readonly RequestDelegate _next;

        public AntiXssMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // enable buffering so that the request can be read by the model binders next
            context.Request.EnableBuffering();

            // leaveOpen: true to leave the stream open after disposing,
            // so it can be read by the model binders
            using (StreamReader sr = new(context.Request.Body, Encoding.UTF8, leaveOpen: true))
            {
                string? raw = await sr.ReadToEndAsync();
                HtmlSanitizer sanitizer = new();
                string sanitized = sanitizer.Sanitize(raw);

                if (raw != sanitized)
                {
                    throw new BadHttpRequestException("XSS injection detected from middleware.");
                }
            }

            // rewind the stream for the next middleware
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            await _next.Invoke(context);
        }
    }
}