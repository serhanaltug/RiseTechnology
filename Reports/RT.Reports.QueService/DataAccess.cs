using Microsoft.Extensions.DependencyInjection;
using RT.Contacts.Business.Abstract;
using RT.Contacts.CompositionRoot;

namespace RT.Reports.QueService
{
    public class DataAccess
    {
        readonly ServiceCollection _services = new ServiceCollection();
        protected IServiceProvider _provider;
        protected IReportService _reports;

        public DataAccess()
        {
            MockSetup.InitializeTestContainer(_services);
            _provider = _services.BuildServiceProvider().CreateScope().ServiceProvider;
            _reports = _provider.GetService<IReportService>();
        }

        internal async Task UpdateReport(int id)
        {
            var report = _reports.GetById(id).Data;
            if (report != null)
            {
                var kayitliKisiSayisi = await _reports.GetTotalContactsCountByLocation(report.Konum);
                var kayitliTelefonNumarasiSayisi = await _reports.GetTotalPhoneNumbersCountByLocation(report.Konum);

                report.RaporDurumu = 1;
                report.KayitliKisiSayisi = kayitliKisiSayisi;
                report.KayitliTelefonNumarasiSayisi = kayitliTelefonNumarasiSayisi;

                _reports.Update(report);

                await Task.Delay(10000);
            }
        }
    }
}
