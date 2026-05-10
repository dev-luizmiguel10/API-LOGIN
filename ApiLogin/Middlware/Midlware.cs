using System.Globalization;

namespace ApiLogin.Middlware
{
    public class Midlware
    {
        private readonly RequestDelegate _delegate;
        public Midlware(RequestDelegate ddl)
        {
            _delegate= ddl;
        }
        public async Task Invoke(HttpContext context)
        {
            var cultura_suportada = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cultura_enviada = context.Request.Headers.AcceptLanguage.SingleOrDefault();
            var cultura_padrao = new CultureInfo("en");
            if (string.IsNullOrWhiteSpace(cultura_enviada) == false && cultura_suportada.Any(u => u.Name.Equals(cultura_enviada)))
            {
                cultura_padrao = new CultureInfo(cultura_enviada);
            }
            CultureInfo.CurrentCulture = cultura_padrao;
            CultureInfo.CurrentUICulture = cultura_padrao;

            await _delegate(context);
        }

    }
}
