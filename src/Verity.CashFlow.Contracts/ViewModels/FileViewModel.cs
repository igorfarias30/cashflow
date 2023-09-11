namespace Verity.CashFlow.Contracts.ViewModels;

public record struct FileViewModel
{
    public FileViewModel(string fileName, string mymeType, byte[] bytes)
    {
        FileName = fileName;
        MymeType = mymeType;
        Bytes = bytes;
    }

    public string FileName { get; }

    public string MymeType { get; }

    public byte[] Bytes { get; }
}
