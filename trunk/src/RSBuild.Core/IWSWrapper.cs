namespace RSBuild
{
    using System;

    public interface IWSWrapper : IDisposable
    {
        void CreateFolder(string Folder, string Parent);
        void CreateDataSource(DataSource source);
        void CreateReport(ReportGroup reportGroup, Report report);
    }
}
